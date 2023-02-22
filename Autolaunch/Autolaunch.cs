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
            /*Process p = new Process();

            p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.FileName = "C:\\Program Files\\Prismatik\\Prismatik.exe";
            p.StartInfo.FileName = "C:\\Users\\david\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\Prismatik.lnk";

            p.Start();*/

            /*ProcessStartInfo process = new ProcessStartInfo();

            process.RedirectStandardOutput = true;
            process.UseShellExecute = false;
            process.CreateNoWindow = true;
            process.WindowStyle = ProcessWindowStyle.Hidden;
            process.WindowStyle = ProcessWindowStyle.Minimized;

            process.FileName = "cmd.exe";
            process.Arguments = "/c start \"\" \"C:\\Program Files\\Prismatik\\Prismatik.exe\"";

            Process.Start(process);*/

            /*using (Process process = new Process())
            {
                process.StartInfo.FileName = @"cmd.exe";
                process.StartInfo.Arguments = "/c start \"\" \"C:\\Program Files\\Prismatik\\Prismatik.exe\"";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
            }*/

            DirectoryInfo di = new DirectoryInfo(targetDirectory);

            if (di.Exists)
            {
                FileInfo[] files = di.GetFiles();

                foreach (FileInfo file in files)
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", $@"{targetDirectory}\{file}"));
                }
            }

            /*ProcessStartInfo  processInfo = new ProcessStartInfo("cmd.exe", "/c " + "start \"C:\\Program Files\\Prismatik\\Prismatik.exe\"");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            Process process = Process.Start(processInfo);

            process.WaitForExit();
            process.Close();*/
        }
    }
}
