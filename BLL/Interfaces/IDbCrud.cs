using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDbCrud //интерфейс для crud-функций
    {
        List<FilmModel> GetAllFilms(); //получение списка фильмов
        List<CountryModel> GetAllCountries(); //получение списка стран
        List<GenreModel> GetAllGenres(); //получение списка жанров
        List<HallModel> GetAllHalls(); //получение списка залов
        List<SessionModel> GetAllSessions(); //получение списка сеансов
        List<TicketModel> GetAllTickets(); //получение списка билетов

        FilmModel GetFilm(int filmId); //получение фильма по id
        void CreateFilm(FilmModel f); //добавление нового фильма
        void UpdateFilm(FilmModel f); //обновление фильма
        void DeleteFilm(int id); //удаление фильма

        SessionModel GetSession(int sessionId); //получение сеанса по id
        void CreateSession(SessionModel s); //добавление нового сеанса
        void UpdateSession(SessionModel s); //обновление сеанса
        void DeleteSession(int id); //удаление сеанса

        TicketModel GetTicket(int ticketId); //получение билета по id
        void UpdateTicket(TicketModel t); //обновление билета
    }
}
