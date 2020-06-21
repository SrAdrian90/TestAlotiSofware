using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlotiSoftware.Server.Data.Entities
{
    public class BusinessUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Barrio { get; set; }

        public string Phone { get; set; }

        public string Ciudad { get; set; }

        public Client Client { get; set; }

    }
}
