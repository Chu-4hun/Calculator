using System.Data;
using System.Windows;
using System.Windows.Controls;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace WpfApplication1
{
 
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainGrid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button) e.OriginalSource).Content;

            if (str == "AC")
                TextBlock.Content = "";
            else if (str == "=")
            {
                //TextBlock.Content = new DataTable().Compute(TextBlock.Content.ToString(),null).ToString();
                TextBlock.Content = new Expression(TextBlock.Content.ToString()).calculate().ToString();
                
            }
            else
                TextBlock.Content += str;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }
    }
}