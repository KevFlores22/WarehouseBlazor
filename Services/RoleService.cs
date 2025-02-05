using System.Net.Http.Headers;
using System.Net.Http.Json;
using WarehouseBlazor.DTO;

namespace WarehouseBlazor.Services
{
    public class RoleService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public RoleService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        private async Task<bool> SetAuthorizationHeader()
        {
            var token = await _authService.GetToken();
            if (string.IsNullOrEmpty(token))
                return false;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return true;
        }

        public async Task<List<RoleResponse>> GetRoles()
        {
            if (!await SetAuthorizationHeader())
                throw new InvalidOperationException("Token inválido. Debe iniciar sesión.");

            try
            {
                return await _httpClient.GetFromJsonAsync<List<RoleResponse>>("api/roles")
                    ?? new List<RoleResponse>();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error de conexión. Verifique su internet.");
            }
            catch
            {
                throw new Exception("Error al obtener los roles.");
            }
        }

        public async Task<bool> CreateRole(RoleRequest roleRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/roles", roleRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateRole(int roleId, RoleRequest roleRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/roles/{roleId}", roleRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/roles/{roleId}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}