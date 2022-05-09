using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class FilmModel //модель дто для фильма
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int CountryId { get; set; }
        public int Timing { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }

        public FilmModel()
        {

        }

        public FilmModel(Film f)
        {
            FilmId = f.FilmId;
            Name = f.Name;
            GenreId = f.GenreId;
            CountryId = f.CountryId;
            Timing = f.Timing;
            Description = f.Description;
            Poster = f.Poster;
        }
    }
}
