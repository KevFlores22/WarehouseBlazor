using WarehouseBlazor.DTO;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WarehouseBlazor.Services
{
    public class MeasurementUnitService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public MeasurementUnitService(HttpClient httpClient, AuthService authService)
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

        public async Task<List<MeasurementUnitResponse>> GetMeasurementUnits()
        {
            if (!await SetAuthorizationHeader())
                throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");

            try
            {
                return await _httpClient.GetFromJsonAsync<List<MeasurementUnitResponse>>("api/measurementUnits") ?? new List<MeasurementUnitResponse>();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error al obtener las unidades de medida. Verifique la conexión a internet.");
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al obtener las unidades de medida.");
            }
        }

        public async Task<bool> CreateMeasurementUnit(MeasurementUnitRequest measurementUnitRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/measurementUnits", measurementUnitRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateMeasurementUnit(int id, MeasurementUnitRequest measurementUnitRequest)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/measurementUnits/{id}", measurementUnitRequest);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteMeasurementUnit(int id)
        {
            if (!await SetAuthorizationHeader())
                return false;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/measurementUnits/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}