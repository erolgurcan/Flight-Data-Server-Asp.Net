using flight_data_server.Database;
using flight_data_server.Interface;
using flight_data_server.Models.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;


namespace flight_data_server.Services.UserFunctions
    {
    public class UserRepository : IUserRepository
        {
        private readonly AirlinerDBContext _db;
        private readonly string _secretKey;

        public UserRepository(AirlinerDBContext db, IConfiguration configuration)
            {
            this._db = db;
            this._secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            }

        public bool IsUniqueUser(string username)
            {
            try
                {
                var user = _db.User.FirstOrDefault(u => u.UserName == username);

                return user == null ? true : false;
                }
            catch (Exception)
                {
                throw new NotImplementedException();
                }
            }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
            {
            var user = _db.User.FirstOrDefault(
                u =>
                    u.UserName.ToLower() == loginRequest.UserName.ToLower()
                    && u.Password == loginRequest.Password
            );

            if (user == null)
                {
                return new LoginResponse()
                    {
                    Token = "",
                    User = null
                    };
                }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDesciptor = new SecurityTokenDescriptor
                {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, user.UserId.ToString()),
                                   new Claim(ClaimTypes.Role, user.Role.ToString())
                    })
                ,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

            var token = tokenHandler.CreateToken(tokenDesciptor);

            LoginResponse loginResponse = new()
                {
                Token = tokenHandler.WriteToken(token),
                User = user
                };
            return loginResponse;
            }



        public async Task<User> Register(RegisterRequest registerRequest)
            {
            try
                {
                User user = new User()
                    {
                    UserName = registerRequest.UserName,
                    Password = registerRequest.Password,
                    Role = registerRequest.Role
                    };

                _db.User.Add(user);
                _db.SaveChangesAsync();

                user.Password = "";

                return user;
                }
            catch (Exception)
                {
                throw new NotImplementedException();
                }
            }
        }
    }
