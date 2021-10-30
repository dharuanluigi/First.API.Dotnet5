using First.API.Model;
using First.API.Model.Contexts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First.API.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly MySQLContext _context;
        private readonly ILogger<BookRepositoryImplementation> _logger;

        public BookRepositoryImplementation(MySQLContext context, ILogger<BookRepositoryImplementation> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Book AddBook(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when add a new book {e.Message}");
                throw;
            }

            return book;
        }

        public void DeleteABook(int id)
        {
            try
            {
                var book = GetABookById(id);

                if(book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to delete a book {e.Message}");
                throw;
            }
        }

        public Book GetABookById(int id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public List<Book> GetAll()
        {
            try
            {
                return _context.Books.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to get all data from DB: {e.Message}");
                throw;
            }
        }

        public Book UpdateBook(Book updatedBook)
        {
            try
            {
                var result = GetABookById(updatedBook.Id);

                if(result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(updatedBook);
                    _context.SaveChanges();
                }
                else
                {
                    return default;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to update a book {e.Message}");
                throw;
            }

            return updatedBook;
        }
    }
}
