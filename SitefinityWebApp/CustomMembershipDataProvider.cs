using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security.Data;
using Telerik.Sitefinity.Security.Model;

namespace SitefinityWebApp
{
    public class CustomMembershipDataProvider : MembershipDataProvider
    {
        public override User CreateUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override User CreateUser(Guid id, string userName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public override User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<User> GetUsers()
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = Guid.Parse("C0C82BC3-DF24-477E-9EFA-1DA96BF298F7"),
                    FirstName = "Chris",
                    LastName = "Woodard",
                    Email = "chris.woodard@progress.com",
                    ApplicationName = this.ApplicationName
                },
                new User()
                {
                    Id = Guid.Parse("23811D98-7072-47DE-8D08-F30DD8E0C61F"),
                    FirstName = "Another",
                    LastName = "User",
                    Email = "test.email@progress.com",
                    ApplicationName = this.ApplicationName
                }
            };

            foreach(var user in users)
            {
                user.SetUserName(user.Email);
                ((IDataItem)user).Provider = this;
            }

            return users.AsQueryable();
        }
    }
}