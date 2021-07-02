using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RemoveKaseya2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(@"c:\Program Files (x86)\Kaseya\", "k*", SearchOption.TopDirectoryOnly);
                Console.WriteLine("The number of directories starting with k is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    var result = dir.Substring(dir.LastIndexOf('\\') + 1);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    string strCmdText = "/c \"C:\\Program Files (x86)\\Kaseya\\" + result + "\\KASetup.exe\" /s /r /g " + result + " /l %TEMP%\\karemoval.log";
                    Console.WriteLine(strCmdText);
                    startInfo.Arguments = strCmdText;
                    process.StartInfo = startInfo;
                    process.Start();
                    Console.WriteLine(dir);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
