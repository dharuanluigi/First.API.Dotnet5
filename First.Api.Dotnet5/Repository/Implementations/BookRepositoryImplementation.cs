using First.API.Model;
using First.API.Model.Contexts;
using Microsoft.Extensions.Logging;
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

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }
    }
}
