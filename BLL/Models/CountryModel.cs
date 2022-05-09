using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class CountryModel //модель дто для страны
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public CountryModel()
        {

        }

        public CountryModel(Country c)
        {
            CountryId = c.CountryId;
            Name = c.Name;
        }
    }
}
