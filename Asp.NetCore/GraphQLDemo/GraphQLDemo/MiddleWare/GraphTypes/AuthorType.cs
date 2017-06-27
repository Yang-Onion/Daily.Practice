using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLDemo.Model;

namespace GraphQLDemo.MiddleWare.GraphTypes
{
    public class AuthorType: ObjectGraphType<Author>
    {
        public AuthorType() {
            Field(x => x.Id).Description("The Id of the author.");
            Field(x => x.Name).Description("The name of the author.");
            Field(x => x.Birthdate).Description("The birthdate of the author.");
            Field(x => x.SecondName).Description("The NickName of the author");
            Field<ListGraphType<BookType>>("books",
                resolve: context => new Book[] { });

        }

    }
}
