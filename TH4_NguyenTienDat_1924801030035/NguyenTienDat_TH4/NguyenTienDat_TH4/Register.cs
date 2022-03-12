using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace NguyenTienDat_TH4
{
    [TestFixture]
    public class CreateTest
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver ();
            baseURL = "http://automationpractice.com";
        }
        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }
        [Test]
         public void TCLogin01()
         {
             driver.Navigate().GoToUrl(baseURL + "/index.php");
             driver.FindElement(By.LinkText("Sign in")).Click();
             driver.FindElement(By.Id("email")).Click();
             driver.FindElement(By.Id("email")).Clear();
             driver.FindElement(By.Id("email")).SendKeys("nguyentiendat3092000@gmail.com");
             driver.FindElement(By.Id("passwd")).Click();
             driver.FindElement(By.Id("passwd")).Clear();
             driver.FindElement(By.Id("passwd")).SendKeys("0916147280");
             driver.FindElement(By.Id("SubmitLogin")).Click();
             Assert.AreEqual("Đạt Nguyễn",driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a/span")).Text);
             driver.FindElement(By.LinkText("Sign out")).Click();
         }
        //Không nhập email
        [Test]
         public void TC_Register_01()
         {
             driver.Navigate().GoToUrl(baseURL + "/index.php");
             driver.FindElement(By.LinkText("Sign in")).Click();
             driver.FindElement(By.Id("SubmitCreate")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
             Assert.AreEqual("Invalid email address.", driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li")).Text);
         }
        //Email đã đăng kí
         [Test]
         public void TC_Register_02()
         {
             driver.Navigate().GoToUrl(baseURL + "/index.php");
             driver.FindElement(By.LinkText("Sign in")).Click();
             driver.FindElement(By.Id("email_create")).SendKeys("nguyentiendat3092000@gmail.com");
             driver.FindElement(By.Id("SubmitCreate")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
             Assert.AreEqual("An account using this email address has already been registered. Please enter a valid password or request a new one.", driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li")).Text);
         }
        //Không nhập First Name
         [Test]
         public void TC_Register_03()
         {
             driver.Navigate().GoToUrl(baseURL + "/index.php");
             driver.FindElement(By.LinkText("Sign in")).Click();
             driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
             driver.FindElement(By.Id("SubmitCreate")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
             driver.FindElement(By.Id("id_gender1")).Click();
             driver.FindElement(By.Id("customer_firstname")).SendKeys("");
             driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
             driver.FindElement(By.Id("passwd")).SendKeys("0916147280");
             driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
             driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
             driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
             driver.FindElement(By.Id("company")).SendKeys("N/A");
             driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
             driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
             driver.FindElement(By.Id("city")).SendKeys("TDM");
             driver.FindElement(By.Id("id_state")).SendKeys("Washington");
             driver.FindElement(By.Id("postcode")).SendKeys("52341");
             driver.FindElement(By.Id("id_country")).SendKeys("United States");
             driver.FindElement(By.Id("other")).SendKeys("N/A");
             driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
             driver.FindElement(By.Id("alias")).Clear();
             driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
             Assert.AreEqual("firstname is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập Last Name
         [Test]
         public void TC_Register_04()
         {
             driver.Navigate().GoToUrl(baseURL + "/index.php");
             driver.FindElement(By.LinkText("Sign in")).Click();
             driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
             driver.FindElement(By.Id("SubmitCreate")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
             driver.FindElement(By.Id("id_gender1")).Click();
             driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
             driver.FindElement(By.Id("customer_lastname")).SendKeys("");
             driver.FindElement(By.Id("passwd")).SendKeys("20916147280");
             driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
             driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
             driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
             driver.FindElement(By.Id("company")).SendKeys("N/A");
             driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
             driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
             driver.FindElement(By.Id("city")).SendKeys("TDM");
             driver.FindElement(By.Id("id_state")).SendKeys("Washington");
             driver.FindElement(By.Id("postcode")).SendKeys("52341");
             driver.FindElement(By.Id("id_country")).SendKeys("United States");
             driver.FindElement(By.Id("other")).SendKeys("N/A");
             driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
             driver.FindElement(By.Id("alias")).Clear();
             driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
             driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
             Assert.AreEqual("lastname is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập Password
       [Test]
        public void TC_Register_05()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("passwd is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Password nhỏ hơn 5 ký tự
        [Test]
        public void TC_Register_06()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0916");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("passwd is invalid.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập address
        [Test]
        public void TC_Register_07()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0916147280");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("");
            driver.FindElement(By.Id("address2")).SendKeys("");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("address1 is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập City
        [Test]
        public void TC_Register_08()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0916147280");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0869302204");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("city is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không chọn State
        [Test]
        public void TC_Regiter_09()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0911647280");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("-");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("This country requires you to choose a State.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập ZipCode
        [Test]
        public void TC_Register_10()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0911647280");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập Country
        [Test]
        public void TC_Register_11()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0911647280");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("-");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0916147280");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("id_country is required.Country cannot be loaded with address->id_countryCountry is invalid", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        //Không nhập Phone Number
        [Test]
        public void TC_Register_12()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("tiendat30092000@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Đạt");
            driver.FindElement(By.Id("passwd")).SendKeys("0911647280");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("address2")).SendKeys("Phú Mỹ");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Washington");
            driver.FindElement(By.Id("postcode")).SendKeys("52341");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Bình Dương");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            Assert.AreEqual("You must register at least one phone number.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
    }
}
public class Register
   {

   }
