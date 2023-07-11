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

namespace Project21WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Contact contactHighlight;
        public MainWindow()
        {
            InitializeComponent();
            ContactDataApi context = new ContactDataApi();
            try
            {
                DataGridView.ItemsSource = context.GetContacts().ToObservableCollection();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            RefreshButton.Click += delegate { DataGridView.ItemsSource = context.GetContacts().ToObservableCollection(); };
            AddButton.Click += delegate
            {
                Contact contact = new Contact()
                {
                    Name = "",
                    Surname = "",
                    FatherName = "",
                    TelephoneNumber = "",
                    ResidenceAdress = "",
                    Description = ""
                };
                AddContactWindow addContactWindow = new AddContactWindow(contact);
                addContactWindow.ShowDialog();

                if (addContactWindow!=null && addContactWindow.DialogResult.Value)
                {
                    context.AddContacts(contact);
                    DataGridView.ItemsSource = context.GetContacts().ToObservableCollection();
                    DataGridView.Items.Refresh();
                }
            };

            DeleteButton.Click += delegate
            {
                if((Contact)DataGridView.SelectedItem != null)
                {
                    contactHighlight = (Contact)DataGridView.SelectedItem;
                    context.DeleteContact(contactHighlight.ID);
                    DataGridView.ItemsSource = context.GetContacts().ToObservableCollection();
                    DataGridView.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Контакт не выбран");
                }
                    
            };

            DetailsButton.Click += delegate
            {
                if ((Contact)DataGridView.SelectedItem != null)
                {
                    contactHighlight = (Contact)DataGridView.SelectedItem;
                    Contact contact = new Contact()
                    {
                        Name = "",
                        Surname = "",
                        FatherName = "",
                        TelephoneNumber = "",
                        ResidenceAdress = "",
                        Description = ""
                    };
                    contact = context.FindContactById(contactHighlight.ID);
                    DetailsWindow detailsWindow = new DetailsWindow(contact);
                    detailsWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Контакт не выбран");
                }
            };

            ContactChangeButton.Click += delegate
            {
                if ((Contact)DataGridView.SelectedItem != null)
                {
                    contactHighlight = (Contact)DataGridView.SelectedItem;
                    Contact contact = new Contact()
                    {
                        Name = contactHighlight.Name,
                        Surname = contactHighlight.Surname,
                        FatherName = contactHighlight.FatherName,
                        TelephoneNumber = contactHighlight.TelephoneNumber,
                        ResidenceAdress = contactHighlight.ResidenceAdress,
                        Description = contactHighlight.Description
                    };
                    try
                    {
                        ChangeContactWindow changeContactWindow = new ChangeContactWindow(contact);
                        changeContactWindow.ShowDialog();
                        if (changeContactWindow.DialogResult.Value)
                        {
                            context.ChangeContact(contact.Name, contact.Surname,
                                contact.FatherName, contact.TelephoneNumber,
                                contact.ResidenceAdress, contact.Description,
                                contactHighlight.ID);
                            DataGridView.ItemsSource = context.GetContacts().ToObservableCollection();
                            DataGridView.Items.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Контакт не выбран");
                }
            };
        }
    }
}
