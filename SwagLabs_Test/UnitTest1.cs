using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LamHuynhHoaNam_22DH112245_TestScript
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://thegioijack.vercel.app/sign-in");
        }

        [Test]
        public void DangNhap()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys("nam27@gmail.com");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys("123456");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/button[1]/span[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/button[1]")).Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void DangNhapTaiKhoanMoi()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys("namnam@gmail.com");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys("123456");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/button[1]/span[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/button[1]")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void TSPVGH01_ThemSanPhamKhiChuaDangNhap()
        {
            driver.FindElement(By.XPath("//img[@alt='image-logo']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/button[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            string currentUrl = driver.Url;
            Console.WriteLine($"URL hiện tại: {currentUrl}");

            string expectedUrl = "https://thegioijack.vercel.app/sign-in";

            string result = (currentUrl == expectedUrl) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet1", currentUrl, result);
            Assert.That(currentUrl, Is.EqualTo(expectedUrl), $"Trang không chuyển hướng đúng, URL hiện tại: {currentUrl}");
        }


        [Test]
        public void TSPVGH02_ThemSanPhamKhiDangNhap()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.Id("cart-notification"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Đã thêm vào giỏ hàng";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet1", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }

        [Test]
        public void TSPVGH03_SoluongSanPhamToiDa()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            IWebElement increaseButton = driver.FindElement(By.Id("increase-quantity"));
            Thread.Sleep(10000);
            for (int i = 0; i < 5; i++)
            {
                increaseButton.Click(); 
                Thread.Sleep(200);
            }

            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.Id("cart-notification"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Thêm sản phẩm vào giỏ hàng thành công";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet1", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");

        }

        [Test]
        public void TSPVGH04_SoluongSanPhamLonHon5()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            IWebElement increaseButton = driver.FindElement(By.Id("increase-quantity"));
            for (int i = 0; i < 5; i++)
            {
                increaseButton.Click();
                Thread.Sleep(200);
            }
            Thread.Sleep(2000);
            IWebElement announcement = driver.FindElement(By.Id("announ-products"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Sản phẩm chỉ mua tối đa số lượng 5";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet1", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");

        }

        [Test]
        public void TSPVGH05_SoLuongGioHang()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            IWebElement increaseButton = driver.FindElement(By.Id("increase-quantity"));
            for (int i = 0; i < 5; i++)
            {
                increaseButton.Click();
                Thread.Sleep(200);
            }
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            IWebElement increaseButton2 = driver.FindElement(By.Id("increase-quantity"));
            for (int i = 0; i < 5; i++)
            {
                increaseButton2.Click();
                Thread.Sleep(200);
            }
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(2000);

            IWebElement announcement = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[1]/div[1]/span[2]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Sản phẩm chỉ mua tối đa số lượng 5, giỏ hàng của bạn đang có 5";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }

        [Test]
        public void TSPVGH06_MuaSanPhamNhungSanPhamHetHang()
        {
            DangNhap();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[2]/div[2]/div[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.Id("out-of-stock"));
            string actualMessage = announcement.Text;
            string expectedMessage = "Sản phẩm hết hàng";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet1", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }
        [Test]
        public void GH_BoTrongTenTrongGH()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[2]")).Click();
            Thread.Sleep(1000);
            //Tick
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/label[1]/span[1]/input[1]")).Click();
            Thread.Sleep(1000);
            //Thay đổi
            driver.FindElement(By.Id("change-button")).Click();
            Thread.Sleep(1000);
            var nameInput = driver.FindElement(By.Id("basic_name"));
            nameInput.SendKeys(Keys.Control + "a");
            nameInput.SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//span[normalize-space()='OK']")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//div[@class='ant-form-item-explain-error']"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Vui lòng nhập tên !";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }
        [Test]
        public void GH_BoTrongDiaChiTrongGH()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[2]")).Click();
            Thread.Sleep(1000);
            //Tick
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/label[1]/span[1]/input[1]")).Click();
            Thread.Sleep(1000);
            //Thay đổi
            driver.FindElement(By.Id("change-button")).Click();
            Thread.Sleep(1000);
            var addressInput = driver.FindElement(By.Id("basic_address"));
            addressInput.SendKeys(Keys.Control + "a");
            addressInput.SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//span[normalize-space()='OK']")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//div[@class='ant-form-item-explain-error']"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Vui lòng nhập địa chỉ !";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }
        [Test]
        public void GH_TenDiaChiTaoLao()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[2]")).Click();
            Thread.Sleep(1000);
            //Tick
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/label[1]/span[1]/input[1]")).Click();
            Thread.Sleep(1000);
            //Thay đổi
            driver.FindElement(By.Id("change-button")).Click();
            Thread.Sleep(1000);
            var addressInput = driver.FindElement(By.Id("basic_address"));
            addressInput.SendKeys(Keys.Control + "a"); 
            addressInput.SendKeys(Keys.Backspace); 
            addressInput.SendKeys("ABCDCCCDDDD");
            driver.FindElement(By.XPath("//span[normalize-space()='OK']")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//span[contains(text(),'Cập nhật thành công!')]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Vui lòng nhập địa chỉ!";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }


        [Test]
        public void GH_XoaSanPhamRaKhoiGioHang()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            //Xóa
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/button[1]")).Click();
            Thread.Sleep(1000);
            //OK
            driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/button[2]/span[1]")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[1]/div[1]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Xóa thành công";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }

        [Test]
        public void GH_XoaNhieuSanPhamRaKhoiGioHang()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //Trang chủ
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/a[1]/span[1]")).Click();
            Thread.Sleep(2000);
            //Tắt QC
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/button[1]")).Click();
            Thread.Sleep(2000);
            //SP khác
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[7]/div[1]/img[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            //Tick
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/span[1]/label[1]/span[1]/input[1]")).Click();
            Thread.Sleep(1000);
            //Xóa
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/span[4]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            //OK
            driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/button[2]/span[1]")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("/html[1]/body[1]/div[4]/div[1]/div[1]/div[1]/div[1]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Xóa sản phẩm thành công!";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }



        [Test]
        public void GH_DangXuatConTonTaiSPTrongGHKhong()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[1]/p[3]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/img[1]")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/sup[1]/bdi[1]/span[1]/span[1]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Không tồn tại sản phẩm trong giỏ hàng";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");

        }
        [Test]
        public void GH_KiemTraThongBaoXoaSP()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/button[1]")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.ClassName("ant-modal-confirm-title"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Xác nhận xóa sản phẩm";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");

        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Dispose();
        }
    }
}