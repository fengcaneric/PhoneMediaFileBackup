using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowsPortableDeviceNet.Model
{
    public class UtilityHelper
    {
        public static int LoadedFileCount = 0;
        public static int CopiedFileCount = 0;
        public static int RootItemCount = 0;
        public static int LoadedItemCount = 0;
        public static List<Task> threadList = null;

        public static void Initial()
        {
            LoadedFileCount = 0;
            CopiedFileCount = 0;
            RootItemCount = 0;
            LoadedItemCount = 0;
            threadList = null;
        }
    }
}
