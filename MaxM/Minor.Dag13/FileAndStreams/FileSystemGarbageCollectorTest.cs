using FileSystemGarbageCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace FileAndStreams
{
    [TestClass]
    public class FileSystemGarbageCollectorTest
    {

        [TestMethod]
        public void NotRootedPathExceptieBijRelatiefPath()
        {
            // Arrange
            var target = new HomeController(new ConsoleReaderMock(@"~/testfolder"), new ConsoleWriter());

            // Act and Assert
            Assert.ThrowsException<NotRootedPathException>(() => target.RequestPath());
        }

        [TestMethod]
        public void NotRootedPath1()
        {
            // Arrange
            var target = new HomeController(new ConsoleReader(), new ConsoleWriter());

            // Act
            var result = target.PathIsRooted(@"../../Test/Path");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NotRootedPath2()
        {
            // Arrange
            var target = new HomeController(new ConsoleReader(), new ConsoleWriter());

            // Act
            var result = target.PathIsRooted(@"~/Test/Path");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DirectoryRooted()
        {
            // Arrange
            var target = new HomeController(new ConsoleReader(), new ConsoleWriter());

            // Act
            var result = target.PathIsRooted(@"C:\Test\Path");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DirectoryBestaatNietExceptie1()
        {
            // Arrange

            var target = new HomeController(new ConsoleReaderMock(@"C:\Niet\Bestaande\Folder"), new ConsoleWriter());

            // Act and Assert
            Assert.ThrowsException<NonExistingDirectoryException>(() => target.RequestPath());
        }

        [TestMethod]
        public void DirectoryBestaatNietExceptie2()
        {
            // Arrange
            var target = new HomeController(new ConsoleReaderMock(@"C:\Niet\Bestaande\Folder"), new ConsoleWriter());

            // Act and Assert
            Assert.ThrowsException<NonExistingDirectoryException>(() => target.RequestPath());
        }

        [TestMethod]
        public void DirectoryBestaat()
        {
            // Arrange
            var crm = new ConsoleReaderMock(@"C:\FileSystemGarbageCollectorTest");

            var target = new HomeController(crm, new ConsoleWriter());
            Directory.CreateDirectory(crm.Path);

            // Act
            try
            {
                target.RequestPath();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no expection but got:" + ex);
            }

            // Cleanup
            Directory.Delete(crm.Path);
        }

        [TestMethod]
        public void KanVsFolderVinden()
        {
            // Arrange
            var crm = new ConsoleReaderMock(@"C:\FileSystemGarbageCollectorTest");

            var target = new HomeController(crm, new ConsoleWriter());
            // Create root directory
            Directory.CreateDirectory(crm.Path);

            // Create hidden .vs directory in root directory
            var vsFolderPath = crm.Path + @"\.vs";
            DirectoryInfo vsDi = Directory.CreateDirectory(vsFolderPath);
            vsDi.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            // Act
            var result = target.GetVsDirectory(crm.Path).FirstOrDefault();

            // Assert
            Assert.AreEqual(vsDi.FullName, result.FullName);

            // Cleanup
            DirectoryInfo di = new DirectoryInfo(crm.Path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(crm.Path);
        }

        [TestMethod]
        public void KanMeerdereVsFolderVinden()
        {
            // Arrange
            var crm = new ConsoleReaderMock(@"C:\FileSystemGarbageCollectorTest");

            var target = new HomeController(crm, new ConsoleWriter());
            // Create root directory
            Directory.CreateDirectory(crm.Path);

            // Create hidden .vs directory in root directory
            var vsFolderPath1 = crm.Path + @"\.vs";
            DirectoryInfo vsDi1 = Directory.CreateDirectory(vsFolderPath1);
            vsDi1.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            var vsFolderPath2 = crm.Path + @"\Extra\.vs";
            DirectoryInfo vsDi2 = Directory.CreateDirectory(vsFolderPath2);
            vsDi2.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            // Act
            var result = target.GetVsDirectory(crm.Path);

            // Assert
            Assert.AreEqual(2, result.Count());

            // Cleanup
            DirectoryInfo di = new DirectoryInfo(crm.Path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(crm.Path);    
        }
    }
}
