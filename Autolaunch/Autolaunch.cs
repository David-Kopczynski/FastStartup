using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autolaunch
{
    internal class Autolaunch
    {
        static readonly string targetDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Programs)}\Startup Fast";

        /**
         * Entry for Autolaunch application that is booting executables upon startup
         */
        static void Main(string[] args)
        {
            CreateFastStartupFolder();
            Autostart();
        }

        /*
         * Create Fast Startup folder and open for current user
         */
        static public void CreateFastStartupFolder()
        {
            DirectoryInfo di = new DirectoryInfo(targetDirectory);

            if (!di.Exists)
            {
                Directory.CreateDirectory(targetDirectory);
                Process.Start(fileName: "explorer.exe", targetDirectory);
            }
        }

        /**
         * Autolaunch applications that are inside the Fast Starutp folder
         */
        static public void Autostart()
        {
            DirectoryInfo di = new DirectoryInfo(targetDirectory);

            if (di.Exists)
            {
                FileInfo[] files = di.GetFiles();

                foreach (FileInfo file in files)
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", $@"{targetDirectory}\{file}"));
                }
            }
        }
    }
}
