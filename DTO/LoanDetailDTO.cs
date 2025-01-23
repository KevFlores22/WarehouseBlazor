namespace WarehouseBlazor.DTO
{
    public class LoanDetailResponse
    {
        public int LoanDetailId { get; set; }

        public int Quantity { get; set; }

        public string Observations { get; set; } = null!;

        public string? IsReturnable { get; set; }

        //public int LoanId { get; set; }

        //public int ArticleId { get; set; }

        public virtual ArticleResponse Article { get; set; } = null!;

        //public virtual LoanResponse Loan { get; set; } = null!;
    }
    public class LoanDetailRequest
    {
        //public int LoanDetailId { get; set; }

        public int Quantity { get; set; }

        public string Observations { get; set; } = null!;

        public string? IsReturnable { get; set; }

        public int LoanId { get; set; }

        public int ArticleId { get; set; }

        //public virtual Article Article { get; set; } = null!;

        //public virtual Loan Loan { get; set; } = null!;
    }
}
