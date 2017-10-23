using System.Collections.Generic;

namespace LinqPageDemo.Page
{

    public interface IPagedList
    {
       Pagination Paged { get; set; }
    }
    public class PagedList<T>:IPagedList
    {
        public PagedList(IEnumerable<T> collection)
        {
            Items = collection;
        } 
        public IEnumerable<T> Items { get; set; } 
        public Pagination Paged { get; set; }
    }

    public class Pagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
