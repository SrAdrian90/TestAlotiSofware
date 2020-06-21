using AlotiSoftware.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.Common.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlotiSoftware.Server.Data
{

    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            Client client = await ClientCheckAsync("Freddy",
                                          "Hernandez",
                                          "234567890",
                                          0);

            bool Bussine = await BusinessUnit("Mi unidad de Neogcio",
                                               "Calle falsa #1-23",
                                               "Mi Barrio",
                                               "2345678",
                                               "Bogotá",
                                               client);

            bool Request = await RequestAsync(StateRequest.NoEfectuado, client, "Oficina 1010", DateTime.Now, DateTime.Now);

        }

        public async Task<Client> ClientCheckAsync(string firstname, string lastname, string document, IDType iDType)
        {

            Client client = await _context.Clients.Where(d => d.Document == document).FirstOrDefaultAsync();

            if (client == null)
            {
                client = new Client
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Document = document,
                    IDType = iDType,
                    Rule = Rules.Client

                };

                if (!_context.Clients.Any())
                {
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();
                    return client;
                }
            }

            return client;

        }


        public async Task<bool> BusinessUnit(string name, string address, string barrio, string phone, string ciudad, Client client)
        {
            BusinessUnit businessUnit = new BusinessUnit
            {
                Name = name,
                Address = address,
                Barrio = barrio,
                Phone = phone,
                Ciudad = ciudad,
                Client = client
            };

            if (!_context.BusinessUnits.Any())
            {
                _context.BusinessUnits.Add(businessUnit);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> RequestAsync(StateRequest stateRequest, Client client, string office, DateTime dateTimeInitial, DateTime dateTimeFinal)
        {
            Request request = new Request
            {
                Client = client,
                StateRequest = stateRequest,
                FilingOffice = office,
                DateInitial = dateTimeInitial,
                DateEnd = dateTimeFinal
            };

            if (!_context.Requests.Any())
            {
                _context.Requests.Add(request);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }


    }
}
