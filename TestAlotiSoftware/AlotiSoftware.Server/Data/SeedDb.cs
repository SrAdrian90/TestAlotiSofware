using AlotiSoftware.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

            await SeedClient("Jeysson",
                        "Cárdenas",
                        "1090419378",
                        0,
                        "Unidos",
                        "Calle falsa #1-23",
                        "Juan de Dios",
                        "56241252",
                        "Mánizales",
                        StateRequest.EnAnalisis,
                        "Oficina 1014",
                        DateTime.Now,
                        DateTime.Now);

            await SeedClient("Freddy",
                        "Hernandez",
                        "234567890",
                        0,
                        "Mi unidad de Neogcio",
                        "Calle falsa #1-23",
                        "Mi Barrio",
                        "2345678",
                        "Bogotá",
                        StateRequest.NoEfectuado,
                        "Oficina 1010",
                        DateTime.Now,
                        DateTime.Now);

            await SeedClient("Ana",
                        "Pérez",
                        "87651790",
                        0,
                        "Rosa de la 93",
                        "Av 5# 1-45",
                        "Las Flores",
                        "87452141",
                        "Medellín",
                        StateRequest.NoEfectuado,
                        "Oficina 1015",
                        new DateTime(2020, 04, 01, 10, 0, 0),
                        new DateTime(2020, 04, 30, 10, 0, 0));

            await SeedClient("Pilar",
                        "Prieto",
                        "87651234",
                        0,
                        "Joyeria Pilar",
                        "Cale 65# 985-8",
                        "Colombia",
                        "98745632",
                        "Bogotá",
                        StateRequest.NoEfectuado,
                        "Oficina 1010",
                        new DateTime(2020, 05, 01, 10, 0, 0),
                        new DateTime(2020, 05, 10, 10, 0, 0));


            await SeedClient("Diana",
                        "Falla",
                        "10987676234",
                        0,
                        "Papeleria Bonaveno",
                        "Calle 45 #1-95",
                        "Madrid",
                        "7896545",
                        "Bogotá",
                        StateRequest.NoEfectuado,
                        "Oficina 1010",
                        new DateTime(2020, 03, 20, 10, 0, 0),
                        new DateTime(2020, 03, 30, 10, 0, 0));

            await SeedClient("Rocio",
                        "Quintero",
                        "8766416789",
                        0,
                        "Pasterelia el buñuelo",
                        "Av 5 # 64-98",
                        "Caracas",
                        "2345678",
                        "Bogotá",
                        StateRequest.NoEfectuado,
                        "Oficina 1010",
                        new DateTime(2020, 04, 08, 10, 0, 0),
                        new DateTime(2020, 04, 20, 10, 0, 0));

            await SeedClient("Leslie",
                        "Robles Lazo",
                        "10904561235",
                        0,
                        "Zapatos la 4",
                        "Calle 1-78",
                        "AmiUnidos",
                        "895456321",
                        "Bogotá",
                        StateRequest.NoEfectuado,
                        "Oficina 1010",
                        new DateTime(2020, 04, 01, 10, 0, 0),
                        new DateTime(2020, 04, 30, 10, 0, 0));

        }


        public async Task SeedClient(string firstnamec,
                                    string lastnamec,
                                    string documentc,
                                    IDType iDType,
                                    string nameb,
                                    string address,
                                    string barriob,
                                    string phoneb,
                                    string cityb,
                                    StateRequest stateRequest,
                                    string office,
                                    DateTime dateTimeInitial,
                                    DateTime dateTimeEnd)

        {

            Client clientExist = await _context.Clients.Where(d => d.Document == documentc).FirstOrDefaultAsync();

            if (clientExist != null)
            {
                return;
            }

            Client client = await ClientCheckAsync(firstnamec, lastnamec, documentc, iDType);
            await BusinessUnit(nameb, address, barriob, phoneb, cityb, client);
            await RequestAsync(stateRequest, office, dateTimeInitial, dateTimeEnd, client);
        }

        public async Task<Client> ClientCheckAsync(string firstname, string lastname, string document, IDType iDType)
        {
            try
            {
                Client client = new Client
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

                }

                return client;


            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task BusinessUnit(string name,
                                        string address,
                                        string barrio,
                                        string phone,
                                        string ciudad,
                                        Client client)
        {

            try
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

                _context.BusinessUnits.Add(businessUnit);
                await _context.SaveChangesAsync();

            }

            catch (Exception)
            {

                throw;
            }


        }

        public async Task RequestAsync(StateRequest stateRequest,
                                        string office,
                                        DateTime dateTimeInitial,
                                        DateTime dateTimeFinal,
                                        Client client)
        {
            try
            {
                Request request = new Request
                {
                    Client = client,
                    StateRequest = stateRequest,
                    FilingOffice = office,
                    DateInitial = dateTimeInitial,
                    DateEnd = dateTimeFinal
                };

                _context.Requests.Add(request);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
