using AspNetCoreQRCodeLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using QRCoder;
using System;
using System.Diagnostics;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;

namespace AspNetCoreQRCodeLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _cache;
        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult QRCode()
        {
            var qrCode = Guid.NewGuid().ToString("N");
            ViewBag.QRCode = qrCode;
            _cache.SetString(qrCode, $"{QRCodeStatus.NEW}_", new DistributedCacheEntryOptions().SetAbsoluteExpiration(new TimeSpan(0, 5, 0)));
            return View();
        }

        public FileResult QRCodeNew()
        {
            return File(QRCodeGeneratorHelper(), "image/png");
        }

        private Byte[] QRCodeGeneratorHelper()
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode($"{Guid.NewGuid().ToString("N")}", QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qrCodeImage = qRCode.GetGraphic(20);

            using (var ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
