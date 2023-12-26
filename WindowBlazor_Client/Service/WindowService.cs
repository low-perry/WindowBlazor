using WindowBlazor_Client.Service.IService;
using WindowBlazor_Models;
using Newtonsoft.Json;

namespace WindowBlazor_Client.Service
{
    public class WindowService : IWindowService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
        public WindowService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseServerUrl = _configuration.GetValue<string>("BaseServerUrl");
        }
        public async Task<WindowDTO> Get(int windowId)
        {
            var response = await _httpClient.GetAsync($"/api/window/{windowId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var window = JsonConvert.DeserializeObject<WindowDTO>(content);
                
                return window;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<WindowDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/window");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var windows = JsonConvert.DeserializeObject<IEnumerable<WindowDTO>>(content);
               return windows;
            }

            return new List<WindowDTO>();
        }
    }
}
