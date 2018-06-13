using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace ThreadWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UIStart(true);
            Thread thread = new Thread(UpdateTextWrong);
            thread.Start();
        }


        private void UpdateTextWrong()
        {
            // Эмулирует некоторую работу посредством пятисекундной задержки
            Thread.Sleep(TimeSpan.FromSeconds(5));


            // Получить диспетчер от текущего окна и использовать его для вызова кода обновления

            Delegate dg = (ThreadStart)delegate () { MyMethod(); };
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, dg);
        }

        private void MyMethod()
        {
            UIStart(false);
        }

        private void UIStart(bool starting)
        {
            if (starting)
            {
                txb.Text = "Start: " + DateTime.Now.ToString("hh:mm:ss");
                txb2.Text = "End: ";
                Prb.Visibility = Visibility.Visible;
                Btn.IsEnabled = false;
                Btn.Content = "Processing...";
            }
            else
            {
                txb2.Text = "End: " + DateTime.Now.ToString("hh:mm:ss");
                Prb.Visibility = Visibility.Hidden;
                Btn.IsEnabled = true;
                Btn.Content = "Start";
            }
        }
    }
}
