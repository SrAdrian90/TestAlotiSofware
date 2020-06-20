using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Storage;
using ImTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aloti.Forms.Prims.Repositories
{
    public class UserRepository : SQliteRepository<User, string>
    {
        public UserRepository()
        {

        }

        public void SaveUser(User user)
        {
            Save(user);
        }

        public bool ExisteDocument(User user)
        {
            var x = FindAllWhere(d => d.Document == user.Document).FirstOrDefault();
            return true;

        }

        public List<User> ListUser()
        {
            return FindAll().ToList();

        }
    }
}
