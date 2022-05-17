using System;
using System.Linq;
using System.Threading;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace ImageDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);

            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http:")
        }
    }
}
