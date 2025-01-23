using WarehouseBlazor.DTO;
using System.Net.Http.Headers;
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

        public async Task<List<CategoriesResponse>> GetCategories()
        {

            try
            {
                var token = await _authService.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o invalido. Iniciar Sesión");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<CategoriesResponse>>("api/categories");

                return response;

            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener las categorias. Revisar conexión a internet.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al obtener las categorias.");
            }
        }
    }
}

