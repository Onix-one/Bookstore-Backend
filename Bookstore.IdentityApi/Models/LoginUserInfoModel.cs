using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.IdentityApi.Models
{
    public class LoginUserInfoModel
    {
        public string Name { get; }
        public string Email { get; }

        public LoginUserInfoModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is LoginUserInfoModel other &&
                   Name == other.Name &&
                   Email == other.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Email);
        }
    }
}
