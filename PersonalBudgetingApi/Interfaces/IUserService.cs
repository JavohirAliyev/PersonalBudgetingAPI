using System.Data.SQLite;
using PersonalBudgetingApi.Service;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Interface;


public interface IUserService
{
    public void AddUser(SQLiteConnection connection, User user);
}