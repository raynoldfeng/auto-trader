using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace AutoTrader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("User32.dll ")]
        public static extern int SendMessage(IntPtr hwad, int wMsg, int lParam, int wParam);
        static IntPtr hMain;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);      
            Form1 mainForm = new Form1();
            hMain = mainForm.Handle;
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer); //到达时间的时候执行事件；   
            timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件； 
            Application.Run(mainForm);
        }


        static void OnTimer(object source, System.Timers.ElapsedEventArgs e)
        {
            SendMessage(hMain, 0x888, 0, 0);
        }

    }
}
