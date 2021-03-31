using Questions.Library.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Controller
{
    public class FileManager : IFileManager
    {
        private string filename;

        public FileManager()
        {
            filename = "ConwayGameofLife.txt";
        }

        public void ClearFileContent()
        {
            try
            {
                File.WriteAllText(filename, String.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void WriteToFile(string content)
        {
            try
            {
                File.AppendAllLines(filename, new[] { content });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void CreateFile()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
