using Microsoft.AspNetCore.SignalR;
using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlotiSoftware.Server.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Document { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Rules Rule { get; set; }

        public IDType IDType { get; set; }

        public ICollection<BusinessUnit> BusinessUnits { get; set; }

        public ICollection<Request> Requests { get; set; }

    }
}
