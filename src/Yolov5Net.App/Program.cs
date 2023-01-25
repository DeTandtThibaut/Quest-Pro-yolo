using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using OpenCvSharp;
using Yolov5Net.Scorer;
using Yolov5Net.Scorer.Models;

namespace Yolov5Net.App
{
    class Program
    {
        /*static void Main(string[] args)
        {
            using var image = Image.FromFile("Assets/test.jpg");

            using var scorer = new YoloScorer<YoloCocoP5Model>("Assets/Weights/yolov5n.onnx");

            List<YoloPrediction> predictions = scorer.Predict(image);

            using var graphics = Graphics.FromImage(image);

            foreach (var prediction in predictions) // iterate predictions to draw results
            {
                double score = Math.Round(prediction.Score, 2);

                graphics.DrawRectangles(new Pen(prediction.Label.Color, 1),
                    new[] { prediction.Rectangle });

                var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);

                graphics.DrawString($"{prediction.Label.Name} ({score})",
                    new Font("Consolas", 16, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
                    new PointF(x, y));
            }

            image.Save("Assets/result.jpg");
        }*/


        public static void Main()
        {

            ForFun fun = new ForFun();

            ForFun2 fun2 = new ForFun2();

            Thread ti = new Thread(new ThreadStart(() => fun.Fun()));
            ti.Start();

            Thread ti2 = new Thread(new ThreadStart(() => fun2.Fun2()));
            ti2.Start();

        }


        public class ForFun2
        {

            public Process process = new Process();
            public ProcessStartInfo ps = new ProcessStartInfo();

            public void Fun2()
            {

                Console.WriteLine("Entered in 2nd thread");

                ps.WindowStyle = ProcessWindowStyle.Normal;
                ps.CreateNoWindow = true;
                ps.UseShellExecute = false;
                ps.RedirectStandardOutput = true;
                ps.RedirectStandardError = true;

                process = new Process();
                ps.FileName = "D:\\Downloads\\wetransfer_yolov5-net-master-zip_2023-01-24_1426\\yolov5-net-master\\src\\Yolov5Net.App\\bin\\Debug\\adb.exe";
                ps.Arguments = "disconnect ";
                process.StartInfo = ps;
                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());
                process.Close(); process.Dispose();

                process = new Process();
                ps.FileName = "D:\\Downloads\\wetransfer_yolov5-net-master-zip_2023-01-24_1426\\yolov5-net-master\\src\\Yolov5Net.App\\bin\\Debug\\adb.exe";
                ps.Arguments = "connect " + "127.0.0.1:5555";
                process.StartInfo = ps;
                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());
                process.Close(); process.Dispose();

                process = new Process();
                ps.FileName = "D:\\Downloads\\wetransfer_yolov5-net-master-zip_2023-01-24_1426\\yolov5-net-master\\src\\Yolov5Net.App\\bin\\Debug\\adb.exe";
                ps.Arguments = "reverse " + "--remove-all";
                process.StartInfo = ps;
                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());
                process.Close(); process.Dispose();

                process = new Process();
                ps.FileName = "D:\\Downloads\\wetransfer_yolov5-net-master-zip_2023-01-24_1426\\yolov5-net-master\\src\\Yolov5Net.App\\bin\\Debug\\adb.exe";
                ps.Arguments = "push " + "scrcpy-server " + "/data/local/tmp/scrcpy-server.jar";
                process.StartInfo = ps; process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());
                process.Close(); process.Dispose();


                process = new Process();
                ps.FileName = "D:\\Downloads\\wetransfer_yolov5-net-master-zip_2023-01-24_1426\\yolov5-net-master\\src\\Yolov5Net.App\\bin\\Debug\\adb.exe";
                ps.Arguments = "reverse " + "localabstract:scrcpy " + "tcp:27183";
                process.StartInfo = ps; process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());
                process.Close(); process.Dispose();

                process = new Process();
                ps.FileName = "D:\\Downloads\\wetransfer_yolov5-net-master-zip_2023-01-24_1426\\yolov5-net-master\\src\\Yolov5Net.App\\bin\\Debug\\adb.exe";
                ps.Arguments = "shell " + "CLASSPATH=/data/local/tmp/scrcpy-server.jar " +
              "app_process " + "/ " + "com.genymobile.scrcpy.Server " +
             "1.13 " + "512 " + "8000000 " + "0 " + "1 " + "false " + "- " + "false " + "false" + " 0";
                process.StartInfo = ps; process.Start();
                Console.WriteLine(process.StandardError.ReadToEnd());
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                process.WaitForExit(); process.Close(); process.Dispose();

            }
        }

        class ForFun
        {
            public void Fun()
            {

                TcpListener server = null;
                TcpListener server2 = null;

                Int32 port = 27183;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                TcpClient client = null;
                NetworkStream stream = null;

                Int32 port2 = 27184;
                IPAddress localAddr2 = IPAddress.Parse("127.0.0.1");
                server2 = new TcpListener(localAddr2, port2);
                TcpClient client2 = null;
                NetworkStream stream2 = null;

                byte[] bb4 = new byte[12];

                try
                {

                    server.Start();
                    server2.Start();


                    while (true)
                    {

                        Console.WriteLine("Waiting for a connection Server No.1---------- ");
                        client = server.AcceptTcpClient();

                        Console.WriteLine("Connected!========>1");
                        stream = client.GetStream();

                        BufferedStream bf = new BufferedStream(stream);
                        Console.Write("Waiting for a connection Server No.2---------- ");

                        Thread ti3 = new Thread(new ThreadStart(() => ForFun3.Fun3())); ti3.Start();


                        client2 = server2.AcceptTcpClient();
                        Console.WriteLine("Connected!========>2");
                        stream2 = client2.GetStream();
                        BufferedStream bf2 = new BufferedStream(stream2);


                        while (true)
                        {
                            while (client.Connected)
                            {
                                if (bf.Read(bb4, 0, bb4.Length) > -1)
                                {
                                    bf2.Write(bb4, 0, bb4.Length);
                                }
                            }



                        }
                    }

                }
                catch (SocketException e)
                {
                    Console.WriteLine("One Number Exception on Socket", e);

                }

                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("Two Number on Augument Null", ane.ToString());

                }

                catch (Exception e)
                {

                    Console.WriteLine("Third is Gneeal", e.ToString());

                }

                finally
                {

                    server.Stop();
                    server2.Stop();
                }

                if (stream != null)
                {

                    stream.Flush();
                    stream.Close();
                    stream2.Flush();
                    stream2.Close();
                    client.Close();
                    client2.Close();
                    server.Stop();
                    server2.Stop();

                }



                Process process = new Process();
                ProcessStartInfo ps = new ProcessStartInfo();




                ps.WindowStyle = ProcessWindowStyle.Normal;
                ps.CreateNoWindow = true;
                ps.UseShellExecute = false;
                ps.RedirectStandardOutput = true;
                ps.RedirectStandardOutput = true;
                ps.RedirectStandardError = true;


                ps.FileName = "adb.exe ";
                ps.Arguments = "reverse " + "--remove-all";
                process.StartInfo = ps;
                process.Start();

                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());

                process.Close(); process.Dispose();



                process.Close(); process.Dispose();

                process = new Process();
                ps.FileName = "adb.exe ";
                ps.Arguments = "kill-server";
                process.StartInfo = ps;
                process.Start();

                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.StandardError.ReadToEnd());

                process.Close();
                process.Dispose();

                Console.WriteLine("\nHit enter to continue...");
                Console.Read();

            }
        }

        class ForFun3
        {
            private static int SafeInt32(long value)
            {
                if (value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("value too large");
                }
                return (int)value;
            }

            public static void Fun3()
            {

                VideoCapture capture = new VideoCapture("tcp://127.0.0.1:27184");
                //capture.Roll = capture.Tilt + 1;

                Mat image = new Mat();
                //var angle = 40;
                //var center = new Point2f(capture.FrameWidth / 2, capture.FrameHeight / 2);
                //var scale = 1.0;

                while (true)
                {

                    image = capture.RetrieveMat();


                    try
                    {
                        Cv2.Rotate(image, image, RotateFlags.Rotate90Clockwise);

                        // var rot_mat = Cv2.GetRotationMatrix2D(center, angle, scale);
                        // Cv2.WarpAffine(image, image, rot_mat, new Size(capture.FrameWidth, capture.FrameHeight));
                        // Mat cropped = new Mat(image, new Rect(1600, 900, 1900, 570));
                        // Resize the frame to the desired resolution
                        // Cv2.Resize(image, image, new Size(1600, 900));
                        // set the region of interest
                        // Cv2.SetImageROI(image, new Rect(1900, 570, image.Width - 1900, image.Height - 570));
                        // Cv2.SelectROI("window", image);
                        Cv2.Resize(image, image, new OpenCvSharp.Size(3200, 1800));
                        image = new Mat(image, new Rect(1660, 500, 1440, 900));




                        /*
                         * ###
                         * Yolov5 Part
                         * ###
                         */



                        Bitmap imageconverted = new Bitmap(image.Width, image.Height, SafeInt32(image.Step()), System.Drawing.Imaging.PixelFormat.Format24bppRgb, image.Data);

                        using var scorer = new YoloScorer<YoloCocoP5Model>("Assets/Weights/yolov5n.onnx");

                        List<YoloPrediction> predictions = scorer.Predict(imageconverted);

                        using var graphics = Graphics.FromImage(imageconverted);

                        foreach (var prediction in predictions) // iterate predictions to draw results
                        {
                            double score = Math.Round(prediction.Score, 2);

                            graphics.DrawRectangles(new Pen(prediction.Label.Color, 1),
                                new[] { prediction.Rectangle });

                            var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);

                            graphics.DrawString($"{prediction.Label.Name} ({score})",
                                new Font("Consolas", 16, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
                                new PointF(x, y));
                        }

                        //imageconverted.Save("Assets/result.jpg");



                        Mat imageToDisplay = new Mat(imageconverted.Height, imageconverted.Width, MatType.CV_8UC3);
                        //Console.WriteLine((imageconverted.Width).ToString(), (imageconverted.Height).ToString());
                        Cv2.Resize(image, image, new OpenCvSharp.Size(3200, 1800));
                        imageToDisplay = new Mat(image, new Rect(1660, 500, 1440, 900));


                        Cv2.ImShow("window", imageToDisplay);

                    }
                    catch (Exception e) { }

                    Cv2.WaitKey(1);


                }
            }
        }
    }



    
}
