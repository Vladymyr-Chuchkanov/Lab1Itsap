using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TWeb1
{
    public partial class Account
    {
        public Account()
        {
            Partisipants = new HashSet<Partisipant>();
        }

        public int AccountId { get; set; }
        [Required(ErrorMessage = "Не вказаний логiн")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не вказаний пароль ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? IdRole { get; set; }
        public string RoleName { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Partisipant> Partisipants { get; set; }
    }
}
