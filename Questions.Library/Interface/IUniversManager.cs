using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Interface
{
    public interface IUniversManager
    {
        bool ConfigureBoard(int length, int height);
        void ConigureUniversGeneration(int generation);
        bool LoadCells();
        bool RunUniverseLivespan();
    }
}
