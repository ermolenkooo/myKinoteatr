using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private FilmContext db; //контекст базы данных
        private FilmRepositorySQL filmRepository; //репозитории
        private CountryRepositorySQL countryRepository;
        private GenreRepositorySQL genreRepository;
        private HallRepositorySQL hallRepository;
        private SessionRepositorySQL sessionRepository;
        private TicketRepositorySQL ticketRepository;

        public DbReposSQL()
        {
            db = new FilmContext(); //создание контекста
        }

        public IRepository<Film> Films //создание репозитория фильмов
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepositorySQL(db);
                return filmRepository;
            }
        }

        public IRepository<Country> Countries //создание репозитория стран
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepositorySQL(db);
                return countryRepository;
            }
        }

        public IRepository<Genre> Genres //создание репозитория жанров
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepositorySQL(db);
                return genreRepository;
            }
        }

        public IRepository<Hall> Halls //создание репозитория залов
        {
            get
            {
                if (hallRepository == null)
                    hallRepository = new HallRepositorySQL(db);
                return hallRepository;
            }
        }

        public IRepository<Session> Sessions //создание репозитория сеансов
        {
            get
            {
                if (sessionRepository == null)
                    sessionRepository = new SessionRepositorySQL(db);
                return sessionRepository;
            }
        }

        public IRepository<Ticket> Tickets //создание репозитория билетов
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepositorySQL(db);
                return ticketRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}