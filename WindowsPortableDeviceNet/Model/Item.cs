﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using PortableDeviceApiLib;
using WindowsPortableDeviceNet.Model.Properties;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace WindowsPortableDeviceNet.Model
{
    public class Item : BaseDeviceItem
    {
        public static List<string> LoadFolders = new List<string>();

        public ContentTypeProperty ContentType { get; set; }
        public NameProperty Name { get; set; }
        public OriginalFileNameProperty OriginalFileName { get; set; }

        private IPortableDeviceContent DeviceContent { get; set; }

        static int array_length = (int)Math.Pow(2, 19);
        const int MAX_THREAD_COUNT = 1;

        public Item(string objectId, IPortableDeviceContent content)
            : base(objectId)
        {
            DeviceContent = content;

            IPortableDeviceProperties properties;
            content.Properties(out properties);

            IPortableDeviceKeyCollection keys;
            properties.GetSupportedProperties(objectId, out keys);

            IPortableDeviceValues values;
            properties.GetValues(objectId, keys, out values);

            ContentType = new ContentTypeProperty(values);
            Name = new NameProperty(values);

            // Only load the sub information if the current object is a folder or functional object.

            switch (ContentType.Type)
            {
                case WindowsPortableDeviceEnumerators.ContentType.FunctionalObject:
                    {
                        //TODO: Replace it back to LoadDeviceItems if not correct
                        LoadDeviceItemsByThread(content);
                        break;
                    }

                case WindowsPortableDeviceEnumerators.ContentType.Folder:
                    {
                        OriginalFileName = new OriginalFileNameProperty(values);
                        LoadDeviceItems(content);
                        break;
                    }

                case WindowsPortableDeviceEnumerators.ContentType.Image:
                case WindowsPortableDeviceEnumerators.ContentType.Video:
                case WindowsPortableDeviceEnumerators.ContentType.Audio:
                    {
                        OriginalFileName = new OriginalFileNameProperty(values);
                        break;
                    }
            }
        }

        private void GetDeviceItemCount(string parentID, IPortableDeviceContent content)
        {
            IEnumPortableDeviceObjectIDs objectIds;
            content.EnumObjects(0, parentID, null, out objectIds);
            uint fe = 9999;
            string ob;

            UtilityHelper.RootItemCount = 0;
            for (; fe > 0;)
            {
                fe = 9999;
                objectIds.Next(1, out ob, ref fe);
                UtilityHelper.RootItemCount++;
            }
            UtilityHelper.RootItemCount--;

        }

        #region Load items by thread
        private void LoadDeviceItemsByThread(IPortableDeviceContent content)
        {
            UtilityHelper.Initial();

            // Enumerate the items contained by the current object
            IEnumPortableDeviceObjectIDs objectIds;
            content.EnumObjects(0, Id, null, out objectIds);

            //Get total item count, it is for progress.
            GetDeviceItemCount(Id, content);

            // Cycle through each device item and add it to the device items list.
            int fCount = 0;
            uint fetched = 9999;
            for (; fetched > 0;)
            {
                fetched = 0;
                string objectId;
                objectIds.Next(1, out objectId, ref fetched);

                // Check if anything was retrieved.

                if (fetched > 0)
                {
                    fCount++;
                    Console.WriteLine("Folder count: " + fCount);
                    if (IsInFolderList(objectId, content) == false)
                    {
                        UtilityHelper.LoadedItemCount++;
                        continue;
                    }

                    while (UtilityHelper.threadList.Count >= MAX_THREAD_COUNT)
                    {
                        Thread.Sleep(200);
                        Console.WriteLine("Sleep -- fCount is " + fCount);
                    }
                    Console.WriteLine("Start Task:" + fCount);
                    int fNumber = fCount;
                    Task t = new Task(() => GetItemsByThread(objectId, content, fNumber));
                    t.Start();
                    UtilityHelper.threadList.Add(t);
                }
            }
        }

        private void GetItemsByThread(string objectId, IPortableDeviceContent content, int fNumber)
        {
            DateTime startTime = DateTime.Now;

            //Console.WriteLine("Task begin:" + fNumber + "ObjectID:" + objectId);

            Item i = new Item(objectId, content);
            if (i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.FunctionalObject ||
                i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Folder ||
                i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Audio ||
                i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Video ||
                i.ContentType.Type == WindowsPortableDeviceEnumerators.ContentType.Image)
            {
                DeviceItems.Add(i);
            }

            RemoveCurrentTask();

            UtilityHelper.LoadedItemCount++;
            Console.WriteLine("Folder:" + fNumber + " " + i.Name.Value +" -- " + (DateTime.Now - startTime).TotalMilliseconds + " -- Task Count: " + UtilityHelper.threadList.Count);
        }

        private void RemoveCurrentTask()
        {
            Task currentTask = UtilityHelper.threadList.Find(tl => tl.Id == Task.CurrentId);
            if (currentTask != null)
            {
                lock (UtilityHelper.threadList)
                {
                    UtilityHelper.threadList.Remove(currentTask);
                }
            }
        }

        private bool IsInFolderList(string objectId, IPortableDeviceContent content)
        {
            bool result = false;

            DeviceContent = content;

            IPortableDeviceProperties properties;
            content.Properties(out properties);

            IPortableDeviceKeyCollection keys;
            properties.GetSupportedProperties(objectId, out keys);

            IPortableDeviceValues values;
            properties.GetValues(objectId, keys, out values);

            var theContentType = new ContentTypeProperty(values);
            var theName = new NameProperty(values);

            if (LoadFolders.Count == 0 || LoadFolders.Contains(theName.Value.ToUpper()))
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region Transfer files
        public void TransferFiles(string destinationPath, bool isKeepFolderStructure)
        {
            switch (ContentType.Type)
            {
                case WindowsPortableDeviceEnumerators.ContentType.Folder:
                case WindowsPortableDeviceEnumerators.ContentType.FunctionalObject:
                {
                    if (isKeepFolderStructure)
                    {
                        destinationPath = Path.Combine(destinationPath, Name.Value);
                        if (!Directory.Exists(destinationPath))
                        {
                            Directory.CreateDirectory(destinationPath);
                        }
                    }

                    foreach (Item item in DeviceItems)
                    {
                        item.TransferFiles(destinationPath, isKeepFolderStructure);
                    }
                }
                break;

                case WindowsPortableDeviceEnumerators.ContentType.Image:
                case WindowsPortableDeviceEnumerators.ContentType.Video:
                case WindowsPortableDeviceEnumerators.ContentType.Audio:
                    {
                        Console.WriteLine("Start Task: copy " + OriginalFileName.Value);
                        TransferFile(destinationPath);
                        UtilityHelper.CopiedFileCount++;
                        Console.WriteLine("Copy files " + UtilityHelper.CopiedFileCount);
                    }
                    break;
            }
        }

        //Share buffer, not assign and release every time.
        static byte[] buffer = new byte[array_length];
        /// <summary>
        /// This method copies the file from the device to the destination path.
        /// </summary>
        /// <param name="destinationPath"></param>
        private void TransferFile(string destinationPath)
        {
            // TODO: Clean this up.

            IPortableDeviceResources resources;
            DeviceContent.Transfer(out resources);

            IStream wpdStream = null;
            uint optimalTransferSize = 0;

            var property = new _tagpropertykey
                               {
                                   fmtid = new Guid("E81E79BE-34F0-41BF-B53F-F1A06AE87842"),
                                   pid = 0
                               };

            System.Runtime.InteropServices.ComTypes.IStream sourceStream = null;
            try
            {
                resources.GetStream(Id, ref property, 0, ref optimalTransferSize, out wpdStream);
                sourceStream = (System.Runtime.InteropServices.ComTypes.IStream)wpdStream;

                FileStream targetStream = new FileStream(
                    Path.Combine(destinationPath, OriginalFileName.Value),
                    FileMode.Create,
                    FileAccess.Write);

                unsafe
                {
                    try
                    {
                        int bytesRead = 9999;
                        for(;bytesRead>0;)
                        {
                            bytesRead = 0;
                            sourceStream.Read(buffer, array_length, new IntPtr(&bytesRead));
                            targetStream.Write(buffer, 0, array_length);
                        } 
                    }
                    finally
                    {
                        targetStream.Close();
                    }
                }
            }
            catch(System.Runtime.InteropServices.COMException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sourceStream != null)
                {
                    Marshal.ReleaseComObject(sourceStream);
                }
                if (wpdStream != null)
                {
                    Marshal.ReleaseComObject(wpdStream);
                }
            }
        }
        #endregion
    }
}
