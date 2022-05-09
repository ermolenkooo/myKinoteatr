using DAL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GenreRepositorySQL : IRepository<Genre> //репозиторий жанров
    {
        private FilmContext db; //контекст базы данных

        public GenreRepositorySQL(FilmContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Genre> GetList() //получение списка жанров
        {
            List<Genre> genres = db.Genre.ToList();
            db.Dispose();
            return genres;
        }

        public Genre GetItem(int id) //получение жанра по id
        {
            return db.Genre.Find(id);
        }

        public void Create(Genre g) //добавление нового жанра
        {
            db.Genre.Add(g);
        }

        public void Update(Genre g) //обновление жанра
        {
            db.Entry(g).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление жанра
        {
            Genre g = db.Genre.Find(id);
            if (g != null)
                db.Genre.Remove(g);
        }
    }
}

