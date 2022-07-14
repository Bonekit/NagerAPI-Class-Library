using PublicHolidaysServiceClass.Interface;

namespace PublicHolidaysServiceClass.Services
{
    /// <summary>
    /// TODO: Write a documentation for the class
    /// </summary>
    public class PublicHolidayService : IPublicHolidayService
    {
        private readonly HttpClient _client;
        private const string BasicURL = "https://date.nager.at/api/v3/";

        /// <summary>
        /// Constructor
        /// </summary>
        public PublicHolidayService()
        {
            _client = new HttpClient();
        }

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

        public async Task<string> ReadContentAsJSON(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }
    }
}