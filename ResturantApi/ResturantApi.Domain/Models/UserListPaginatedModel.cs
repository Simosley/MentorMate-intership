namespace ResturantApi.Domain.Models
{
    public class UserResponseModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalUsers { get; set; }
        public List<UserResponseModelProps> Users { get; set; }
    }
}
