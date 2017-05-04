using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

//using PortableDevices;
using WindowsPortableDeviceNet;
using WindowsPortableDeviceNet.Model;

namespace Backupfiles
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        #region Events
        private void Backup_Load(object sender, EventArgs e)
        {
            this.bindMTPList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.bindMTPList();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //string drive = this.cmbDriverList.SelectedValue.ToString();
            //PhotoCopyFromDrive pcfd = new PhotoCopyFromDrive();
            //pcfd.copyAllPhotosByThread(drive);

            //copyAllMTPPhotos();
            copyALLMediaFiles(@"E:\test");
        }
        #endregion

        #region Private methods
        private void bindDriveList()
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            if (di != null && di.Count<DriveInfo>() > 0)
            {
                cmbDriverList.DataSource = di.ToList<DriveInfo>();
                cmbDriverList.ValueMember = "Name";
                cmbDriverList.DisplayMember = "Name";
            }
        }

        private void bindMTPList()
        {
            this.btnCopy.Enabled = false;

            this.getConnectedPD();
        }

        private void getConnectedPD()
        {
            DateTime startTime = DateTime.Now;
            Utility ut = new Utility();
            List<Device> connectedPortableDevices = ut.Get(false);
            Console.WriteLine("Time to get devices without items -- " + (DateTime.Now - startTime).TotalMilliseconds);

            
            bindMTPListInThread(connectedPortableDevices);
        }

        private void bindMTPListInThread(List<Device> dList)
        {
            Dictionary<string, string> ds = new Dictionary<string, string>();
            foreach(Device d in dList)
            {
                ds.Add(d.DeviceId, d.Name.Value);
            }

            if (cmbDriverList.InvokeRequired)
            {
                cmbDriverList.BeginInvoke(new MethodInvoker(delegate {
                    cmbDriverList.DataSource = new BindingSource(ds, null);
                    cmbDriverList.DisplayMember = "value";
                    cmbDriverList.ValueMember = "key";
                }));

                btnCopy.BeginInvoke(new MethodInvoker(delegate {
                    btnCopy.Enabled = true;
                }));

            }
            else
            {
                cmbDriverList.DisplayMember = "value";
                cmbDriverList.ValueMember = "key";
                cmbDriverList.DataSource = new BindingSource(ds, null);

                btnCopy.Enabled = true;
            }
        }

        private void copyALLMediaFiles(string destinationPath)
        {
            if (cmbDriverList.SelectedValue == null)
            {
                return;
            }

            string selectValue = cmbDriverList.SelectedValue.ToString();
            btnCopy.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                Utility ut = new Utility();
                Device selectedPD = null;

                selectedPD = ut.GetDevice(selectValue);
                GC.Collect();
                GC.WaitForFullGCComplete();

                DateTime startTime = DateTime.Now;
                try
                {
                    Console.WriteLine("Copy start");
                    selectedPD.TransferData(destinationPath, false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                Console.WriteLine("Copy is done -- " + (DateTime.Now - startTime).TotalMilliseconds);

                btnCopy.BeginInvoke(new MethodInvoker(delegate {
                    btnCopy.Enabled = true;
                }));

            });
        }


        //private void bindMTPList()
        //{
        //    var collection = new PortableDeviceCollection();

        //    collection.Refresh();

        //    Dictionary<string, string> selection = new Dictionary<string, string>();
        //    foreach (var device in collection)
        //    {
        //        device.Connect();
        //        try
        //        {
        //            selection.Add(device.DeviceId, (String.IsNullOrEmpty(device.FriendlyName) ? "Unknow" : device.FriendlyName));
        //        }
        //        finally
        //        {
        //            device.Disconnect();
        //        }
        //    }
        //    cmbDriverList.DataSource = new BindingSource(selection, null);
        //    cmbDriverList.ValueMember = "Key";
        //    cmbDriverList.DisplayMember = "Value";

        //}

        //private void copyAllMTPPhotos()
        //{
        //    var collection = new PortableDeviceCollection();

        //    collection.Refresh();

        //    PortableDevice device = (PortableDevice)collection.FirstOrDefault(s => s.DeviceId.Equals(cmbDriverList.SelectedValue));

        //    device.Connect();
        //    try
        //    {
        //        var folder = device.GetContents();

        //        printFiles(folder, 0);
        //        //foreach (var item in folder.Files)
        //        //{
        //        //    Console.WriteLine(item.Name);
        //        //}
        //    }
        //    finally
        //    {
        //        device.Disconnect();
        //    }

        //}

        //private static void printFiles(PortableDeviceFolder folder, int i)
        //{
        //    foreach (var item in folder.Files)
        //    {
        //        Console.WriteLine("L" + i + " - " + item.Name);
        //        if (item is PortableDeviceFile)
        //        {
        //            Console.WriteLine("L" + i + " - " + Path.GetFileName(item.Id));
        //        }

        //        if (item is PortableDeviceFolder)
        //        {
        //            printFiles(item as PortableDeviceFolder, i+1);
        //        }
        //    }
        //}


        #endregion
    }
}
