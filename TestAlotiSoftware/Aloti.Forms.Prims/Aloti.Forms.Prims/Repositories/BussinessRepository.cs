using Aloti.Forms.Prims.Models;
using Aloti.Forms.Prims.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aloti.Forms.Prims.Repositories
{
    public class BussinessRepository : SQliteRepository<BussinesUnit, string>
    {
        public BussinessRepository()
        {

        }

        public void SaveClient(BussinesUnit bussinesUnit)
        {
            Save(bussinesUnit);
        }

        public List<BussinesUnit> ListBussinesUnit()
        {
            return FindAll().ToList();

        }

        public BussinesUnit BussinesUnitCall(int Id)
        {
            return FindAllWhere(c => c.Id == Id).FirstOrDefault();

        }

        public bool ExistBussinesUnit(int Id)
        {
            var BussinesUnitExist = FindAllWhere(id => id.Id == Id).FirstOrDefault();

            if (BussinesUnitExist != null)
            {
                return true;
            }

            return false;
        }

    }
}
