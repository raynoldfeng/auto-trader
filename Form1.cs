using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AutoTrader
{
  
    public partial class Form1 : Form
    {


        CookieContainer m_cookie = new CookieContainer();
        

        public Form1()
        {
            InitializeComponent();
          
            this.Browser.Navigate("https://etrade.newone.com.cn/newtrade/index.jsp");
        }
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x888)
            {
                try
                {
                    HtmlElement menu = Browser.Document.GetElementById("botrigy");
                    HtmlElement title = Browser.Document.GetElementById("jy_title");
                    if (menu != null)
                    {
                        menu.Children[0].Children[0].InvokeMember("click");
                    }
                }
                catch (Exception e)
                {

                }
            }
            base.WndProc(ref msg);
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        }
        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box.   
            e.Handled = true;
        }
    }
}
