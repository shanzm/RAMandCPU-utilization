#region
// ===============================================================================
// Project Name        :    ConsoleApplication1
// Project Description :   
// ===============================================================================
// Class Name          :    磁盘剩余
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-7 22:15:47
// Update Time         :    2018-6-7 22:15:47
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public  class cipan
    {

        /// 获取指定驱动器的空间总大小(单位为GB)  
        /// </summary>   
        /// <param name=”str_HardDiskName”>只需输入代表驱动器的字母即可 </param>  
        /// <returns> </returns>    
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }

        /// <summary>  
        /// 获取指定驱动器的剩余空间总大小(单位为GB)  
        /// </summary>  
        /// <param name=”str_HardDiskName”>只需输入代表驱动器的字母即可 </param>  
        /// <returns> </returns>  
        public static long GetHardDiskFreeSpace(string str_HardDiskName)
        {
            long freeSpace = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            return freeSpace;
        }




    }
}
