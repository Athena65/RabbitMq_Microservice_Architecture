using Shared.Models;
using System.Threading.Tasks;

namespace Ticketing.Microservice.Services
{
    public interface ITicketService
    {
        public Task<Ticket> CreateTicket(Ticket ticket);
    }
}
