using eduKnowledge.Contracts;
using eduKnowledge.Data;
using eduKnowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Article entity)
        {
            _db.Articles.Add(entity);
            return Save();
        }

        public bool Delete(Article entity)
        {
            _db.Articles.Remove(entity);
            return Save();
        }

        public ICollection<Article> FindAll()
        {
            return _db.Articles.ToList();
        }

        public Article FindById(int id)
        {
            return _db.Articles.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Article entity)
        {
            _db.Articles.Update(entity);
            return Save();
        }
    }
}
