using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectTLCNShopCore.Areas.Admin.Models
{
    public class UserLogin:IdentityUser
    {
		[Key]
		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }

		public UserLogin() { }
		public UserLogin(string email, string pass)
		{
			Email = email;
			Password = pass;
		}
	}
}
