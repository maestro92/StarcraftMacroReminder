using NAudio.Wave;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

// http://www.pinvoke.net/default.aspx/gdi32.setdevicegammaramp

public class Test
{

    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RAMP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Red;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Green;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Blue;
    }



    public static void SetGamma(bool redMode)
    {

        if(redMode)
        {
            int gamma = 256;
            RAMP ramp = new RAMP();
            ramp.Red = new ushort[256];
            ramp.Green = new ushort[256];
            ramp.Blue = new ushort[256];
            for (int i = 1; i < 256; i++)
            {
                int iArrayValue = i * (gamma + 128);

                if (iArrayValue > 65535)
                    iArrayValue = 65535;


                //    int iArrayValue2 = i * 128;// i * (0 + 128);

                int iArrayValue2 = i * (0 + 128);

                if (iArrayValue2 > 65535)
                    iArrayValue2 = 65535;

                ramp.Red[i] = (ushort)iArrayValue;

                // ramp.Blue[i] = (ushort)iArrayValue;
                // ramp.Green[i] = (ushort)iArrayValue2;
                ramp.Blue[i] = ramp.Green[i] = (ushort)iArrayValue2;


                //                ramp.Blue[i] = ramp.Green[i] = (ushort)iArrayValue2;
            }
            bool b = SetDeviceGammaRamp(GetDC(IntPtr.Zero), ref ramp);
            if (b)
            {
                // Console.WriteLine("SetDeviceGammaRamp is true");
            }
            else
            {
                Console.WriteLine("SetDeviceGammaRamp is false");
            }
        }
        else
        {
            RAMP ramp = new RAMP();
            ramp.Red = new ushort[256];
            ramp.Green = new ushort[256];
            ramp.Blue = new ushort[256];
            int gamma = 100;
            for (int i = 1; i < 256; i++)
            {
                int iArrayValue = i * (gamma + 128);

                if (iArrayValue > 65535)
                    iArrayValue = 65535;
                ramp.Red[i] = ramp.Blue[i] = ramp.Green[i] = (ushort)iArrayValue;
            }
            bool b = SetDeviceGammaRamp(GetDC(IntPtr.Zero), ref ramp);
            if (b)
            {
                // Console.WriteLine("SetDeviceGammaRamp is true");
            }
            else
            {
                Console.WriteLine("SetDeviceGammaRamp is false");
            }
        }
    }


    


    public static void Main(string[] args)
    {
        string ent = "";
        int g = 0;

        WaveOutEvent waveOut = new WaveOutEvent();
        WaveFileReader wavReader = new WaveFileReader("media.io_reminder.wav");
        waveOut.Init(wavReader);


        bool running = true;
        bool displaying = false;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        
        long start = stopwatch.ElapsedMilliseconds;
        long displayingStart = 0;
        while (running)
        {
            long now = stopwatch.ElapsedMilliseconds;
            if (now - start > 5000)
            {
                SetGamma(true);
                wavReader.Position = 0;
                waveOut.Play();

                displaying = true;
                start = now;
                displayingStart = now;
            }

            if (displaying)
            {
                if(now - displayingStart > 1000)
                {
                    SetGamma(false);
                    displaying = false;
                }
            }

            Thread.Sleep(10);
        }
        
    }
}