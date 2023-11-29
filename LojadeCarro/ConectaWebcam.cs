using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.DirectShow;

namespace LojadeCarro
{
    internal class ConectaWebcam
    {
        internal static object imagem;

        internal class ConectaWebcan
        {
            public static VideoCaptureDevice videoSource;
            public static System.Windows.Forms.PictureBox pcbfoto;
            public static byte[] imagem = null;
            public static void tirarFotoSalvarBD()
            {
                videoSource.NewFrame -= VideoSource_NewFrame;

                Bitmap bmp = new Bitmap(pcbfoto.Image);
                MemoryStream memory = new MemoryStream();
                bmp.Save(memory, ImageFormat.Bmp);
                imagem = memory.ToArray();
            }
            public static void VideoSource_NewFrame(object sender,
                AForge.Video.NewFrameEventArgs eventArgs)
            {
                if (pcbfoto.Image != null)
                    pcbfoto.Image.Dispose(); //Limpa a pcb e a memória
                pcbfoto.Image = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            }
            public static void verificarWebCamLigada()
            {
                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                    pcbfoto.Image = null;
                }
                else
                {
                    videoSource.Start();
                }
            }

            public static void tiraFoto()
            {
                try
                {
                    //Captura um Frame
                    videoSource.NewFrame -= VideoSource_NewFrame;

                    using (var dialog = new System.Windows.Forms.SaveFileDialog())
                    {
                        dialog.DefaultExt = "png";
                        dialog.AddExtension = true;

                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            pcbfoto.Image.Save(dialog.FileName, ImageFormat.Png);
                        }
                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show("Erro: " + ex.Message);
                }
            }
            //Procura o dispositivo 
            public static void procurarDispositivo()
            {
                var videoSources = new
                    FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoSources != null && videoSources.Count > 0)
                {
                    videoSource = new
                    VideoCaptureDevice(videoSources[0].MonikerString);
                    videoSource.NewFrame += VideoSource_NewFrame;
                }
            }
        }
    }
}
