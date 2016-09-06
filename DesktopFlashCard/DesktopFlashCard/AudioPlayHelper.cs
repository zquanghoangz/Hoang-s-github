using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DesktopFlashCard
{
    public class AudioPlayHelper
    {
        //private const string WAV = "waveaudio";
        //private const string MP3 = "mpegvideo";

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
                                                 StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        #region Play Audio

        public static void Play(string fileName, bool repeat)
        {
            mciSendString("open \"" + fileName + "\" type mpegvideo alias MediaFile",
                        null, 0, IntPtr.Zero);
            
            mciSendString("play MediaFile" + (repeat ? " repeat" : String.Empty), null,
                          0, IntPtr.Zero);
        }

        public static void Play(byte[] embeddedResource, bool repeat)
        {
            ExtractResource(embeddedResource, Path.GetTempPath() + "resource.tmp");
            mciSendString("open \"" + Path.GetTempPath() + "resource.tmp" +
                          "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile" + (repeat ? " repeat" : String.Empty),
                          null, 0, IntPtr.Zero);
        }

        public static void Pause()
        {
            mciSendString("stop MediaFile", null, 0, IntPtr.Zero);
        }

        public static void Stop()
        {
            mciSendString("close MediaFile", null, 0, IntPtr.Zero);
        }

        private static void ExtractResource(IEnumerable<byte> res, string filePath)
        {
            if (File.Exists(filePath)) return;

            var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            var bw = new BinaryWriter(fs);

            foreach (var b in res) bw.Write(b);

            bw.Close();
            fs.Close();
        }

        #endregion

        #region Record

        public static void Record()
        {
            mciSendString("open new type waveaudio alias MediaFile", null, 0, IntPtr.Zero);//cannot record mp3
            mciSendString("record MediaFile", null, 0, IntPtr.Zero);
        }

        public static void Save(string fileName)
        {
            mciSendString("save MediaFile \"" + fileName + "\"", null, 0, IntPtr.Zero); //extension .wav
            mciSendString("close MediaFile ", null, 0, IntPtr.Zero);
        }

        #endregion
    }
}