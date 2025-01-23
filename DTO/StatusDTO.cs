namespace WarehouseBlazor.DTO
{
    public class StatusResponse
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

        //public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
    public class StatusRequest
    {
        //public int StatusId { get; set; }

        public string StatusName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

        //public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
