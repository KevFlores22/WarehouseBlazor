using System.Net.Http.Headers;
using System.Net.Http.Json;
using WarehouseBlazor.DTO;

namespace WarehouseBlazor.Services
{
    public class CategoriesService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public CategoriesService(HttpClient httpClient, AuthService authService)
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

        public async Task<List<CategoriesResponse>> GetCategories()
        {
            if (!await SetAuthorizationHeader())
                throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");

            try
            {
                return await _httpClient.GetFromJsonAsync<List<CategoriesResponse>>("api/categories") ?? new List<CategoriesResponse>();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener las categorías. Verifique la conexión a internet.");
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener las categorías.");
            }
        }

        public async Task<bool> CreateCategory(CategoriesRequest categoryRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/categories", categoryRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategory(int id, CategoriesRequest categoryRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", categoryRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/categories/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
