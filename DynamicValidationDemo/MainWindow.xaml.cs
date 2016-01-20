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

namespace DynamicValidationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p = new Person();
        public MainWindow()
        {
            InitializeComponent();

           // CreateTextBox();

            this.DataContext = p;
        }

        private void CreateTextBox()
        {
            TextBox txtBox = new TextBox();
            txtBox.FontSize = 18;
            txtBox.Width = 180;
            txtBox.VerticalAlignment = VerticalAlignment.Center;
            txtBox.HorizontalAlignment = HorizontalAlignment.Center;
            txtBox.LostFocus += txtBox_LostFocus;


            //Validation v = new Validation();

            //Binding valBinding = new Binding();


            //valBinding.Path = new System.Windows.PropertyPath("Text");

            //valBinding.ValidatesOnDataErrors = true;

            //valBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            //valBinding.Source = TextBox.TextProperty;

            //valBinding.ValidationRules.Add(v);

            //txtBox.SetBinding(TextBox.TextProperty, valBinding);




            Grid.SetColumn(txtBox, 0);

            Grid.SetRow(txtBox, 1);

            GridList.Children.Add(txtBox);
        }

        void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;

            Validation v = new Validation();

            ValidationResult r = v.Validate(txt.Text, null);

            if (!r.IsValid)
            {
                txt.Text = r.ErrorContent.ToString();
            }

            string s;
        }

        void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;

            BindingExpression bind = txt.GetBindingExpression(TextBox.TextProperty);
            bind.UpdateSource();

            ValidationError error = new ValidationError(bind.BindingGroup.ValidationRules[0], txt.GetBindingExpression(TextBox.TextProperty));

            string s;
        }

        private void BTN_Clicked(object sender, RoutedEventArgs e)
        {
            IsNullValidationRule1 isnullRule = new IsNullValidationRule1();


            ValidationResult result = isnullRule.Validate(this.txtOther.Text, null);


            if (!result.IsValid)
            {
                this.txtOther.Text = result.ErrorContent.ToString();


                return;
            }  
        }

        void TextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (tb != null)
            {
                tb.Text = tb.Text;
            }
        } 
    }
}
