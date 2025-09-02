namespace FoodOrderSystem.Models
{
    public class UpdateMenuRequest
    {
        public string MenuName { get; set; }
        public int ChefId { get; set; }
        public decimal MenuPrice { get; set; }
        public DateTime? AvailabilityStartDate { get; set; }
        public DateTime? AvailabilityEndDate { get; set; }
    }
}
