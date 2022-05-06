using Lunatech.Application.Core.Exceptions;
using Lunatech.Application.Model.Dto.Account;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly AppDbContext _context;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterFormDto register)
        {
            var user = await _userManager.FindByEmailAsync(register.Email);

            if (user is not null)
            {
                throw new Exception("This user is already exist");
            }
            AppUser newUser = new()
            {
                UserName = register.Username,
                Email = register.Email,
                EmailConfirmed = true,
            };

            if (user == null)
            {
                //Burda biz userManager vasitesile user ve RegistirVM passwword yoxluyuruq.(yaradiriq)
                var identityRusult = await _userManager.CreateAsync(newUser, register.Password);

                //Yratdigimiz user ilk yarananda user rolu verik.
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginFormDto user)
        {
            if (ModelState.IsValid)
            {
                AppUser founderUser = null;

                if (user.Username.IsEmail())
                {
                    founderUser = await _userManager.FindByEmailAsync(user.Username);
                    if (founderUser is null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    founderUser = await _userManager.FindByNameAsync(user.Username);
                    if (founderUser is null)
                    {
                        return NotFound();
                    } 
                }
                var sRuselt = await _signInManager.PasswordSignInAsync(founderUser, user.Password, true, true);
                if (!sRuselt.Succeeded)
                {
                    return NotFound();
                }
                return Ok(sRuselt);
            }
            return NotFound();
        }

        [HttpPost("RessetPassword")]
        public async Task<IActionResult> RessetPassword([Required]string Email,string newPassword)
        {

            AppUser user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var identityResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
