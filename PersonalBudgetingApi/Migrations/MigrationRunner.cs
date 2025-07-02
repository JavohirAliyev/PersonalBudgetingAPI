using System.Data.SQLite;
using System.IO;

namespace PersonalBudgetingApi.Migration;

public static class MigrationRunner
{
    public static void RunMigrations(SQLiteConnection connection)
    {
        string sql = File.ReadAllText("Migrations/CreateUserTable.sql");
        using var command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        Console.WriteLine("Migration completed: Users table created.");
    }
}
