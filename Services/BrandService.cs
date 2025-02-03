using System.Net.Http.Headers;
using System.Net.Http.Json;
using WarehouseBlazor.DTO;

namespace WarehouseBlazor.Services
{
    public class BrandService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public BrandService(HttpClient httpClient, AuthService authService)
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

        public async Task<List<BrandResponse>> GetBrands()
        {
            if (!await SetAuthorizationHeader())
                throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");

            try
            {
                return await _httpClient.GetFromJsonAsync<List<BrandResponse>>("api/brands") ?? new List<BrandResponse>();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener las marcas. Verifique la conexión a internet.");
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener las marcas.");
            }
        }

        public async Task<bool> CreateBrand(BrandRequest brandRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/brands", brandRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateBrand(int id, BrandRequest brandRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/brands/{id}", brandRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBrand(int id)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/brands/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
