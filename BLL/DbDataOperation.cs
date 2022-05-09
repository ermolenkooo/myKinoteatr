using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DAL.Repository;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class DbDataOperation : IDbCrud
    {
        IDbRepos db; // реализация репозитория
        ILogger logger; // логгер

        public DbDataOperation()
        {
            var loggerFactory = LoggerFactory.Create(builder => //логгирование
            {
                builder.AddConsole(); 
            });

            logger = loggerFactory.CreateLogger<DbDataOperation>();
            try
            {
                db = new DbReposSQL(); //создание репозитория
            }
            catch
            {
                logger.LogError("Error in the database connection");
            }
        }

        public List<FilmModel> GetAllFilms() //получение списка фильмов
        {
            try
            {
                return db.Films.GetList().Select(i => new FilmModel(i)).ToList();
            }
            catch
            {
                logger.LogError("Error getting a list of movies from the database");
                return null;
            }
        }

        public List<CountryModel> GetAllCountries() //получение списка стран
        {
            try
            {
                return db.Countries.GetList().Select(i => new CountryModel(i)).ToList();
            }
            catch
            {
                logger.LogError("Error getting a list of countries from the database");
                return null;
            }
        }

        public List<GenreModel> GetAllGenres() //получение списка жанров
        {
            try
            {
                return db.Genres.GetList().Select(i => new GenreModel(i)).ToList();
            }
            catch
            {
                logger.LogError("Error getting a list of genres from the database");
                return null;
            }
        }

        public List<HallModel> GetAllHalls() //получение списка залов
        {
            try
            {
                return db.Halls.GetList().Select(i => new HallModel(i)).ToList();
            }
            catch
            {
                logger.LogError("Error getting a list of halls from the database");
                return null;
            }
        }

        public List<SessionModel> GetAllSessions() //получение списка сеансов
        {
            try
            {
                return db.Sessions.GetList().Select(i => new SessionModel(i)).ToList();
            }
            catch
            {
                logger.LogError("Error getting a list of sessions from the database");
                return null;
            }
        }

        public List<TicketModel> GetAllTickets() //получение списка билетов
        {
            try
            {
                return db.Tickets.GetList().Select(i => new TicketModel(i)).ToList();
            }
            catch
            {
                logger.LogError("Error getting a list of tickets from the database");
                return null;
            }
        }

        public FilmModel GetFilm(int Id) //получение фильма по id 
        {
            try
            {
                return new FilmModel(db.Films.GetItem(Id));
            }
            catch
            {
                logger.LogError("Error getting a movie by id " + Id);
                return null;
            }
        }

        public void CreateFilm(FilmModel f) //добавление нового фильма
        {
            try
            {
                db.Films.Create(new Film() { Name = f.Name, GenreId = f.GenreId, CountryId = f.CountryId, Timing = f.Timing, Description = f.Description, Poster = f.Poster });
                Save();
            }
            catch
            {
                logger.LogError("Error adding a new movie");
            }
        }

        public void UpdateFilm(FilmModel f) //обновление фильма
        {
            try
            {
                Film film = db.Films.GetItem(f.FilmId);
                film.Name = f.Name;
                film.GenreId = f.GenreId;
                film.CountryId = f.CountryId;
                film.Timing = f.Timing;
                film.Description = f.Description;
                film.Poster = f.Poster;
                db.Films.Update(film);
                Save();
            }
            catch
            {
                logger.LogError("Movie update error " + f.FilmId);
            }
        }

        public void DeleteFilm(int id) //удаление фильма
        {
            try
            {
                Film f = db.Films.GetItem(id);
                if (f != null)
                {
                    db.Films.Delete(f.FilmId);
                    Save();
                }
            }
            catch
            {
                logger.LogError("Movie deletion error " + id);
            }
        }

        public SessionModel GetSession(int Id) //получение сеанса по id 
        {
            try
            {
                return new SessionModel(db.Sessions.GetItem(Id));
            }
            catch
            {
                logger.LogError("Error getting a session by id " + Id);
                return null;
            }
        }

        public void CreateSession(SessionModel s) //добавление нового сеанса
        {
            try
            {
                db.Sessions.Create(new Session() { FilmId = s.FilmId, Time = s.Time, HallId = s.HallId });
                Save();
            }
            catch
            {
                logger.LogError("Error adding a new session");
            }
        }

        public void UpdateSession(SessionModel s) //обновление сеанса
        {
            try
            {
                Session session = db.Sessions.GetItem(s.SessionId);
                session.FilmId = s.FilmId;
                session.Time = s.Time;
                session.HallId = s.HallId;
                db.Sessions.Update(session);
                Save();
            }
            catch
            {
                logger.LogError("Session update error " + s.SessionId);
            }
        }

        public void DeleteSession(int id) //удаление сеанса
        {
            try
            {
                Session s = db.Sessions.GetItem(id);
                if (s != null)
                {
                    db.Sessions.Delete(s.SessionId);
                    Save();
                }
            }
            catch
            {
                logger.LogError("Session deletion error " + id);
            }
        }

        public TicketModel GetTicket(int Id) //получение билета по id 
        {
            try
            {
                return new TicketModel(db.Tickets.GetItem(Id));
            }
            catch
            {
                logger.LogError("Error getting a ticket by id " + Id);
                return null;
            }
        }

        public void UpdateTicket(TicketModel t) //обновление билета
        {
            try
            {
                Ticket ticket = db.Tickets.GetItem(t.TicketId);
                ticket.SessionId = t.SessionId;
                ticket.ViewerId = t.ViewerId;
                ticket.Row = t.Row;
                ticket.Place = t.Place;
                ticket.Price = t.Price;
                ticket.Status = t.Status;
                db.Tickets.Update(ticket);
                Save();
            }
            catch
            {
                logger.LogError("Ticket update error " + t.TicketId);
            }
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
