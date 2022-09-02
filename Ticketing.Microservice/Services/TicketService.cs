using MassTransit;
using Shared.Models;
using System;
using System.Threading.Tasks;

namespace Ticketing.Microservice.Services
{
    public class TicketService:ITicketService
    {
        private readonly IBus _bus;

        public TicketService(IBus bus)
        {
            _bus = bus; //stratup'a eklenen Bus degiskeni kullaniliyor
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            ticket.BookedOn = DateTime.Now;  
            Uri uri = new Uri("rabbitmq://localhost/ticketQueue");//siramizi ticketqueue olarak adlanidiriyoruz yeni url olusturuyor
            var endPoint = await _bus.GetSendEndpoint(uri); //shared model objelerini gonderebilen endpointi aliyior
            await endPoint.Send(ticket); //mesaji siraya pushluyor
            return ticket;  
        }
    }
}
