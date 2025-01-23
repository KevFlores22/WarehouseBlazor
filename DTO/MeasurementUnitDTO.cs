namespace WarehouseBlazor.DTO
{
    public class MeasurementUnitResponse
    {
        public int UnitId { get; set; }

        public string MeasurementUnitName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
    public class MeasurementUnitRequest
    {
        public int UnitId { get; set; }

        public string MeasurementUnitName { get; set; } = null!;

        //public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
