using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SessiaBlazor.Model;

namespace SessiaBlazor.Services
{
    public class AuthApiService
    {
        private readonly HttpClient _httpClient;
        public AuthApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user", new
            {
                userName = request.UserName,
                passwordHash = request.Password, // Для MVP просто передаём пароль
                roleId = request.RoleId
            });
            return response.IsSuccessStatusCode;
        }

        public async Task<Model.User> LoginAsync(LoginRequest request)
        {
            // MVP: просто ищем пользователя по имени и паролю (пароль не хэшируется)
            var users = await _httpClient.GetFromJsonAsync<Model.User[]>("api/user");
            return users?.FirstOrDefault(u => u.UserName == request.UserName && u.PasswordHash == request.Password);
        }
    }
} 