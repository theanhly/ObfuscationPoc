using BlazorServerApp;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.ToString());
                File.AppendAllText("log.txt", sb.ToString());
                sb.Clear();
            }

            this.Loaded += WindowLoaded;
        }

        internal void WindowLoaded(object sender, EventArgs args)
        {
            try
            {
                WebServer webServer = new WebServer();
                webServer.StartServer<Startup>(null);
                webView2.Source = new Uri("https://localhost:1234");
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.ToString());
                File.AppendAllText("log.txt", sb.ToString());
                sb.Clear();
            }
        }
    }
}