using System;

namespace FantasyScrumBoard.BE.Shared.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Level { get; set; }
        public string Nick { get; set; }
        public int Exp { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
