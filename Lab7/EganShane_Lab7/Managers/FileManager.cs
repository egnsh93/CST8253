/**                                                                     **/
/**                                                                     **/
/**    Student Name                :  Shane Egan                        **/
/**    EMail Address               :  egan0049@algonquinlive.com        **/
/**    Student Number              :  040 695 345                       **/
/**    Course Number               :  CST 8253                          **/
/**    Lab Section Number          :  011                               **/
/**    Professor Name              :  Wei Gong                          **/
/**    Assignment Name/Number/Date :  Lab 7 - File IO (Mar 15 2015)     **/
/**    Optional Comments           :                                    **/
/**                                                                     **/
/**                                                                     **/
/*************************************************************************/

using System;
using System.IO;

namespace EganShane_Lab7.Managers
{
    static class FileManager
    {
        private const String DirPath = @"C:\Users\Shane\Bank\";
        private const String FileName = "Customer.txt";

        public static bool CheckFileExists(String dirPath, String fileName)
        {
            return File.Exists(dirPath + fileName);
        }

        public static bool CheckDirExists(String dirPath)
        {

            return Directory.Exists(dirPath);
        }

        public static String GetDirPath()
        {
            return DirPath;
        }

        public static String GetFileName()
        {
            return FileName;
        }
    }
}
