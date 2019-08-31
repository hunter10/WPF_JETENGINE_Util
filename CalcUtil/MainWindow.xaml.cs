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

namespace CalcUtil
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model currModel;
        private CompressType currType;

        public MainWindow()
        {
            InitializeComponent();

            currType = CompressType.NONE;
            currModel = Model.NONE;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(currType == CompressType.NONE)
            {
                MessageBox.Show("컴프레스 타입을 정해주세요.");
                return;
            }

            double d2 = double.Parse(txtBox_D2.Text);
            double h = double.Parse(txtBox_H.Text);

            Turbine turbine = null;
            if (currType == CompressType.Retro_Curved)
            {
                turbine = new RetroCurved_Turbine();
            }
            else if (currType == CompressType.Retro_Curved)
            {
                turbine = new RadiallyTipped_Turbine();
            }

            turbine.Init("", currType, h, d2);

            //lb_D3_val.Content = 1.12 * d2;
            //lb_D4_val.Content = 1.67 * d2;
            //lb_F_val.Content = Math.Sqrt(3030 * d2 * h);

            //double a = Math.Pow(d2, 2);
            //double b = 6.8 * d2 * h;
            //lb_Di_val.Content = Math.Sqrt(a - b);

            lb_D3_val.Content = turbine.D3();
            lb_D4_val.Content = turbine.D4();
            lb_F_val.Content = turbine.F();
            lb_Di_val.Content = turbine.Di();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = combo_compressType.SelectedIndex;
            switch(idx)
            {
                case 0: currType = CompressType.Retro_Curved; break;
                case 1: currType = CompressType.Radially_Tipped; break;
            }
        }
    }
}
