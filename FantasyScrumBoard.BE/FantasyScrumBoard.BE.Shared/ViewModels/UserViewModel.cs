using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class UserViewModel
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
