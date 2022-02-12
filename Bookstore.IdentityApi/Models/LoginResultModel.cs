using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.IdentityApi.Models
{
    public class LoginResultModel
    {
        public LoginUserInfoModel User { get; }
        public string AccessToken { get; }
        public IList<string> Roles { get; }

        public LoginResultModel(LoginUserInfoModel user, string accessToken, IList<string> roles)
        {
            User = user;
            AccessToken = accessToken;
            Roles = roles;
        }

        public override bool Equals(object obj)
        {
            return obj is LoginResultModel other &&
                   EqualityComparer<LoginUserInfoModel>.Default.Equals(User, other.User) &&
                   AccessToken == other.AccessToken &&
                   EqualityComparer<IList<string>>.Default.Equals(Roles, other.Roles);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(User, AccessToken, Roles);
        }
    }
}
