using PublicHolidaysServiceClass.Classes;

namespace PublicHolidaysServiceClass.Interface
{
    /// <summary>
    /// <c>IPublicHolidayService</c> - Interface
    /// </summary>
    public interface IPublicHolidayService
    {
        /// <summary>
        /// Send a request to get the public holidays for the year and country
        /// </summary>
        /// <param name="year">integer</param>
        /// <param name="countryCode">string</param>
        /// <returns>A <see cref="HttpResponseMessage"/> object</returns>
        public Task<HttpResponseMessage> GetPublicHolidaysAsync(int year, string countryCode);

        /// <summary>
        /// Check if today is a public holiday in my country
        /// </summary>
        /// <param name="countryCode">string</param>
        /// <returns>A <see cref="HttpResponseMessage"/> object</returns>
        public Task<HttpResponseMessage> IsTodayAPublicHolidayAsync(string countryCode);

        /// <summary>
        /// Get upcoming holidays from now one until current year ends.
        /// </summary>
        /// <param name="countryCode">string</param>
        /// <returns>A <see cref="HttpResponseMessage"/> object</returns>
        public Task<HttpResponseMessage> GetUpcomingHolidaysAsync(string countryCode);

        /// <summary>
        /// Read the content from the response message object as JSON-String
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>A JSON formatted <see cref="string"/> </returns>
        public Task<string> ReadContentAsJSON(HttpResponseMessage response);

        /// <summary>
        /// Filter by days off from the public holidays JSON string.
        /// <para>
        /// The country code is needed to filter more specificly
        /// </para>
        /// </summary>
        /// <param name="JSONString">string</param>
        /// <returns><see cref="PublicHoliday"/> object filled in an array</returns>
        public PublicHoliday[]? FilterByDaysOff(string JSONString, string countryCode);
    }
}
