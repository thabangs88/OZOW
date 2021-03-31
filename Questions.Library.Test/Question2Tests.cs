using NUnit.Framework;
using Questions.Library.Controller;
using Questions.Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Test
{
    [TestFixture]
    public class Question2Tests
    {
        IUniversManager _universeManager;
        IFileManager _fileManager;
        public Question2Tests()
        {
            _universeManager = new UniversManager();
            _fileManager = new FileManager();
        }

        [Test]
        public void Question2_Configure_Board
         ([Values(4)] int length, [Values(4)] int height)
        {
            var configureBoard = _universeManager.ConfigureBoard(length, height);
            Assert.IsTrue(true);
        }

        [Test]
        public void Question2_BoardSizes_Cannot_Equal_Zero_ThrowsExcpetion
       ([Values(0)] int length, [Values(0)] int height)
        {
            var ex = Assert.Throws<Exception>(() => _universeManager.ConfigureBoard(length, height));
            Assert.That(ex.Message == "Board length or heigh cannot be Zero");
        }

        [Test]
        public void Question2_ConfigureUniverse_Load_Cells
         ([Values(4)] int length, [Values(4)] int height, [Values(3)] int generationKey )
        {
            var configureBoard = _universeManager.ConfigureBoard(length, height);
            _universeManager.ConigureUniversGeneration(generationKey);

            var createCells = _universeManager.LoadCells();
            Assert.IsTrue(createCells);
        }


        [Test]
        public void Question2_Create_Universe_File_For_Printing()
        {
            _fileManager.CreateFile();
            Assert.Pass();
        }

        [Test]
        [TestCase(3, 7,3)]
        [TestCase(2, 5,4)]
        [TestCase(2, 3,2)]
        public void Question2_Write_Universe_Cycle_to_File (int length,  int height, int generationKey)
        {
            var configureBoard = _universeManager.ConfigureBoard(length, height);
            _universeManager.ConigureUniversGeneration(generationKey);

            var createCells = _universeManager.LoadCells();
            _universeManager.RunUniverseLivespan();
            Assert.IsTrue(createCells);
        }



    }
}
