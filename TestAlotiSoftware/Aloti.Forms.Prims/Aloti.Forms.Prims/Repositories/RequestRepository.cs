using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aloti.Forms.Prims.Repositories
{
    public class RequestRepository : SQliteRepository<Request, string>
    {
        public RequestRepository()
        {

        }

        public void SaveClient(Request request)
        {
            Save(request);
        }

        public List<Request> ListRequest()
        {
            return FindAll().ToList();

        }

        public Request RequestCall(int Id)
        {
            return FindAllWhere(c => c.Id == Id).FirstOrDefault();

        }

        public bool ExistRequest(int Id)
        {
            var RequestExist = FindAllWhere(id => id.Id == Id).FirstOrDefault();

            if (RequestExist != null)
            {
                return true;
            }

            return false;
        }
    }
}
