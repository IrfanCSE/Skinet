namespace Core.Specifications
{
    public class ProductParams
    {
        private const int MaxPageSize = 10;
        private int _pageSize = 6;
        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int PageIndex { get; set; } = 1;
        
        public string Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        private string _search;
        public string Search {
            get => _search;
            set => _search=value.ToLower();
        }
    }        
}