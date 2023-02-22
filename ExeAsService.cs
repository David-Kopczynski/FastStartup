using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using murrayju.ProcessExtensions;

namespace ExeAsService
{
    public partial class ExeAsService : ServiceBase
    {
        public ExeAsService()
        {
            // Allow OnSessionChange Event Handling
            CanHandleSessionChangeEvent = true;

            InitializeComponent();
        }

        /**
         * Start basic autolaunch functionalities
         */
        protected override void OnStart(string[] args)
        {
            if (args.Length != 0)
            {
                // Check start mode
                switch (args[0])
                {
                    case "install":
                        OnUserLogin();
                        break;

                    default:
                        break;
                }
            }

            base.OnStart(args);
        }

        /**
         * Handle session changes
         */
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:

                    // Check if session login and call handler
                    OnUserLogin();
                    break;

                default:
                    break;
            }

            base.OnSessionChange(changeDescription);
        }

        /**
         * Start Autostart handler when user login is detected
         */
        public void OnUserLogin()
        {
            //string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //ProcessExtensions.StartProcessAsCurrentUser("C:\\Program Files (x86)\\David Kopczynski\\Fast Startup\\Autolaunch.exe");
            ProcessExtensions.StartProcessAsCurrentUser($@"{AppDomain.CurrentDomain.BaseDirectory}\Autolaunch.exe");
        }
    }
}
