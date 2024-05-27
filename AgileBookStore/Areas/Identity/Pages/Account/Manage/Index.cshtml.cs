// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AgileBookStore.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgileBookStore.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AgileBookStoreUser> _userManager;
        private readonly SignInManager<AgileBookStoreUser> _signInManager;

        public IndexModel(
            UserManager<AgileBookStoreUser> userManager,
            SignInManager<AgileBookStoreUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 
        public string CurrentImgAvatarPath { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			/// 

			[Required]
			[DataType(DataType.Text)]
			[Display(Name = "Full name")]
			public string Name { get; set; }

			[Display(Name = "Birth Date")]
			[DataType(DataType.Date)]
			public DateTime DOB { get; set; }

			[Display(Name = "Address")]
			[DataType(DataType.Text)]
			public string Address { get; set; }

			[Display(Name = "Avatar")]
			public IFormFile ImgAvatar { get; set; }

			[Display(Name = "Gender")]
			public Gender Gender { get; set; }

            [EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(AgileBookStoreUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
				Name = user.Name,
				DOB = user.DayOfBirth,
				Address = user.Address,
				ImgAvatar = null,
				Email = user.Email,
				PhoneNumber = phoneNumber,
                Gender = user.Gender ?? Gender.undefined
            };
            CurrentImgAvatarPath = user.ImgAvatar;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.Name != user.Name)
			{
                user.Name = Input.Name;

            }
			if (Input.DOB != user.DayOfBirth)
			{
				user.DayOfBirth = Input.DOB;
			}
			if (Input.Address != user.Address)
			{
				user.Address = Input.Address;
			}

            if (Input.ImgAvatar != null && Input.ImgAvatar.Length > 0)
            {
                var fileName = Path.GetFileName(Input.ImgAvatar.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.ImgAvatar.CopyToAsync(stream);
                }

                user.ImgAvatar = "/uploads/" + fileName;
            }

            if (Input.Gender != user.Gender)
			{
                user.Gender = Input.Gender;
			}
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
