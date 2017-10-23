using System;
using System.Linq;
using System.Threading.Tasks;

namespace LinqPageDemo.Page
{
    public static class LinqExtension
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> queryLinq, PageQuery pageQuery) where T : class
        {
            PagedList<T> pagedResult = null;
            if (pageQuery.IsPage)
            {
                if (pageQuery.PageIndex <= 0)
                {
                    pageQuery.PageIndex = 0;
                }
                if (pageQuery.PageSize <= 0)
                {
                    pageQuery.PageSize = 20;
                }
                pagedResult =
                    new PagedList<T>(
                        queryLinq.Skip(pageQuery.PageIndex*pageQuery.PageSize).Take(pageQuery.PageSize).ToList());
            }
            else
            {
                pagedResult = new PagedList<T>(queryLinq.ToList());
            }
            pagedResult.Paged = new Pagination();
            pagedResult.Paged.TotalCount = queryLinq.Count();
            pagedResult.Paged.PageCount = (int) Math.Ceiling(pagedResult.Paged.TotalCount/(pageQuery.PageSize*1.0));
            pagedResult.Paged.PageSize = pageQuery.PageSize;
            pagedResult.Paged.PageIndex = pageQuery.PageIndex;

            return pagedResult;
        }


        public static Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> queryLinq, PageQuery pageQuery)
            where T : class
        {
            return Task.FromResult(ToPagedList(queryLinq, pageQuery));
        }
    }
}