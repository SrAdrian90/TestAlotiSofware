using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aloti.Forms.Prims.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Rules Rule { get; set; }

        public IDType IDType { get; set; }

        public ICollection<BussinesUnit> BusinessUnits { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
