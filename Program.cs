using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(@"https://pokemon-arena.co.il/");
            Console.WriteLine(driver.Url);
            //Login
            IWebElement _username = driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement _password = driver.FindElement(By.CssSelector("input[name='password']"));
            _username.SendKeys("YossiBz");
            _password.SendKeys("123456");
            driver.FindElement(By.CssSelector("input[name='login']")).Click();

            //Home Page
            Actions action = new Actions(driver);
            IWebElement _actions = driver.FindElement(By.CssSelector(".pokeicon.i-swords"));
            action.MoveToElement(_actions).Build().Perform();
            driver.FindElement(By.CssSelector("li.pokeicon.i-swords>ul>li>a")).Click();

            //Attack_Map
            driver.FindElement(By.CssSelector("input[alt='Grass field']")).Click();
            string _pokemonName = driver.FindElement(By.Id("pokemon_naam")).Text;
            IWebElement computer_life = driver.FindElement(By.Id("computer_life"));
            IWebElement pokemon_life = driver.FindElement(By.Id("pokemon_life"));
            if (_pokemonName.IndexOf("Dratini") != -1 || _pokemonName.IndexOf("Gengar") != -1)
            {
                while (computer_life.GetCssValue("width") != "0px" && pokemon_life.GetCssValue("width") != "px")
                {
                    driver.FindElement(By.ClassName("attacko2")).Click();
                }
            }
            else if (_pokemonName.IndexOf("Charizard") != -1)
            {
                while (computer_life.GetCssValue("width") != "0px" && pokemon_life.GetCssValue("width") != "px")
                {
                    driver.FindElement(By.ClassName("attacko1")).Click();
                }
            }
            else if (_pokemonName.IndexOf("Poliwhirl") != -1 || _pokemonName.IndexOf("Horsea") != -1)
            {
                while (computer_life.GetCssValue("width") != "0px" && pokemon_life.GetCssValue("width") != "px")
                {
                    driver.FindElement(By.ClassName("attacko4")).Click();
                }
            }

            // driver.Quit();
        }
    }
}
