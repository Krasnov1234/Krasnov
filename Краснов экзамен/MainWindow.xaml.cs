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

namespace Краснов_экзамен
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        КинотеатрEntities db = new КинотеатрEntities();
        buyer bu = new buyer();
        public MainWindow()
        {
            InitializeComponent();
            Number.ItemsSource = db.places.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bu.Name = Name.Text;
            bu.Surname = Surname.Text;
            bu.Midlname = Midlname.Text;
            bu.number = Convert.ToInt32( Number.Text);
            if(db.buyer.Select(i=>i.number.ToString()).Contains(Number.Text))
            {
                MessageBox.Show("Место занято выберете другое");
            }
            else 
            {
                MessageBox.Show("Место выбрано");
                db.buyer.Add(bu);
                db.SaveChanges();
            }


        }
    }
}
