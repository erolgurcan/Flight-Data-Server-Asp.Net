using flight_data_server.Models.User;

namespace flight_data_server.Interface
    {
    public interface IUserRepository
        {
        bool IsUniqueUser(string username);

        Task<LoginResponse> Login(LoginRequest loginRequest);

        Task<User> Register(RegisterRequest registerRequest);
        }
    }
