
using NGO_DB_Project.Models;

namespace NGO_DB_Project.Services;

public interface IAccountService
{
    public bool Login(string username, string password);
    public bool Register(Member member);
    public bool AdminLogin(string username, string password);
}
