namespace WarehouseBlazor.DTO
{
    public class CategoriesResponse
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
    public class CategoriesRequest
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
