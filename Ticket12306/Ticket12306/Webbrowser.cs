using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ticket12306
{
    public partial class Webbrowser : Form
    {
        public Webbrowser(string url)
        {
            InitializeComponent();
            this.webBrowser1.Navigate(url);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                this.Text = webBrowser1.Document.Title;
            }
        }
    }
}
