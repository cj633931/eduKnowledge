using eduKnowledge.Contracts;
using eduKnowledge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Repository
{
    public class TaggedArticleRepository : ITaggedArticleRepository
    {
        private readonly ApplicationDbContext _db;

        public TaggedArticleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(TaggedArticle entity)
        {
            _db.TaggedArticles.Add(entity);
            return Save();
        }

        public bool Delete(TaggedArticle entity)
        {
            _db.TaggedArticles.Remove(entity);
            return Save();
        }

        public ICollection<TaggedArticle> FindAll()
        {
            return _db.TaggedArticles.ToList();
        }

        public TaggedArticle FindById(int id)
        {
            return _db.TaggedArticles.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(TaggedArticle entity)
        {
            _db.TaggedArticles.Update(entity);
            return Save();
        }
    }
}
