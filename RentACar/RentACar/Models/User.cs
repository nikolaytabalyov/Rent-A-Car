﻿using Microsoft.AspNetCore.Identity;

namespace RentACar.Models {
    public class User : IdentityUser {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
