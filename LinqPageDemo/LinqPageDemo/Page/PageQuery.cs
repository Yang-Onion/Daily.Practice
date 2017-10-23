namespace LinqPageDemo.Page
{
    public class PageQuery
    {
        public virtual int PageIndex { get; set; }
        public virtual int PageSize { get; set; }
        public bool IsPage { get; set; } = true;
    }
}
