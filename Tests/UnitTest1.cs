using FluentAssertions;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using SplitIt.Pages;
using SplitIt.Tests;

namespace SplitIt.Tests
{
    public class Test : BaseTest
    {
        [Test, Timeout(TIMEOUT_PERIOD)]
        public void initialTest()
        {
            // Go to https://pos.sandbox.splitit.com/
            driver.Navigate().GoToUrl(pageUrl);

            // Press on ‘New Transaction’ button
            Homepage homepage = new Homepage(driver);
            homepage.newTransaction();

            // Login
            LoginPage loginPage = new LoginPage(driver);
            loginPage.login("qa@splitit.com", "A1qazxsw23434!");
            
            // Extract access_token
            var endpoint = "https://reqres.in/api/users";
            var client = new RestClient(endpoint);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = client.Execute(request);

            //Verify
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
} 