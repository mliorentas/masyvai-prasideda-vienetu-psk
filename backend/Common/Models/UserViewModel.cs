namespace MasyvaiPrasidedaVienetu.Models
{
    public class UserViewModel
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBanned { get; set; } = false;
        public int UserRole { get; set; } = 0;
    }
}