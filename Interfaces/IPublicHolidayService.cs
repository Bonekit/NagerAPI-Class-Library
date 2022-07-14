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
    }
}
