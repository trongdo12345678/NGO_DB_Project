using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NGO_DB_Project.Services;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace NGO_DB_Project.Models.ClassImpl;

public class ServiceBuid : IAccountService
{
    private readonly GiveAidContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ServiceBuid(GiveAidContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    public bool AdminLogin(string username, string password)
    {
        var admin = _context.Members.Include(m => m.Role).FirstOrDefault(m => m.Username == username && m.Password == password);
        if (admin != null && admin.RoleId == 1)
        {
            _httpContextAccessor.HttpContext.Session.SetString("LoggedInUser", username);
            return true;
        }
        return false;
    }



    public bool Login(string username, string password)
    {
        var member = _context.Members.Include(m => m.Role).FirstOrDefault(m => m.Username == username);
        if (member != null && VerifyPassword(password, member.Password) && member.RoleId == 2)
        {
            _httpContextAccessor.HttpContext.Session.SetString("LoggedInUser", username);
            return true;
        }
        return false;
    }


    public bool Register(Member member)
    {
        var existingMember = _context.Members.FirstOrDefault(m => m.Username == member.Username);
        if (existingMember != null)
        {
           
            return false;
        }
        member.Password = HashPassword(member.Password);

        
        var userRole = _context.Roles.FirstOrDefault(r => r.Id == 2);
        if (userRole != null)
        {
            member.RoleId = userRole.Id;
        }
        else
        {
           
            var newUserRole = new Role { Id = 2, RoleName = "User" };
            _context.Roles.Add(newUserRole);
            _context.SaveChanges();
            member.RoleId = newUserRole.Id;
        }
        
        _context.Members.Add(member);
        Debug.WriteLine(member.Password);
        Debug.WriteLine(member.Email);
        _context.SaveChanges();

        return true;
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    private bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInputPassword = HashPassword(password);
        return string.Equals(hashedInputPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
    }

}
