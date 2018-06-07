using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace 沛川_cpu和内存
{
    class Program
    {
        public static PerformanceCounter cpu;
        //public static ComputerInfo cif;  
        static void Main(string[] args)
        {
            List<string> info = new List<string>();


            Console.WriteLine("磁盘总空间：{0}G", cipan.GetHardDiskSpace("C"));
            Console.WriteLine("剩余空间：{0}\n", cipan.GetHardDiskFreeSpace("C"));
            info.Add("磁盘总空间：" + cipan.GetHardDiskSpace("C") + "G");
            info.Add("剩余空间：" + cipan.GetHardDiskFreeSpace("C") + "G");
            info.Add("      \n");

            cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            // cif = new ComputerInfo();  
            MEMORY_INFO MemInfo;
            MemInfo = new MEMORY_INFO();



            while (true)
            {
                GlobalMemoryStatus(ref  MemInfo);
                Console.WriteLine("内存利用率：" + MemInfo.dwMemoryLoad.ToString() + "%");
                info.Add("内存利用率：" + MemInfo.dwMemoryLoad.ToString() + "%");


                var percentage = cpu.NextValue();
                Console.WriteLine("CPU利用率：" + percentage + "%\n");
                info.Add("CPU利用率：" + percentage + "%");



                File.WriteAllLines(@"C:\Users\shanzm\Desktop\info.txt", info);


                System.Threading.Thread.Sleep(2000);
            }


        }


        [DllImport("kernel32")]
        public static extern void GetSystemDirectory(StringBuilder SysDir, int count);
        [DllImport("kernel32")]
        public static extern void GetSystemInfo(ref  CPU_INFO cpuinfo);
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref  MEMORY_INFO meminfo);
        [DllImport("kernel32")]
        public static extern void GetSystemTime(ref  SYSTEMTIME_INFO stinfo);
    }




    //定义CPU的信息结构    
    [StructLayout(LayoutKind.Sequential)]
    public struct CPU_INFO
    {
        public uint dwOemId;
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }


    //定义内存的信息结构    
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_INFO
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public uint dwTotalPhys;
        public uint dwAvailPhys;
        public uint dwTotalPageFile;
        public uint dwAvailPageFile;
        public uint dwTotalVirtual;
        public uint dwAvailVirtual;
    }

    //定义系统时间的信息结构    
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME_INFO
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }


}
