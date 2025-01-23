namespace WarehouseBlazor.DTO
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public string? FullName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Passwords { get; set; }

        //public int RoleId { get; set; }

        //public int StatusId { get; set; }

        //public virtual ICollection<Loan> LoanGrocers { get; set; } = new List<Loan>();

        //public virtual ICollection<Loan> LoanUsers { get; set; } = new List<Loan>();

        public virtual RoleResponse Role { get; set; } = null!;

        public virtual StatusResponse Status { get; set; } = null!;
    }
    public class UserRequest
    {
        //public int UserId { get; set; }

        public string? FullName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Passwords { get; set; }

        public int RoleId { get; set; }

        public int StatusId { get; set; }

        //public virtual ICollection<Loan> LoanGrocers { get; set; } = new List<Loan>();

        //public virtual ICollection<Loan> LoanUsers { get; set; } = new List<Loan>();

        //public virtual Role Role { get; set; } = null!;

        //public virtual Status Status { get; set; } = null!;
    }
}
