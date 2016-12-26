using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectTLCNShopCore.EF
{
    public partial class Users
	{
        public Users()
        {
            Attendance = new HashSet<Attendance>();
            Customers = new HashSet<Customers>();
            PointHistory = new HashSet<PointHistory>();
            Rating = new HashSet<Rating>();
            SurveyUsers = new HashSet<SurveyUsers>();
            WishList = new HashSet<WishList>();
        }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Looked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarPicture { get; set; }
        public string CoverPicture { get; set; }
        public int Lpoint { get; set; }
        public int? ReferUserId { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<PointHistory> PointHistory { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<SurveyUsers> SurveyUsers { get; set; }
        public virtual ICollection<WishList> WishList { get; set; }
    }
}
