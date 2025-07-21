using PersonalBudgetingApi.Database;

namespace PersonalBudgetingApi.Services
{
    public class SubscriptionCronJobService(IServiceProvider serviceProvider) : IHostedService
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;
        private Timer? _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var midnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc);
            _timer = new Timer(CheckSubscription, null, midnight - now, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void CheckSubscription(object? state)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PersonalBudgetingDbContext>();

            var subscriptions = context.Subsccriptions
                .Where(s => s.EndDate >= DateTime.UtcNow)
                .ToList();

            foreach (var subscription in subscriptions)
            {
                subscription.IsActive = false;
                Console.WriteLine($"Processing subscription: {subscription.Name} for user {subscription.UserId}");
            }

            context.SaveChanges();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}