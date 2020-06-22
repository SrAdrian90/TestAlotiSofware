using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aloti.Forms.Prims.Repositories
{
    public class ClientRepository : SQliteRepository<Client, string>
    {

        public ClientRepository()
        {

        }

        public void SaveClient(Client client)
        {
            Save(client);
        }

        public List<Client> ListClients()
        {
            return FindAll().ToList();

        }

        public Client ClientCall(int Id)
        {

            return FindAllWhere(c => c.Id == Id).FirstOrDefault();

        }

        public bool ExistClient(int Id)
        {
            var ClientExist = FindAllWhere(id => id.Id == Id).FirstOrDefault();

            if (ClientExist != null)
            {
                return true;
            }

            return false;
        }
    }
}
