using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;


using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using Microsoft.Extensions.Options;
using broker.Data;
using broker.Models;
using broker.Helpers;
using broker.Entity;
using broker.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Hosting.Internal;

namespace Controllers
{

    // [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        [Obsolete]
        private static IHostingEnvironment _environment;

        private List<User> registeredUsers;
        private readonly AppSettings _appSettings;

        // public static IHostingEnvironment Environment { get => _environment; set => _environment = value; }

        public UserController(IRepository<User> repo, IMapper mapper, IOptions<AppSettings> appSettings, IHostingEnvironment environment)
        {
            _userRepository = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _environment = environment;



        }

        private async void getUsers()
        {
            List<User> users = await _userRepository.GetData();
            this.registeredUsers = users;
            Console.WriteLine("This is the GetUsers method and this the registered users", this.registeredUsers);
        }



        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            // var user = _userService.Authenticate(model.Username, model.Password);

            // if (user == null)
            //     return BadRequest(new { message = "Username or password is incorrect" });

            // return Ok(user);

            // 
            // getUsers();
            Console.WriteLine("Authentication Method");
            List<User> users = await _userRepository.GetData();
            var user = users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            // return null if user not found
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // user.Token = tokenHandler.WriteToken(token);
            UserEntity userEntity = new UserEntity();
            userEntity.user = user;
            userEntity.Token = tokenHandler.WriteToken(token);
            return Ok(userEntity);
        }
        // [Authorize(Roles = "Customer")]
        // [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Customer")]
        //    [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var model = await _userRepository.GetData();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(model));
        }

        // [HttpGet("email")]
        // public async Task<IActionResult> GetUserById(int id)
        // {
        //     Console.WriteLine("Returning job of id" + id);
        //     var model = await _userRepository.GetDataById(id);
        //     return Ok(_mapper.Map<UserDto>(model));
        // }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(int id)
        {
            Console.WriteLine("Returning job of id" + id);
            var model = await _userRepository.GetDataById(id);
            return Ok(_mapper.Map<UserDto>(model));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            // Console.WriteLine("Creating Users");
            // var user = _mapper.Map<User>(userDto);
            //  Console.WriteLine("Entered to the image upload");

            // string fName = userDto.Picture.FileName;
            // Console.WriteLine(fName);
            // string path = Path.Combine(_environment.ContentRootPath, "Images/" + userDto.Picture.FileName);
            // using (var stream = new FileStream(path, FileMode.Create))
            // { 
            //     await userDto.Picture.CopyToAsync(stream);
            // }
            // // return file.FileName;
            // user.Picture=userDto.Picture.FileName;
            // await _userRepository.UpdateData(user);
            return Ok(userDto);
        }
        //   [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            Console.WriteLine("DELETE USER");
            var model = await _userRepository.GetDataById(id);
            var user = _mapper.Map<User>(model);
            await _userRepository.DeleteData(user);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto user)
        {
            Console.WriteLine(user.FullName);
            var userModel = _mapper.Map<User>(user);
            await _userRepository.UpdateData(userModel);
            return Ok(userModel);
        }
        [HttpPost("uploadfileg")]
        public async Task<string> UploadFile([FromForm] IFormFile file)
        {
            Console.WriteLine("Entered tot he image upload");

            string fName = file.FileName;
            Console.WriteLine(fName);
            string path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/" + file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            { 
                await file.CopyToAsync(stream);
            }
            
            return file.FileName;
        }
        [HttpGet("getimage")]
public IActionResult Get(string name)
{
    var image = System.IO.File.OpenRead(name);
    return File(image, "image/jpeg");
}
    }

}