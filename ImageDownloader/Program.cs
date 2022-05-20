using System;
using System.Linq;
using System.Threading;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;



namespace ImageDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(100);

            File.Delete(@"C:\Users\Carter\source\repos\ImageDownloader\ImageDownloader\bin\Debug\chromedriver.exe");
            ZipFile.ExtractToDirectory(@"C:\Users\Carter\source\repos\ImageDownloader\ImageDownloader\bin\Debug\chromedriver_win32.zip", @"C:\Users\Carter\source\repos\ImageDownloader\ImageDownloader\bin\Debug");

            var driver = new ChromeDriver();

            for (int k = 1; k < 100; k++)
            { 
                string LandingUrl = "https://www.jpxgyw.vip/plus/search/index.asp?keyword=%E8%8A%9D%E8%8A%9Dbooty&searchtype=title&p=" + k;
                driver.Navigate().GoToUrl(LandingUrl);

                Thread.Sleep(200);

                var Project = driver.FindElements(By.TagName("b"));

                Console.WriteLine();

                for (int i = 0; i < Project.Count(); i++)
                {
                    Project = driver.FindElements(By.TagName("b"));
                    Project[i].Click();
                    Thread.Sleep(200);
                    var y = 1;

                    string Name = driver.Title;
                    Name = Name.Remove(Name.Length - 7, 7);
                    var newDirectory = Directory.CreateDirectory(@"E:\\Image Downloaded\\" + Name);

                    var Pages = driver.FindElement(By.XPath("//div[@class='pagination']")).FindElement(By.TagName("ul")).FindElements(By.TagName("a"));

                    Console.WriteLine("pages=" + Pages.Count());

                    var Images = driver.FindElement(By.XPath("//p[@style='text-align: center']")).FindElements(By.TagName("img"));

                    for (int x = 0; x < Images.Count(); x++)
                    {
                        var ImageUrl = Images[x].GetAttribute("src");

                        WebClient Downloader = new WebClient();
                        Downloader.DownloadFile(ImageUrl, newDirectory.FullName + "\\" + y + ".jpg");
                        y++;
                    }
                    driver.FindElement(By.XPath("//*[contains(text(),'下一页')]")).Click();

                    for (int j = 0; j < Pages.Count() - 2; j++)
                    {
                        Images = driver.FindElement(By.XPath("//p[@align='center']")).FindElements(By.TagName("img"));

                        for (int x = 0; x < Images.Count(); x++)
                        {
                            var ImageUrl = Images[x].GetAttribute("src");

                            WebClient Downloader = new WebClient();
                            Downloader.DownloadFile(ImageUrl, newDirectory.FullName + "\\" + y + ".jpg");
                            y++;
                        }
                        if (j != Pages.Count() - 3)
                            driver.FindElement(By.XPath("//*[contains(text(),'下一页')]")).Click();
                    }

                    Thread.Sleep(100);


                    for (int j = 0; j < Pages.Count() - 1; j++)
                        driver.Navigate().Back();

                }

            }
        }
    }
}
