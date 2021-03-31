using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Interface
{
    public interface IFileManager
    {
        void ClearFileContent();
        void WriteToFile(string content);
        void CreateFile();
    }
}
