namespace WarehouseBlazor.DTO
{
    public class BrandResponse
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
    public class BrandRequest
    {
        //public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
