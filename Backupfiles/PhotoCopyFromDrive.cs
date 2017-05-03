using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;


namespace Backupfiles
{
    class PhotoCopyFromDrive
    {
        #region Photo copy
        static List<string> allPhotoDirs = null;
        public void copyAllPhotos()
        {
            int time = DateTime.Now.Millisecond;

            int count = allPhotoDirs.Count;
            while (count > 0)
            {
                string dir = "";
                lock (allPhotoDirs)
                {
                    dir = allPhotoDirs[0];
                    allPhotoDirs.RemoveAt(0);
                }

                copyDirPhotos(dir, @"e:\test\");

                lock (allPhotoDirs)
                {
                    count = allPhotoDirs.Count;
                }
            }
            Console.WriteLine("Finish time:" + (DateTime.Now.Millisecond - time));
        }

        public void copyAllPhotosByThread(string drive)
        {
            allPhotoDirs = getAllDirWithPhoto(drive);

            Thread firstThread = new Thread(new ThreadStart(this.copyAllPhotos));
            firstThread.Start();

            Thread secondThread = new Thread(new ThreadStart(this.copyAllPhotos));
            secondThread.Start();
        }

        public List<string> getAllDirWithPhoto(string path)
        {
            bool withPhoto = false;
            List<string> result = new List<string>();

            string[] dirs = Directory.GetDirectories(path);

            for (int i = 0; i < dirs.Count(); i++)
            {
                withPhoto = false;
                try
                {
                    withPhoto = (Directory.EnumerateFiles(dirs[i], "*.*", SearchOption.AllDirectories).FirstOrDefault(s => s.EndsWith(".png") || s.EndsWith(".jpg"))
                                        != null);
                }
                catch
                {

                }
                if (withPhoto == true)
                {
                    result.Add(dirs[i]);
                }
            }

            return result;
        }

        public void copyDirPhotos(string sPath, string dRootPath)
        {
            try
            {
                string dPath = dRootPath + sPath.Replace(Path.GetPathRoot(sPath), "");

                var photosFiles = Directory.EnumerateFiles(sPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg"));
                foreach (string fName in photosFiles)
                {
                    FastCopy.FCopy(fName, fName.Replace(sPath, dPath));

                    Console.WriteLine(fName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #endregion

    }
}
