namespace WarehouseBlazor.DTO
{
    public class ArticleResponse
    {
        public int ArticleId { get; set; }

        public string UniqueCode { get; set; } = null!;

        public string ArticleName { get; set; } = null!;

        public string? Descriptions { get; set; }

        public int Stock { get; set; }

        public string? IsReturnable { get; set; }

        public int CategoryId { get; set; }

        public int UnitId { get; set; }

        public int BrandId { get; set; }

        public int StatusId { get; set; }

        public virtual BrandResponse Brand { get; set; } = null!;

        public virtual CategoriesResponse Category { get; set; } = null!;

        //public virtual ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();

        public virtual StatusResponse Status { get; set; } = null!;

        public virtual MeasurementUnitResponse Unit { get; set; } = null!;
    }
    public class ArticleRequest
    {
        //public int ArticleId { get; set; }

        public string UniqueCode { get; set; } = null!;

        public string ArticleName { get; set; } = null!;

        public string? Descriptions { get; set; }

        public int Stock { get; set; }

        public string? IsReturnable { get; set; }

        public int CategoryId { get; set; }

        public int UnitId { get; set; }

        public int BrandId { get; set; }

        public int StatusId { get; set; }

        //public virtual Brand Brand { get; set; } = null!;

        //public virtual Category Category { get; set; } = null!;

        //public virtual ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();

        //public virtual Status Status { get; set; } = null!;

        //public virtual MeasurementUnit Unit { get; set; } = null!;
    }
}
