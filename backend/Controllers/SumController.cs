using System;
using System.IO;
using System.Drawing;
using OpenCvSharp;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;


namespace backend.Controllers
{
    public class SumController : Controller
    {
        [Route("ImageProcessor")]
        public IActionResult ProcessImage()
        {
            // Prompt the user to input the filename of the image they want to process
            Console.WriteLine("Enter the filename of the image you want to process:");
            string filename = Console.ReadLine();

            Bitmap YourImage = (Bitmap)Image.FromFile(filename);

            
            // var hue_list = new List<float>();


            // for (var x = 0; x < YourImage.Width; x++)
            // // for (var x = 50; x < 100; x++)
            // {
            //     for (var y = 0; y < YourImage.Height; y++)
            //     {
            //         Color pixel = YourImage.GetPixel(x, y);
            //         float hue, saturation, value;
            //         Color hsvColor = Color.FromArgb(pixel.R, pixel.G, pixel.B);
            //         hue = hsvColor.GetHue();
            //         saturation = hsvColor.GetSaturation();
            //         value = hsvColor.GetBrightness();

            //         if ((hue > 0) && (hue < 179*(360/180)))
            //         {
            //             if ((saturation > 53*(360/256) && saturation < 255))
            //             {
            //                 if ((value > 93*(360/256)) && (value < 255))   

            //                 {
            //                     YourImage.SetPixel(x, y, Color.White);
            //                 }
            //             }
            //         }    

            //         hue_list.Add(hue);
            //     }
            // }
            
            // float maxValue = hue_list.Max();
            // Console.WriteLine("Max HUE is : "+ maxValue);

            // return File(ImageToByteArray(YourImage), "image/png");

            var r_list = new List<int>();
            var g_list = new List<int>();
            var b_list = new List<int>();

            for (var x = 500; x < 600; x++)
            // for (var x = 0; x < YourImage.Width; x++)
            {
                for (var y = 700; y < 800; y++)
                // for (var y = 0; y < YourImage.Height; y++)
                {
                    Color pixel = YourImage.GetPixel(x, y);

                    // Console.WriteLine(pixel);

                    // if (pixel != Color.Blue)
                    if (pixel.R <=100 && pixel.G <=100 && pixel.B > 160)
                    {
                        YourImage.SetPixel(x, y, Color.White);
                    }
                    r_list.Add(pixel.R);
                    g_list.Add(pixel.G);
                    b_list.Add(pixel.B);

                    // Console.WriteLine(pixel);
                }
            }
            int maxR = r_list.Max();
            int maxG = g_list.Max();
            int maxB = b_list.Max();
            int minR = r_list.Min();
            int minG = g_list.Min();
            int minB = b_list.Min();

            Console.WriteLine("Max Red is : "+ maxR + ", Min Red is : "+ minR);
            Console.WriteLine("Max Green is : "+ maxG + ", Min Green is : "+ minG);
            Console.WriteLine("Max Blue is : "+ maxB+ ", Min Blue is : "+ minB);
            

            return File(ImageToByteArray(YourImage), "image/png");
        }
        private static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}































// using Microsoft.AspNetCore.Mvc;
// using System.Drawing;

// namespace backend.Controllers
// {
//     public class SumController : Controller
//     {
//         [Route("ImageProcessor")]
//         public IActionResult ProcessImage()
//         {
//             Bitmap YourImage = (Bitmap)Image.FromFile("1182.jpg");

//             for (var x = 0; x < YourImage.Width; x++)
//             {
//                 for (var y = 0; y < YourImage.Height; y++)
//                 {
//                     Color pixel = YourImage.GetPixel(x, y);
//                     if (pixel.R < 190 && pixel.G < 190 && pixel.B < 150)
//                     {
//                         YourImage.SetPixel(x, y, Color.White);
//                     }
//                 }
//             }

//             return File(ImageToByteArray(YourImage), "image/png");
//         }

//         private static byte[] ImageToByteArray(Image image)
//         {
//             using (var ms = new System.IO.MemoryStream())
//             {
//                 image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
//                 return ms.ToArray();
//             }
//         }
//     }
// }