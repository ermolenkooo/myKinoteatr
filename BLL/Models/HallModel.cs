using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class HallModel //модель дто для зала
    {
        public int HallId { get; set; }
        public string Number { get; set; }

        public HallModel()
        {

        }

        public HallModel(Hall h)
        {
            HallId = h.HallId;
            Number = h.Number;
        }
    }
}
