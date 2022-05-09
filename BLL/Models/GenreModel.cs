using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class GenreModel //модель дто для жанра
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public GenreModel()
        {

        }

        public GenreModel(Genre g)
        {
            GenreId = g.GenreId;
            Name = g.Name;
        }
    }
}
