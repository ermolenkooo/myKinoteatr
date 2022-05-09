using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class SessionModel //модель дто для сеанса
    {
        public int SessionId { get; set; }
        public int FilmId { get; set; }
        public DateTime Time { get; set; }
        public int HallId { get; set; }

        public SessionModel()
        {

        }

        public SessionModel(Session s)
        {
            SessionId = s.SessionId;
            FilmId = s.FilmId;
            Time = s.Time;
            HallId = s.HallId;
        }
    }
}
