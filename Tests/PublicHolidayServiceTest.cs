using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHolidaysServiceClass.Services;
using System.Net;

namespace PublicHolidaysServiceClass.Tests
{
    [TestClass]
    public class PublicHolidayServiceTest
    {
        #region GetPublicHolidays - Tests
        [TestMethod]
        public async Task Test_GetPublicHolidays_Success()
        {
            // Arrange
            int year = 2022;
            string countrycode = "DE";
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.GetPublicHolidaysAsync(year, countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetPublicHolidays_NotFound()
        {
            // Arrange
            int year = 2022;
            string countrycode = "DE-de"; // Wrong country code
            HttpStatusCode expectedStatusCode = HttpStatusCode.NotFound;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.GetPublicHolidaysAsync(year, countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetPublicHolidays_BadRequest()
        {
            // Arrange
            int year = 0; // Not working year
            string countrycode = "DE";
            HttpStatusCode expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.GetPublicHolidaysAsync(year, countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }
        #endregion

        #region GetUpcomingHolidays - Tests
        [TestMethod]
        public async Task Test_GetUpcomingHolidays_Success()
        {
            // Arrange
            string countrycode = "DE";
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.GetUpcomingHolidaysAsync(countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetUpcomingHolidays_NotFound()
        {
            // Arrange
            string countrycode = ""; // empty country code
            HttpStatusCode expectedStatusCode = HttpStatusCode.NotFound;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.GetUpcomingHolidaysAsync(countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetUpcomingHolidays_InternalServerError()
        {
            // Arrange
            string countrycode = "DE-de"; // wrong country code
            HttpStatusCode expectedStatusCode = HttpStatusCode.InternalServerError;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.GetUpcomingHolidaysAsync(countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }
        #endregion

        #region IsTodayAPublicHoliday - Tests
        [TestMethod]
        public async Task Test_IsTodayAPublicHoliday_SuccessfullButBlank()
        {
            // Arrange
            string countrycode = "DE";
            HttpStatusCode expectedStatusCode = HttpStatusCode.NoContent;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.IsTodayAPublicHolidayAsync(countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }

        [TestMethod]
        public async Task Test_IsTodayAPublicHoliday_NotFound()
        {
            // Arrange
            string countrycode = ""; // empty country code
            HttpStatusCode expectedStatusCode = HttpStatusCode.NotFound;

            // Act
            PublicHolidayService publicHolidayService = new();
            var result = await publicHolidayService.IsTodayAPublicHolidayAsync(countrycode);

            // Assert
            Assert.AreEqual(expectedStatusCode, result.StatusCode);
        }
        #endregion

        #region ReadContentAsJSON - Test
        [TestMethod]
        public async Task Test_ReadContentAsJSON_Success()
        {
            // Arrange
            int year = 2022;
            string countrycode = "DE";
            PublicHolidayService publicHolidayService = new();
            var response = await publicHolidayService.GetPublicHolidaysAsync(year, countrycode);
            string expectedString = await response.Content.ReadAsStringAsync();

            // Act
            var result = await publicHolidayService.ReadContentAsJSON(response);

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public async Task Test_ReadContentAsJSON_EmptyString()
        {
            // Arrange
            PublicHolidayService publicHolidayService = new();
            HttpResponseMessage response = new();
            string expectedString = "";

            // Act
            var result = await publicHolidayService.ReadContentAsJSON(response);

            // Assert
            Assert.AreEqual(expectedString, result);
        }
        #endregion
    }
}
