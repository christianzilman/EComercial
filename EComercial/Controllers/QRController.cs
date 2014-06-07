using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using EComercial.Models;

namespace EComercial.Controllers
{
    public class QRController : Controller
    {
        //
        // GET: /QR/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QR(FormCollection form)
        {
            var pagina = form["txtPagina"];
            ViewBag.Pagina = pagina;
            return View(ImagenQR);
        }
        public ActionResult Generar(QR qr)
        {
            // generating a barcode here. Code is taken from QrCode.Net library
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(qr.Nombre, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

            Stream memoryStream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, memoryStream);

            // very important to reset memory stream to a starting position, otherwise you would get 0 bytes returned
            memoryStream.Position = 0;

            var resultStream = new FileStreamResult(memoryStream, "image/png");
            resultStream.FileDownloadName = String.Format("{0}.png", qr.Nombre);

            return resultStream;
        }

        public IView ImagenQR { get; set; }
    }
}
