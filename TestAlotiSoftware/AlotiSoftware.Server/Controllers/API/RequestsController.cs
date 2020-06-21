using AlotiSoftware.Server.Data;
using AlotiSoftware.Server.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlotiSoftware.Server.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly DataContext _context;

        public RequestsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            try
            {
                List<Request> requests = await _context.Requests.Include(c => c.Client)
                                                                        .ThenInclude(b => b.BusinessUnits).ToListAsync();


                return Ok(ToRequestResponse(requests));

            }

            catch (Exception ex)
            {

                return BadRequest(ex);

            }
        }

        public List<RequestResponse> ToRequestResponse(List<Request> requests)
        {
            return requests.Select(r => new RequestResponse
            {
                Id = r.Id,
                DateEnd = r.DateEnd,
                DateInitial = r.DateInitial,
                FilingOffice = r.FilingOffice,
                StateRequest = r.StateRequest,
                Client = ToClientResponse(r.Client),

            }).ToList();
        }


        private ClientResponse ToClientResponse(Client client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientResponse
            {
                Id = client.Id,
                Document = client.Document,
                FirstName = client.FirstName,
                LastName = client.LastName,
                IDType = client.IDType,
                Rule = client.Rule,
                BusinessUnits = client.BusinessUnits?.Select(c => new BusinessUnitResponse
                {
                    Id = c.Id,
                    Address = c.Address,
                    Barrio = c.Barrio,
                    Name = c.Name,
                    Ciudad = c.Ciudad,
                    Phone = c.Phone

                }).OrderBy(n => n.Name).ToList()
            };
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Request request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest([FromRoute] int id, [FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostRequest([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Request request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}