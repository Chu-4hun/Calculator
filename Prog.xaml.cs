using System.Windows;
using static WpfApplication1.MainWindow;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using static WpfApplication1.Prog;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace WpfApplication1
{
    public partial class Prog : Window
    {
        public int number_system = 10;
        public string dev;
        public string n1;
        public bool n2;
        public Prog()
        {
            InitializeComponent();
        }

       private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button) e.OriginalSource).Content;

            if (str == "CL")
            {
                OutputlaLabel.Content = "";
                HEXlabel.Content = "";
                DEClabel.Content = "";
                OCTlabel.Content = "";
                BINlabel.Content = "";
            }
                
            
            else if (str == "=")
            {
                double res = new Expression(OutputlaLabel.Content.ToString()).calculate();
                OutputlaLabel.Content = res;
                HEXlabel.Content = Conv(10,16,res.ToString());
                DEClabel.Content = Conv(10,10,res.ToString());
                OCTlabel.Content = Conv(10,8,res.ToString());
                BINlabel.Content = Conv(10,2,res.ToString());

            }
            else
                OutputlaLabel.Content += str;
        }
        private void Backspace_OnClick(object sender, RoutedEventArgs e)
        {
            if (OutputlaLabel.Content.ToString() != "")
            {
                OutputlaLabel.Content = OutputlaLabel.Content.ToString().Substring(0, OutputlaLabel.Content.ToString().Length- 1);
            }
            else
            {
                OutputlaLabel.Content = "0";
            }
        }
        
        
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Percent_OnClick(object sender, RoutedEventArgs e)
        {
            OutputlaLabel.Content = new Expression(OutputlaLabel.Content.ToString()).calculate();
            OutputlaLabel.Content = Convert.ToInt32(OutputlaLabel.Content) / 100;
        }

        private void PlusMinus_OnClick(object sender, RoutedEventArgs e)
        {
            OutputlaLabel.Content = new Expression(OutputlaLabel.Content.ToString()).calculate();
            OutputlaLabel.Content = Convert.ToInt32(OutputlaLabel.Content) * -1;
        }


        private void AC_OnClick(object sender, RoutedEventArgs e)
        {
            OutputlaLabel.Content = "";
        }

        private void SQRT_OnClick(object sender, RoutedEventArgs e)
        {
            OutputlaLabel.Content = new Expression(OutputlaLabel.Content.ToString()).calculate();
            OutputlaLabel.Content = Math.Sqrt(Convert.ToDouble(OutputlaLabel.Content));
        }
        
        private void OneDivX_OnClick(object sender, RoutedEventArgs e)
        {
            OutputlaLabel.Content = new Expression(OutputlaLabel.Content.ToString()).calculate();
            OutputlaLabel.Content = 1 / Convert.ToDouble(OutputlaLabel.Content);
        }


        private void MainCalc_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            
            this.Close();
        }
        private string Conv(int From, int To, string Numbers)
        {
            Numbers = Numbers.Trim();
            if (Numbers == string.Empty) return string.Empty;
            string[] buf = Numbers.Split(' ');
            string Out = "";

            foreach (string s in buf)
            {
                try
                {
                    Out = Out + Convert.ToString(Convert.ToInt64(s, From), To) + " ";
                }
                catch
                {
                    Out = Out + Convert.ToString(Int64.MaxValue, To) + " ";
                }
            }

            return Out.Trim();
        }

        private void HEX_button(object sender, RoutedEventArgs e)
        {
            number_system = 16;
            A_btn.IsEnabled  = true;
            B_btn.IsEnabled  = true;
            C_btn.IsEnabled  = true;
            D_btn.IsEnabled  = true;
            E_btn.IsEnabled  = true;
            F_btn.IsEnabled  = true;
            
            one_butn.IsEnabled = true;
            two_butn.IsEnabled = true;
            three_butn.IsEnabled = true;
            four_butn.IsEnabled = true;
            five_butn.IsEnabled = true;
            six_butn.IsEnabled = true;
            seven_butn.IsEnabled = true;
            eigth_butn.IsEnabled = true;
            nine_butn.IsEnabled = true;
            zero_butn.IsEnabled = true;
        }

        private void DEC_button(object sender, RoutedEventArgs e)
        {
            number_system = 10;
            A_btn.IsEnabled  = false;
            B_btn.IsEnabled  = false;
            C_btn.IsEnabled  = false;
            D_btn.IsEnabled  = false;
            E_btn.IsEnabled  = false;
            F_btn.IsEnabled  = false;
            
            one_butn.IsEnabled = true;
            two_butn.IsEnabled = true;
            three_butn.IsEnabled = true;
            four_butn.IsEnabled = true;
            five_butn.IsEnabled = true;
            six_butn.IsEnabled = true;
            seven_butn.IsEnabled = true;
            eigth_butn.IsEnabled = true;
            nine_butn.IsEnabled = true;
            zero_butn.IsEnabled = true;
        }

        private void OCT_button(object sender, RoutedEventArgs e)
        {
            number_system = 8;
            A_btn.IsEnabled  = false;
            B_btn.IsEnabled  = false;
            C_btn.IsEnabled  = false;
            D_btn.IsEnabled  = false;
            E_btn.IsEnabled  = false;
            F_btn.IsEnabled  = false;
            
            one_butn.IsEnabled = true;
            two_butn.IsEnabled = true;
            three_butn.IsEnabled = true;
            four_butn.IsEnabled = true;
            five_butn.IsEnabled = true;
            six_butn.IsEnabled = true;
            seven_butn.IsEnabled = true;
            eigth_butn.IsEnabled = true;
            nine_butn.IsEnabled = false;
            zero_butn.IsEnabled = true;
        }

        private void BIN_button(object sender, RoutedEventArgs e)
        {
            number_system = 2;
            A_btn.IsEnabled  = false;
            B_btn.IsEnabled  = false;
            C_btn.IsEnabled  = false;
            D_btn.IsEnabled  = false;
            E_btn.IsEnabled  = false;
            F_btn.IsEnabled  = false;
            
            one_butn.IsEnabled = true;
            two_butn.IsEnabled = false;
            three_butn.IsEnabled = false;
            four_butn.IsEnabled = false;
            five_butn.IsEnabled = false;
            six_butn.IsEnabled = false;
            seven_butn.IsEnabled = false;
            eigth_butn.IsEnabled = false;
            nine_butn.IsEnabled = false;
            zero_butn.IsEnabled = true;
        }
        
    }
}