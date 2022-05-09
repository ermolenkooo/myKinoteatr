using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IBooking //интерфейс для бронирования
    {
        void NewBooking(List<TicketModel> ticket, string id_viewer); //бронирование билетов
    }
}
