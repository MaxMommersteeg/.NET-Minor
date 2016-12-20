using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FilesAndMore;
using System.Diagnostics;
using System.Threading;

namespace FilesAndMoreTesting
{
    [TestClass]
    public class FilesTesting
    {

        [TestMethod]
        public void FileCreatedEvent()
        {
            //Arrange
            string filePath = @"C:/TFS/JeroenH/TestingFolderFilesAndMore/FileCreatedEvent.txt";


            FileArchiver fileArchiver = new FileArchiver();




            //Act
            StreamWriter sw = File.CreateText(filePath);
            Thread.Sleep(200);
            

            bool result = fileArchiver.HasCreated;

            //Assert
            Assert.IsTrue(result);

            //Garbage Collection

            sw.Dispose();

            Thread.Sleep(100);

            File.Delete(filePath);

            Thread.Sleep(100);


        }

        [TestMethod]
        public void FileCreateAndRead()
        {
            //Arrange
            string filePath = @"C:/TFS/JeroenH/TestingFolderFilesAndMore/FileCreateAndRead.txt";

            FileArchiver fileArchiver = new FileArchiver();

            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine("Bla bla");
            }


            Thread.Sleep(1000);


            //Act
            var result = fileArchiver.FileContent;

            //Assert
            Assert.AreEqual("Bla bla", result);
            Assert.IsTrue(fileArchiver.HasChanged);

            //Garbage Collection
            Thread.Sleep(100);

            File.Delete(filePath);

            Thread.Sleep(100);

        }

        [TestMethod]
        public void FileCreateAndCopyToArchiveFolder()
        {
            //Arrange
            string filePath = @"C:/TFS/JeroenH/TestingFolderFilesAndMore/FileCreateAndCopyToArchiveFolder.txt";

            FileArchiver fileArchiver = new FileArchiver();

            using (StreamWriter sw = File.CreateText(filePath))
            {
                Thread.Sleep(100);

                sw.WriteLine("Bla bla");
            }

            string date = DateTime.Now.Date.ToString();
            Thread.Sleep(1000);


            //Act


            //Assert
            //Assert.IsTrue(File.Exists($"C:/TFS/JeroenH/TestingFolderFilesAndMore/FileCreateAndRead_{date}/FileCreateAndRead.txt"));

            //Garbage Collection
            Thread.Sleep(100);
            File.Delete(filePath);

            //File.Delete($"C:/TFS/JeroenH/TestingFolderFilesAndMore/Archive/FileCreateAndRead_{date}.txt");

            Thread.Sleep(100);

        }




    }
}
