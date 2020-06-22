using System;
using System.Collections.Generic;
using System.Text;

namespace Aloti.Forms.Prims.Models
{
    public class BussinesUnit
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
