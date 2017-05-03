using System;
using System.IO;

namespace Backupfiles
{
    public static class FastCopy
    {
        static int array_length = (int)Math.Pow(2, 19);
        static byte[] dataArray = new byte[array_length];
        /// <summary> Fast file copy with big buffers
        /// </summary>
        /// <param name="source">Source file path</param> 
        /// <param name="destination">Destination file path</param> 
        static public void FCopy(string source, string destination)
        {
            if (Directory.Exists(Path.GetDirectoryName(destination)) != true)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destination));
            }

            //int array_length = (int)Math.Pow(2, 19);
            //byte[] dataArray = new byte[array_length];
            using (FileStream fsread = new FileStream
            (source, FileMode.Open, FileAccess.Read, FileShare.None, array_length))
            {
                using (BinaryReader bwread = new BinaryReader(fsread))
                {
                    using (FileStream fswrite = new FileStream
                    (destination, FileMode.Create, FileAccess.Write, FileShare.None, array_length))
                    {
                        using (BinaryWriter bwwrite = new BinaryWriter(fswrite))
                        {
                            for (;;)
                            {
                                int read = bwread.Read(dataArray, 0, array_length);
                                if (0 == read)
                                    break;
                                bwwrite.Write(dataArray, 0, read);
                            }
                        }
                    }
                }
            }
            //File.Delete(source);
        }

    }
}
