using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var op = new ChromeOptions();//创建浏览器


            ChromeDriver driver = new ChromeDriver(@"E:\Google\Chrome\Application\".ToString(), op);


            driver.Navigate().GoToUrl("https://fr.tlscontact.cn/cn/bjs/register.php");//打开百度
                                                                                      //截图保存
                                                                                      //Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                                                                                      //screenshot.SaveAsFile(@"C:\Users\Public\Desktop\baidu.jpg", ScreenshotImageFormat.Jpeg);
                                                                                      ////退出

            //driver.FindElement(By.Id("u_email")).SendKeys("727821378@qq.com");
            //System.Threading.Thread.Sleep(1 * 1000);
            //driver.FindElement(By.Id("u_email_confirm")).SendKeys("781221378@qq.com");
            //System.Threading.Thread.Sleep(1 * 1000);

            //driver.FindElement(By.Id("u_password")).SendKeys("qweQWE123!@#");
            //System.Threading.Thread.Sleep(1 * 1000);

            //driver.FindElement(By.Id("u_password_confirm")).SendKeys("qweQWE123!@#");
            //System.Threading.Thread.Sleep(1 * 1000);

            //var checkbox = driver.FindElementByXPath("//*[@type='checkbox']");
            //System.Threading.Thread.Sleep(1 * 500);

            //checkbox.Click();
            ////var Element = driver.FindElementsByClassName() ;
            ////Element.Click();
            //System.Threading.Thread.Sleep(1 * 500);
            //driver.FindElement(By.Id("create_user")).Click();

            //screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            //screenshot.SaveAsFile(@"C:\Users\Public\Desktop\baidu.jpg", ScreenshotImageFormat.Jpeg);
            //string sdasd = driver.Title;
            //登录
            {
                driver.Navigate().GoToUrl("https://www.evisa.gov.et/client/requests/create");
                driver.FindElement(By.Id("VisaTypeId")).SendKeys("1");
                System.Threading.Thread.Sleep(1 * 1000);
                driver.FindElement(By.Id("CitizenshipId")).SendKeys("762");
                System.Threading.Thread.Sleep(1 * 1000);

                driver.FindElement(By.ClassName("recaptcha-checkbox-border")).Click();

                //var checkbox = driver.FindElementByXPath("//*[@value=\"Log in\"]");
                //checkbox.Click();

            }
            driver.Quit();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
