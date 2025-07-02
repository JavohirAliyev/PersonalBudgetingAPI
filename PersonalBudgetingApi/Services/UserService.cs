namespace PersonalBudgetingApi.Service;
using System;
using System.Data.SQLite;
using PersonalBudgetingApi.Interface;
using PersonalBudgetingApi.Models;

public class UserService : IUserService
{
    public void AddUser(SQLiteConnection connection, User user)
    {
        string query = @"
            INSERT INTO Users (
                Id, FirstName, LastName, Email, PasswordHash, ProfilePictureUrl,
                DateOfBirth, Currency, PreferredLanguage, IsEmailConfirmed,
                Role, CreatedAt, UpdatedAt, IsActive
            ) VALUES (
                @Id, @FirstName, @LastName, @Email, @PasswordHash, @ProfilePictureUrl,
                @DateOfBirth, @Currency, @PreferredLanguage, @IsEmailConfirmed,
                @Role, @CreatedAt, @UpdatedAt, @IsActive
            );
        ";

        using var command = new SQLiteCommand(query, connection);
        command.Parameters.AddWithValue("@Id", user.Id.ToString());
        command.Parameters.AddWithValue("@FirstName", user.FirstName);
        command.Parameters.AddWithValue("@LastName", user.LastName);
        command.Parameters.AddWithValue("@Email", user.Email);
        command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
        command.Parameters.AddWithValue("@ProfilePictureUrl", (object?)user.ProfilePictureUrl ?? DBNull.Value);
        command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth?.ToString("yyyy-MM-ddTHH:mm:ss") ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@Currency", user.Currency);
        command.Parameters.AddWithValue("@PreferredLanguage", user.PreferredLanguage);
        command.Parameters.AddWithValue("@IsEmailConfirmed", user.IsEmailConfirmed ? 1 : 0);
        command.Parameters.AddWithValue("@Role", user.Role);
        command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss"));
        command.Parameters.AddWithValue("@UpdatedAt", user.UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ss"));
        command.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);

        command.ExecuteNonQuery();
        Console.WriteLine("User added.");
    }
}
