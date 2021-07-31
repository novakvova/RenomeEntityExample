using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(AddUsersThread);
            thread.Start();
            Debug.WriteLine("Main id "+Thread.CurrentThread.ManagedThreadId);
        }
        private void AddUsersThread()
        {
            Debug.WriteLine("Other id "+Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(200);
                Dispatcher.Invoke(() =>
                {

                    lblInfo.Content = i + 1;
                });

            }
        }
    }
}
