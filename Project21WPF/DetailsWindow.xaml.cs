using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Project21WPF
{
    /// <summary>
    /// Логика взаимодействия для DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private DetailsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Публичный конструктор, принимающий экземпляр контакта
        /// contact, в котором происходит биндинг полей контакта
        /// в DataGridView. Контакт записывается в ObservableCollection
        /// с помощью второй перегрузки метода ToObservableCollection.
        /// </summary>
        /// <param name="contact"></param>
        public DetailsWindow(Contact contact) : this()
        {
            DetailsDataGridView.ItemsSource = contact.ToObservableCollection();
            BackToMenuButton.Click += delegate { this.DialogResult = false; };
        }
    }
}
