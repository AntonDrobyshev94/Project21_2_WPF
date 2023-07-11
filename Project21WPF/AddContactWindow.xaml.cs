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
using System.Windows.Shapes;

namespace Project21WPF
{
    /// <summary>
    /// Логика взаимодействия для AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        private AddContactWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Публичный конструктор, принимающий экземпляр контакта
        /// contact. При нажатии на кнопку CancelButton происходит 
        /// вызов события отмены изменений и возврат в меню с 
        /// присвоением переменной DialogResult значения false. 
        /// При нажатии CreateButton происходит вызов события
        /// "добавление контакта", в результате которого значения,
        /// записанные в поля TextBox записываются в значения
        /// параметров контакта и DialogResult принимает значение true.
        /// </summary>
        /// <param name="contact"></param>
        public AddContactWindow(Contact contact):this()
        {
            CancelButton.Click += delegate { this.DialogResult = false; };
            CreateButton.Click += delegate
            {
                try
                {
                    contact.Name = TxtName.Text;
                    contact.Surname = TxtSurname.Text;
                    contact.FatherName = TxtFatherName.Text;
                    contact.TelephoneNumber = TxtTelephoneNumber.Text;
                    contact.ResidenceAdress = TxtAdress.Text;
                    contact.Description = TxtDescription.Text;
                    this.DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
            };
        }
    }
}
