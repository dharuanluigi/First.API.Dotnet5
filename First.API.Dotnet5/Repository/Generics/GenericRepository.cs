using First.API.Dotnet5.Model.Base;
using First.API.Model;
using First.API.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.API.Dotnet5.Repository.Generics
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        private DbSet<T> _dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public void Delete(long id)
        {
            try
            {
                var result = FindById(id);

                if (result != null)
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(item => item.Id == id);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
            {
                return default;
            }

            var result = FindById(item.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return item;
        }

        public bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id == id);
        }
    }
}
