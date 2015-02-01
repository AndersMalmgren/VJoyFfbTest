using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;

namespace VJoyFfbTest
{
    class Program
    {
        private delegate void Callback(IntPtr data, IntPtr userData);

        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static void FfbRegisterGenCB(Callback cb, IntPtr data);

        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static bool FfbStart(uint rId);

        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static void FfbStop(uint rId);


        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static uint Ffb_h_DeviceID(IntPtr data, ref int id);

        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static uint Ffb_h_Type(IntPtr data, ref int packetType);

        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static uint Ffb_h_EBI(IntPtr data, ref int blockIndex);

        [DllImport("vJoyInterface.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static uint Ffb_h_Eff_Const(IntPtr data, ref FFB_EFF_CONST effect);

        private enum FFBEType // FFB Effect Type
        {
            // Effect Type
            ET_NONE = 0, //    No Force
            ET_CONST = 1, //    Constant Force
            ET_RAMP = 2, //    Ramp
            ET_SQR = 3, //    Square
            ET_SINE = 4, //    Sine
            ET_TRNGL = 5, //    Triangle
            ET_STUP = 6, //    Sawtooth Up
            ET_STDN = 7, //    Sawtooth Down
            ET_SPRNG = 8, //    Spring
            ET_DMPR = 9, //    Damper
            ET_INRT = 10, //    Inertia
            ET_FRCTN = 11, //    Friction
            ET_CSTM = 12, //    Custom Force Data
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FFB_EFF_CONST
        {

            public byte EffectBlockIndex;
            public FFBEType EffectType;
            public UInt32	Duration;// Value in milliseconds. 0xFFFF means infinite
            public UInt32 TrigerRpt;
            public UInt32 SamplePrd;
            public byte	Gain;
            public byte	TrigerBtn;
            public byte	Polar; // How to interpret force direction Polar (0-360�) or Cartesian (X,Y),
            public byte DirectionOrDirX; //Union correct?
            public byte DirY;
        }

        static void Main(string[] args)
        {

            uint index = 1;
            var joystick = new vJoy();

            if (!joystick.vJoyEnabled())
                throw new Exception("vJoy driver not enabled: Failed Getting vJoy attributes");
            

            var status = joystick.GetVJDStatus(index);

            string error = null;
            switch (status)
            {
                case VjdStat.VJD_STAT_BUSY:
                    error = "vJoy Device {0} is already owned by another feeder";
                    break;
                case VjdStat.VJD_STAT_MISS:
                    error = "vJoy Device {0} is not installed or disabled";
                    break;
                case VjdStat.VJD_STAT_UNKN:
                    error = ("vJoy Device {0} general error");
                    break;
            }

            if (error == null && !joystick.AcquireVJD(index))
                error = "Failed to acquire vJoy device number {0}";

            if (error != null)
                throw new Exception(string.Format(error, index));

            joystick.ResetVJD(index);


            if (!FfbStart(index))
                throw new Exception(string.Format("Failed to start Forcefeedback on device {0}", index));

            FfbRegisterGenCB(OnEffect, IntPtr.Zero);

            Console.ReadLine();

            FfbStop(index);
            joystick.RelinquishVJD(index);   
        }

        private static void OnEffect(IntPtr data, IntPtr ptr)
        {
            int id = 0;
            int packetType = 0;
            int blockIndex = 0;
            var effect = new FFB_EFF_CONST();

            //var msg = (FFB_DATA)Marshal.PtrToStructure(data, typeof(FFB_DATA));

            var result = Ffb_h_DeviceID(data, ref id);
            result = Ffb_h_Type(data, ref packetType);
            result = Ffb_h_EBI(data, ref blockIndex);
            result = Ffb_h_Eff_Const(data, ref effect);

            System.Diagnostics.Debug.WriteLine("Device: {0} - Packet type: {1} - Block index: {2}", id, packetType, blockIndex);
            System.Diagnostics.Debug.WriteLine(
                "Effect --> EffectBlockIndex: {0}, EffectType: {1}, Duration: {2}, TrigerRpt: {3}, SamplePrd: {4}, Gain: {5}, TrigerBtn: {6}, Polar: {7}, DirectionOrDirX: {8}, DirectionOrDirX: {9}",
                effect.EffectBlockIndex, effect.EffectType, effect.Duration, effect.TrigerRpt, effect.SamplePrd,
                effect.Gain, effect.TrigerBtn, effect.Polar, effect.DirectionOrDirX, effect.DirectionOrDirX);

            //Will crash when this method returns
        }
    }
}
