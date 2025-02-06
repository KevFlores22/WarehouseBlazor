using WarehouseBlazor.DTO;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WarehouseBlazor.Services
{
    public class StatusService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public StatusService(HttpClient httpClient, AuthService authService)
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

        public async Task<List<StatusResponse>> GetStatuses()
        {
            if (!await SetAuthorizationHeader())
                throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");

            try
            {
                return await _httpClient.GetFromJsonAsync<List<StatusResponse>>("api/statuses") ?? new List<StatusResponse>();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener los estados. Verifique la conexión a internet.");
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener los estados.");
            }
        }

        public async Task<bool> CreateStatus(StatusRequest statusRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/statuses", statusRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatus(int id, StatusRequest statusRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/statuses/{id}", statusRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteStatus(int id)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/statuses/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}