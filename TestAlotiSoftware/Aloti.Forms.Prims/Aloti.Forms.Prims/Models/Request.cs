using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aloti.Forms.Prims.Models
{
    public class Request
    {
        public int Id { get; set; }

        public StateRequest StateRequest { get; set; }

        public Client Client { get; set; }

        public string FilingOffice { get; set; }

        public Nullable<DateTime> DateInitial { get; set; }

        public Nullable<DateTime> DateEnd { get; set; }
    }
}
