using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp1.converters;

namespace WpfApp1.helper
{
    public class GenerateQRcode
    {
        private BitmapToSOurce sOurce;
       public GenerateQRcode()
       {
            sOurce = new BitmapToSOurce();
       }
        public ImageSource Images { get;  set; }

        public ImageSource makeQrCode(string data)
        {
            QRCodeGenerator qrcodegenerator = new QRCodeGenerator();
            QRCodeData codeData = qrcodegenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(codeData);
            Bitmap qrcodeIamage = qrcode.GetGraphic(20);
            Images = sOurce.BitmapToImSource(qrcodeIamage);

            return Images;
        }




    }
}
