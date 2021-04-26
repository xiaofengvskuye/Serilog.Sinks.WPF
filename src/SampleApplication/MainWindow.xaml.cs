using System.Windows;

using Serilog;
using Serilog.Sinks.WPF;

namespace SampleApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly LoggerConfiguration LogCtl = null;
        public MainWindow()
        {
            InitializeComponent();
            LogCtl = new LoggerConfiguration();
            Log.Logger = LogCtl.WriteToSimpleTextBox().CreateLogger();

            Log.Information("Logger has been created");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Log.Information(inputTxt.Text);
            //inputTxt.Text = string.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogCtl.LoggerClear();
        }
    }
}
