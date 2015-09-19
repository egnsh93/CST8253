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
    internal class CustomerManager
    {
        private FileStream _fs;
        private StreamWriter _sw;
        private String _name;
        private double _checkingsBalance;
        private double _savingsBalance;
        
        public CustomerManager()
        {
            _name = null;
            _checkingsBalance = 0.0;
            _savingsBalance = 0.0;
        }

        public void Load()
        {
            // Opens the file, reads in all lines, and closes the file
            var lines = File.ReadAllLines(FileManager.GetDirPath() + FileManager.GetFileName());

            // Extract the customer data from the array of file data
            _name = lines[0];
            _checkingsBalance = Convert.ToDouble(lines[1]);
            _savingsBalance = Convert.ToDouble(lines[2]);
        }

        public void Save(String name, double checkingsBalace, double savingsBalance)
        {
            // If the directory does not exist
            if (!FileManager.CheckDirExists(FileManager.GetDirPath()))
            {
                Directory.CreateDirectory(@"C:\Users\Shane Egan\Bank\");
            }

            // If the file exists, open it. Otherwise create it. Must have elevated privledges.
            _fs = new FileStream(FileManager.GetDirPath() + FileManager.GetFileName(), FileMode.OpenOrCreate);
            _sw = new StreamWriter(_fs);

            try
            {
                // Write the customer data to file
                _sw.WriteLine(name);
                _sw.WriteLine(checkingsBalace);
                _sw.WriteLine(savingsBalance);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error was encountered while attempting to write to the file.");
            }
            finally
            {
                // Clean up resources
                _sw.Close();
                _fs.Close();
            }
        } 

        public String UpdateName()
        {
            return _name;
        }

        public double UpdateCheckingsBalance()
        {
            return _checkingsBalance;
        }

        public double UpdateSavingsBalance()
        {
            return _savingsBalance;
        }
    }
}
