using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AgileBookStore.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AgileBookStoreUser class
public enum Gender
{
	Male = 0,
	Female = 1,
	Other = 2,
    undefined = 3
}
public class AgileBookStoreUser : IdentityUser
{
	public string? Name { get; set; }
	public DateTime DayOfBirth { get; set; } = DateTime.Now;
	public string? ImgAvatar { get; set; } = "https://i.pinimg.com/564x/0d/64/98/0d64989794b1a4c9d89bff571d3d5842.jpg";
	public string? Address { get; set; } = " ";
	public Gender? Gender { get; set; } = null;
}

