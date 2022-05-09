using DAL.Interfaces;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class FilmRepositorySQL : IRepository<Film> //репозиторий фильмов
    {
        private FilmContext db; //контекст базы данных

        public FilmRepositorySQL(FilmContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Film> GetList() //получение списка фильмов
        {
            List<Film> films = db.Film.ToList();
            db.Dispose();
            return films;
        }

        public Film GetItem(int id) //получение фильма по id
        {
            return db.Film.Find(id);
        }

        public void Create(Film f) //добавление нового фильма
        {
            db.Film.Add(f);
        }

        public void Update(Film f) //обновление фильма 
        {
            db.Entry(f).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление фильма
        {
            Film f = db.Film.Find(id);
            if (f != null)
                db.Film.Remove(f);
        }
    }
}

