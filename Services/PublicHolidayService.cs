using System.Text.Json;
using PublicHolidaysServiceClass.Classes;
using PublicHolidaysServiceClass.Interface;

namespace PublicHolidaysServiceClass.Services
{
    /// <summary>
    /// This Class contain methods to get holidays from the NagerAPI
    /// </summary>
    public class PublicHolidayService : IPublicHolidayService
    {
        private readonly HttpClient _client;
        private const string BasicURL = "https://date.nager.at/api/v3/";

        public PublicHolidayService() => _client = new HttpClient();

        public async Task<HttpResponseMessage> GetPublicHolidaysAsync(int year, string countryCode)
        {
            string url = $"{BasicURL}PublicHolidays/{year}/{countryCode}";
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> GetUpcomingHolidaysAsync(string countryCode)
        {
            string url = $"{BasicURL}NextPublicHolidays/{countryCode}";
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> IsTodayAPublicHolidayAsync(string countryCode)
        {
            string url = $"{BasicURL}IsTodayPublicHoliday/{countryCode}";
            return await _client.GetAsync(url);
        }

        public PublicHoliday[]? FilterByDaysOff(string JSONString, string countryCode)
        {
            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<PublicHoliday[]>(JSONString, jsonSerializerOptions);
        }

        public async Task<string> ReadContentAsJSON(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }
    }
}