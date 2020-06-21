using Shared.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlotiSoftware.Server.Data.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public StateRequest StateRequest { get; set; }

        public Client Client { get; set; }

        public string FilingOffice { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public Nullable<DateTime> DateInitial { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public Nullable<DateTime> DateEnd { get; set; }

    }
}
