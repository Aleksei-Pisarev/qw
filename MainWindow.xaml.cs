using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Wpf_PR_12_2_Pisarev.ApplicationData;
using Wpf_PR_12_2_Pisarev.PageMain;

namespace Wpf_PR_12_2_Pisarev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelOdb = new firstEntities();
            AppFrame.frameMain = FrmMain;

            FrmMain.Navigate(new PageLogin());
        }
    }
}
