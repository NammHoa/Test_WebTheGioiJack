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
        public void GH_BoTrongSoDienThoaiTrongGH()
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
            var phoneInput = driver.FindElement(By.Id("basic_phone"));
            phoneInput.SendKeys(Keys.Control + "a");
            phoneInput.SendKeys(Keys.Backspace);
            driver.FindElement(By.XPath("//span[normalize-space()='OK']")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//div[@class='ant-form-item-explain-error']"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Vui lòng nhập số điện thoại !";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }

        [Test]
        public void GH_SoDienThoaiBangChuTrongGH()
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
            var phoneInput = driver.FindElement(By.Id("basic_phone"));
            phoneInput.SendKeys(Keys.Control + "a");
            phoneInput.SendKeys(Keys.Backspace);
            phoneInput.SendKeys("một hai ba");
            driver.FindElement(By.XPath("//span[normalize-space()='OK']")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//div[@class='ant-form-item-explain-error']"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Vui lòng nhập số !";
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
        public void GH_BoTrongGioHang()
        {
            DangNhap();    
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);

            string currentUrl = driver.Url;
            Console.WriteLine($"URL hiện tại: {currentUrl}");

            string expected = "Giỏ hàng trống";

            string result = (currentUrl == expected) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet3", currentUrl, result);
            Assert.That(currentUrl, Is.EqualTo(expected), $"Trang không chuyển hướng đúng, URL hiện tại: {currentUrl}");
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
        public void GH_KiemTraGioHangKhiDangXuat()
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
            string expectedMessage = "Giỏ hàng bị xóa sau khi đăng xuất";
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
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            //TB
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
        [Test]
        public void GH_DatHangKhiGioHangTrong()
        {
            DangNhap();
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/button[1]/span[1]")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//span[contains(text(),'Vui lòng chọn sản phẩm')]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Vui lòng chọn sản phẩm";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }
        [Test]
        public void GH_SPKhiCoGangBamDauTru()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("//span[@aria-label='minus']//*[name()='svg']")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//span[@class='ant-modal-confirm-title']"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Xác nhận xóa sản phẩm";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }

        [Test]
        public void TT_ThanhToanTienMat()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);
            //tick
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/span[1]/label[1]/span[1]/input[1]")).Click();
            Thread.Sleep(1000);
            //Mua
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/button[1]/span[1]")).Click();
            Thread.Sleep(1000);
            //Dat hang
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/button[1]/span[1]")).Click();
            Thread.Sleep(1000);
            IWebElement announcement = driver.FindElement(By.XPath("//span[contains(text(),'Đặt hàng thành công')]"));
            string actualMessage = announcement.Text;
            Console.WriteLine($"Thông báo lấy được: {actualMessage}");
            string expectedMessage = "Đặt hàng thành công";
            string result = (expectedMessage == actualMessage) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualMessage, result);
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Thông báo hiển thị: {actualMessage}");
        }

        [Test]
        public void GH_VoHieuHoaDauCong()
        {
            DangNhap();
            driver.FindElement(By.Id("card-component")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("add-to-cart")).Click();
            Thread.Sleep(1000);
            //GH
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/*[name()='svg'][1]")).Click();
            Thread.Sleep(1000);

            IWebElement increaseButton = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/button[2]/span[1]/*[name()='svg'][1]"));
            Thread.Sleep(1000);
            for (int i = 0; i < 6; i++)
            {
                increaseButton.Click();
                Thread.Sleep(200);
            }
            string pointerEvents = increaseButton.GetCssValue("pointer-events");
            //độ mờ của nút
            string opacity = increaseButton.GetCssValue("opacity");
            bool isDisabled = pointerEvents == "none" || opacity == "0.5";
            Assert.That(isDisabled, Is.False, "Nút tăng số lương bị vô hiệu hóa");
        }


        [Test]
        public void NF12_KiemTraGiaoDienResponsive()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(375, 812);

            string actualResult;
            try
            {
                driver.FindElement(By.Id("home-page"));
                actualResult = "Responsive";
            }
            catch (NoSuchElementException)
            {
                actualResult = "Không có Responsive";
            }

            string expectedResult = "Responsive";
            string result = (actualResult == expectedResult) ? "Passed" : "Failed";
            ExcelDataProvider.WriteResultExcel("LamHuynhHoaNam_22DH112245.xlsx", "Sheet2", actualResult, result);
            Assert.That(actualResult, Is.EqualTo(expectedResult), $"Kết quả: {actualResult}");
        }




        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Dispose();
        }
    }
}