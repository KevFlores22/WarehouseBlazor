using System.Net.Http.Headers;
using System.Net.Http.Json;
using WarehouseBlazor.DTO;

namespace WarehouseBlazor.Services
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ArticleService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<ArticleResponse>> GetArticles()
        {
            try
            {
                var token = await _authService.GetToken();
                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("El token es nulo o inválido. Iniciar sesión.");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<ArticleResponse>>("api/articles");

                return response ?? new List<ArticleResponse>();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener artículos. Verifica la conexión a internet.");
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener artículos.");
            }
        }

        public async Task<bool> AddArticle(ArticleRequest article)
        {
            try
            {
                var token = await _authService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PostAsJsonAsync("api/articles", article);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar el artículo.");
            }
        }

        public async Task<bool> UpdateArticle(int id, ArticleRequest article)
        {
            try
            {
                var token = await _authService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PutAsJsonAsync($"api/articles/{id}", article);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw new Exception("Error al actualizar el artículo.");
            }
        }

        public async Task<bool> DeleteArticle(int id)
        {
            try
            {
                var token = await _authService.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.DeleteAsync($"api/articles/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar el artículo.");
            }
        }
    }
}
