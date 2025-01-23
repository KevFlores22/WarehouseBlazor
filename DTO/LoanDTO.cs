namespace WarehouseBlazor.DTO
{
    public class LoanResponse
    {
        public int LoanId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        //public int StatusId { get; set; }

        //public int GrocerId { get; set; }

        //public int UserId { get; set; }

        public virtual UserResponse Grocer { get; set; } = null!;

        //public virtual ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();

        //public virtual ICollection<LoanValidation> LoanValidations { get; set; } = new List<LoanValidation>();

        public virtual StatusResponse Status { get; set; } = null!;

        public virtual UserResponse User { get; set; } = null!;
    }
    public class LoanRequest
    {
        public int LoanId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int StatusId { get; set; }

        public int GrocerId { get; set; }

        public int UserId { get; set; }

        //public virtual User Grocer { get; set; } = null!;

        //public virtual ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();

        //public virtual ICollection<LoanValidation> LoanValidations { get; set; } = new List<LoanValidation>();

        //public virtual Status Status { get; set; } = null!;

        //public virtual User User { get; set; } = null!;
    }
}
