using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string apiKey = "a9e6b2c2d939474c8e859219c7437b92";
    private const string name = "Ocp-Apim-Subscription-Key";

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add(name, apiKey);
    }

    public async Task<string> FetchDataFromApiAsync(string url)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            return ex.Message;
        }
    }
}
