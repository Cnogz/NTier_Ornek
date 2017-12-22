using NTier.Core.Entity;
using NTier.Core.Service;
using NTier.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NTier.Service.BaseService
{
    public class ServiceBase<T> : ICoreService<T> where T : CoreEntity
    {
        private ProjectContext _context;
        //protected DbSet<T> table;
        public ServiceBase()
        {
            _context = new ProjectContext();
            //table = _context.Set<T>();
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            //table.AddRange(items);
            Save();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            //table.AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp); //Bodied Member araştırınız.
        //{
        //    return   _context.Set<T>().Any(exp);
        //}

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Core.Enum.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Core.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(T item)
        {
            item.Status = Core.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Core.Enum.Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetById(item.Id);
            DbEntityEntry entry = _context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();

        }
    }
}
