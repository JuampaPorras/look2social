using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace SmartSocial.Desktop
{
    class ZipLib
    {
        //function that will uncompress the zip file with info of data files
        public bool uncompressDataFile(string completeFilePath, string saveFileName)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(completeFilePath);
                directoryName = directoryName + "\\smartsocialTemp_" + saveFileName.Substring(0, saveFileName.Length - 4);

                //create a stream variable with the content of the zip file for data files
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(completeFilePath)))
                {

                    ZipEntry theEntry;
                    //will go thru all the files(Excel) inside the zip file
                    while ((theEntry = s.GetNextEntry()) != null)
                    {

                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        //check if is a valid file
                        if (fileName != String.Empty)
                        {
                            //logic that will uncompress each file inside the zip
                            using (FileStream streamWriter = File.Create(directoryName + "\\" + theEntry.Name))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }

                return true;

            }

            catch (Exception ex)
            {
                //return false in case of any general IO error operations
                return false;
            }

        }

        //function that will uncompress the zip file with info of data files
        public bool uncompressStreamFile(string completeFilePath, string saveFileName)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(completeFilePath);
                directoryName = directoryName + "\\smartsocialTemp2_" + saveFileName.Substring(0, saveFileName.Length - 4);

                //create a stream variable with the content of the zip file for data files
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(completeFilePath)))
                {

                    ZipEntry theEntry;
                    //will go thru all the files(Excel) inside the zip file
                    while ((theEntry = s.GetNextEntry()) != null)
                    {

                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        //check if is a valid file
                        if (fileName != String.Empty)
                        {
                            //logic that will uncompress each file inside the zip
                            using (FileStream streamWriter = File.Create(directoryName + "\\" + theEntry.Name))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }

                return true;

            }

            catch (Exception ex)
            {
                //return false in case of any general IO error operations
                return false;
            }

        }



    }
}
