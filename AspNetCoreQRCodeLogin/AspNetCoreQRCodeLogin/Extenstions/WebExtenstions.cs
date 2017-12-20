using System;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using QRCoder;

namespace WebExtenstions
{
       public static class QRHelper{
        public static IHtmlContent GetnerateQRCode(this IHtmlHelper htmlHelper ,string data,string alt="",int width=256,int height=256){
            QRCodeGenerator  qRCodeGenerator= new QRCodeGenerator();
            QRCodeData qRCodeData=qRCodeGenerator.CreateQrCode(data,QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode=new QRCode(qRCodeData);
            
            Bitmap qrCodeImage = qRCode.GetGraphic(20);
            
            using(var ms = new MemoryStream()){
               qrCodeImage.Save(ms, ImageFormat.Png);
                var img=$"<img src='data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}'  alt='{alt}' width='{width}px' height='{height}px' />";
                return new HtmlString(img);
            }
        }
       }
}