using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Model;

namespace GraphQLDemo.Repository.Impl
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookRepository(ApplicationContext context) {
            _context = context;
        }
        public IEnumerable<Author> AllAuthors() {
            return _context.Authors;
        }

        public IEnumerable<Book> AllBooks() {
            return _context.Books;
        }

        public Author AuthorById(int id) {
            return _context.Authors.Find(id);
        }

        public Book BookByIsbn(string isbn) {
            return _context.Books.Find(isbn);
        }
    }
}
