using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Threading.Tasks;
using Ticketing.Microservice.Services;

namespace Ticketing.Microservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                    return NoContent();

                await _ticketService.CreateTicket(ticket);
                return Ok(ticket.UserName +" Created!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
               
            }

        }
        
    
    }
}
