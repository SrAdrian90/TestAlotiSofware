using Shared.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Common.Responses
{
    public class ClientResponse
    {
        public int Id { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Rules Rule { get; set; }

        public IDType IDType { get; set; }

        public List<BusinessUnitResponse> BusinessUnits { get; set; }

        public List<RequestResponse> Requests { get; set; }
    }
}
