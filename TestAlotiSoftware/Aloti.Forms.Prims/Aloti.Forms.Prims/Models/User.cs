using Shared.Common.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aloti.Forms.Prims.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Document { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public Rules Rule { get; set; }

    }
}
