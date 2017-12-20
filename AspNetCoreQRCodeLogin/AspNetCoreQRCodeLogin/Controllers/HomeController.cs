using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreQRCodeLogin.Models;
using QRCoder;
using System.DrawingCore;
using System.IO;
using System.DrawingCore.Imaging;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreQRCodeLogin.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult QRCode() {
            ViewBag.QRCode=Guid.NewGuid().ToString("N");
            return View();   
        }

        public FileResult QRCodeNew(){
             return File(QRCodeGeneratorHelper(), "image/png");
        }

        private Byte[] QRCodeGeneratorHelper(){
            QRCodeGenerator  qRCodeGenerator= new QRCodeGenerator();
            QRCodeData qRCodeData=qRCodeGenerator.CreateQrCode($"UserId:{Guid.NewGuid().ToString("N")}",QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode=new QRCode(qRCodeData);
            Bitmap qrCodeImage = qRCode.GetGraphic(20);
            
            using(var ms = new MemoryStream()){
               qrCodeImage.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
  
}
