namespace WarehouseBlazor.DTO
{
    public class RoleResponse
    {
        public int RoleId { get; set; }

        public string RolName { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
    public class RoleRequest
    {
        //public int RoleId { get; set; }

        public string RolName { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
