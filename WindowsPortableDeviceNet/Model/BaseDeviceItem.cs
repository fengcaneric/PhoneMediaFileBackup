using System.Collections.Generic;
using PortableDeviceApiLib;

using System.Threading.Tasks;

using System;

namespace WindowsPortableDeviceNet.Model
{
    public class BaseDeviceItem
    {
        public static int LoadedImageCount = 0;
        public static int CopiedImageCount = 0;

        public string Id { get; protected set; }
        public List<Item> DeviceItems { get; private set; }

        public BaseDeviceItem(string id)
        {
            Id = id;
            DeviceItems = new List<Item>();
        }

        static BaseDeviceItem()
        {
            tList = new List<Task>();
        }

        /// <summary>
        /// This method enumerates/cycles through sub objects within this current object.
        /// </summary>
        /// <param name="content"></param>
        protected void LoadDeviceItems(IPortableDeviceContent content)
        {
            // Enumerate the items contained by the current object

            IEnumPortableDeviceObjectIDs objectIds;
            content.EnumObjects(0, Id, null, out objectIds);

            // Cycle through each device item and add it to the device items list.

            uint fetched = 9999;
            for(;fetched > 0;)
            {
                fetched = 0;
                string objectId;
                objectIds.Next(1, out objectId, ref fetched);

                // Check if anything was retrieved.

                if (fetched > 0)
                {
                    Item i = new Item(objectId, content);
                    if (i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.FunctionalObject ||
                        i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Folder ||
                        i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Audio ||
                        i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Video ||
                        i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Image)
                    {
                        DeviceItems.Add(i);
                    }

                    if (i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Audio ||
                        i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Video ||
                        i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Image)
                    {
                        LoadedImageCount++;
                    }
                }
            } 
        }

        public static List<Task> tList = null;
    }
}
