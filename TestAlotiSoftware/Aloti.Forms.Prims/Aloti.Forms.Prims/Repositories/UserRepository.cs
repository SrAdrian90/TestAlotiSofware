using Aloti.Forms.Prims.Helpers;
using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Storage;
using FFImageLoading;
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

        public bool DeleteUser(User user)
        {
            try
            {
                Delete(user);
                return true;
            }
            catch (Exception)
            {

                throw;

            }

        }

        public bool ExisteDocument(User user)
        {
            var userResponse = FindAllWhere(d => d.Document == user.Document).FirstOrDefault();

            if (userResponse != null)
            {
                return true;
            }

            return false;
        }

        public User LoginUser(string username, string password)
        {
            password = Encrypt.GetSHA256(password);

            try
            {
                User user = FindAllWhere(d => d.Username.ToLower() == username.ToLower()).FirstOrDefault();

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        return user;
                    }

                    return null;
                }

                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<User> ListUser()
        {
            return FindAll().ToList();

        }
    }
}
