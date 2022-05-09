using BLL.Interfaces;
using BLL.Models;
using DAL.Repository;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class BookingService : IBooking
    {
        IDbRepos db; //реализация репозитория
        ILogger logger; // логгер

        public BookingService()
        {
            var loggerFactory = LoggerFactory.Create(builder => //логгирование
            {
                builder.AddConsole();
            });

            logger = loggerFactory.CreateLogger<BookingService>(); 
            try
            {
                db = new DbReposSQL(); //создание репозитория
            }
            catch
            {
                logger.LogError("Error in the database connection");
            }
        }

        public void NewBooking(List<TicketModel> tickets, string id_viewer) //функция бронирования билетов
        {
            //для всех билетов из list изменяется статус и устанавливается id зрителя
            try
            {
                for (int i = 0; i < tickets.Count; i++)
                {
                    Ticket ticket = db.Tickets.GetItem(tickets[i].TicketId);
                    ticket.Status = 0;
                    ticket.ViewerId = id_viewer;
                    db.Tickets.Update(ticket);
                }
                Save();
            }
            catch
            {
                logger.LogError("Ticket booking error");
            }
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
