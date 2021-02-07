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
        public Prog()
        {
            InitializeComponent();
        }

       private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button) e.OriginalSource).Content;
            
            if (str == "C")
                TextBlock.Content = "";
            
            else if (str == "=")
            {
                TextBlock.Content = new Expression(TextBlock.Content.ToString()).calculate();
                
            }
            else
                TextBlock.Content += str;
        }
        private void Backspace_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBlock.Content.ToString() != "")
            {
                TextBlock.Content = TextBlock.Content.ToString().Substring(0, TextBlock.Content.ToString().Length- 1);
            }
            else
            {
                TextBlock.Content = "0";
            }
        }
        
        
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Percent_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock.Content = new Expression(TextBlock.Content.ToString()).calculate();
            TextBlock.Content = Convert.ToInt32(TextBlock.Content) / 100;
        }

        private void PlusMinus_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock.Content = new Expression(TextBlock.Content.ToString()).calculate();
            TextBlock.Content = Convert.ToInt32(TextBlock.Content) * -1;
        }


        private void AC_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock.Content = "";
        }

        private void SQRT_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock.Content = new Expression(TextBlock.Content.ToString()).calculate();
            TextBlock.Content = Math.Sqrt(Convert.ToDouble(TextBlock.Content));
        }
        
        private void OneDivX_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock.Content = new Expression(TextBlock.Content.ToString()).calculate();
            TextBlock.Content = 1 / Convert.ToDouble(TextBlock.Content);
        }


        private void MainCalc_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            
            this.Close();
        }
    }
}