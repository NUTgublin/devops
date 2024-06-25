using Beast.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Beast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbHandler db = new DbHandler();
        string NewKleur = "";
        int NewValue = 0;
        int ID = 0;
        string selcolor = "";
        int selectedrow = 0;
        Random _myRandom = new Random();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ReadValue();
            db.AddNew(NewKleur, NewValue);
            
        }

        private void btnR_Click(object sender, RoutedEventArgs e)
        {
            readFromDatabase();
        }

        private void readFromDatabase()
        {
            DataTable result = db.GetNumber();
            tbNumber.Text = result.Rows[selectedrow]["data"].ToString();
            selcolor = result.Rows[selectedrow]["kleur"].ToString();
            tbNumber.Background = db.brush(selcolor);
            dt.ItemsSource = result.DefaultView;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ReadValue();
            db.UpdateNumber(NewKleur, NewValue, ID);
            
        }

        private void ReadValue()
        {
           NewValue = Convert.ToInt32(tb.Text);
           NewKleur = myComboBox.Text;
           ID = Convert.ToInt32(tb2.Text);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            NewValue = Convert.ToInt32(tb2.Text);
            db.Delete(NewValue);
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            DataTable result = db.GetNumber();
            selectedrow = _myRandom.Next(0, result.Rows.Count);
            readFromDatabase();

        }
    }
}
