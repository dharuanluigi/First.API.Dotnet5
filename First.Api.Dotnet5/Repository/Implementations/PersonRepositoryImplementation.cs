﻿using First.API.Model;
using First.API.Model.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First.API.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var result = FindById(id);

                if (result != null)
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return default;
            }

            var result = FindById(person.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public bool Exists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }
    }
}
