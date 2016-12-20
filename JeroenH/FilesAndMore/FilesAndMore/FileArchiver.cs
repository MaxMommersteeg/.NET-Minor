using System;
using System.IO;
using System.Text;
using System.Threading;


namespace FilesAndMore
{
    public class FileArchiver
    {
        public bool HasChanged { get; set; }
        public bool HasCreated { get; set; }

        public string FileContent { get; set; }

        public string VolledigPad { get; set; }
        public FileArchiver()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"C:/TFS/JeroenH/TestingFolderFilesAndMore";
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "*.txt";
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Changed += new FileSystemEventHandler(OnChanged);

                watcher.EnableRaisingEvents = true;

                VolledigPad = watcher.Path;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            VolledigPad = e.FullPath;
            HasCreated = true;
            string fileName = VolledigPad.Substring(VolledigPad.LastIndexOf('/')+1);
            string directoryValue = VolledigPad.Substring(0, VolledigPad.LastIndexOf('/'));
            File.Copy(VolledigPad, Path.Combine(directoryValue, "Archive/", fileName), true);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            VolledigPad = e.FullPath;
            Thread.Sleep(100);

            string fileName = VolledigPad.Substring(VolledigPad.LastIndexOf('/') + 1);
            string directoryValue = VolledigPad.Substring(0, VolledigPad.LastIndexOf('/'));
            File.Copy(VolledigPad, Path.Combine(directoryValue, "Archive/", fileName), true);
            FileContent = File.ReadAllText(VolledigPad).Trim();


            HasChanged = true;
        }



    }
}


