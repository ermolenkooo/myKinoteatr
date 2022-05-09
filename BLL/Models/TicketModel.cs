using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class TicketModel //модель дто для билета
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public string ViewerId { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }

        public TicketModel()
        {

        }

        public TicketModel(Ticket t)
        {
            TicketId = t.TicketId;
            SessionId = t.SessionId;
            ViewerId = t.ViewerId;
            Row = t.Row;
            Place = t.Place;
            Price = t.Price;
            Status = t.Status;
        }
    }
}
