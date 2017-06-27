using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Model;

namespace GraphQLDemo.Repository
{
    public interface IBookRepository
    {
        Book BookByIsbn(string isbn);
        IEnumerable<Book> AllBooks();
        Author AuthorById(int id);
        IEnumerable<Author> AllAuthors();
    }
}
