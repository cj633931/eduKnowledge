using eduKnowledge.Contracts;
using eduKnowledge.Data;
using eduKnowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _db;

        public TagRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Tag entity)
        {
            _db.Add(entity);
            return Save();
        }

        public bool Delete(Tag entity)
        {
            _db.Tags.Remove(entity);
            return Save();
        }

        public ICollection<Tag> FindAll()
        {
            return _db.Tags.ToList();
        }

        public Tag FindById(int id)
        {
            return _db.Tags.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Tag entity)
        {
            _db.Tags.Update(entity);
            return Save();
        }
    }
}
