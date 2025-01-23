namespace WarehouseBlazor.DTO
{
    public class LoanValidationResponse
    {
        public int LoanValidationId { get; set; }

        public DateTime ValidationDate { get; set; }

        public string Observations { get; set; } = null!;

        //public int LoanId { get; set; }

        //public int UserId { get; set; }

        public string IsApproved { get; set; } = null!;

        public virtual LoanResponse Loan { get; set; } = null!;

        public virtual UserResponse User { get; set; } = null!;
    }
    public class LoanValidationRequest
    {
        //public int LoanValidationId { get; set; }

        public DateTime ValidationDate { get; set; }

        public string Observations { get; set; } = null!;

        public int LoanId { get; set; }

        public int UserId { get; set; }

        public string IsApproved { get; set; } = null!;

        //public virtual Loan Loan { get; set; } = null!;

        //public virtual User User { get; set; } = null!;
    }
}
