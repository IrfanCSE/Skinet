using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using Core.Entities.Identity;
using Core.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/account")]
    public class AccountController : ControllerBase {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountController (
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService) 
        {
            this._tokenService = tokenService;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [HttpPost ("login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto loginDto) {
            var user = await _userManager.FindByEmailAsync (loginDto.Email);

            if (user == null) return Unauthorized (new ApiResponse (401));

            var result = await _signInManager.CheckPasswordSignInAsync (user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized (new ApiResponse (401));

            return new UserDto {
                Email = user.Email,
                    DisplayName = user.DisplayName,
                    Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost ("register")]
        public async Task<ActionResult<UserDto>> Register (RegisterDto registerDto) {
            var user = new AppUser {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync (user, registerDto.Password);

            if (!result.Succeeded) return BadRequest (new ApiResponse (400));

            return new UserDto {
                DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
            };
        }
    }
}