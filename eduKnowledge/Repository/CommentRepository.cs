using eduKnowledge.Contracts;
using eduKnowledge.Data;
using eduKnowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Comment entity)
        {
            _db.Comments.Add(entity);
            return Save();
        }

        public bool Delete(Comment entity)
        {
            _db.Comments.Remove(entity);
            return Save();
        }

        public ICollection<Comment> FindAll()
        {
            return _db.Comments.ToList();
        }

        public Comment FindById(int id)
        {
            return _db.Comments.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Comment entity)
        {
            _db.Comments.Update(entity);
            return Save();
        }
    }
}
