using ContactManagementSystem.Entities;
using ContactManagementSystem.Enums;
using ContactManagementSystem.Services.Classes;
using ContactManagementSystem.Services.Interfaces;
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

namespace ContactManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IJsonService<ContactEntity> _jsonService;
        private List<ContactEntity> _contacts;
        public MainWindow(IJsonService<ContactEntity> jsonService)
        {
            _jsonService = jsonService;
            InitializeComponent();
        }

        public MainWindow() : this(new JsonService<ContactEntity>("contacts"))
        {
            InitializeComponent();

        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _contacts = await _jsonService.GetAllContactsAsync();
            lvContacts.ItemsSource = _contacts;
            cmbOrder.ItemsSource = Enum.GetValues(typeof(OrderType)).Cast<OrderType>();
        }

        private  void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var textAsLower = txtSearch.Text.ToLower().Replace(" ", "");
                lvContacts.DataContext = null;
                lvContacts.ItemsSource = _contacts.Where(x =>
            x.Name.Replace(" ", "").ToLower().Contains(textAsLower) ||
            x.Phone.Contains(textAsLower) || x.Email.Contains(textAsLower));
            } else
            {
                lvContacts.ItemsSource = _contacts;
            }
        }

        private void lvContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOrder.SelectedIndex >= 0)
            {
                lvContacts.DataContext = null;           
                var orderDictionary = new Dictionary<OrderType, Func<List<ContactEntity>>>()
                {
                    {OrderType.Name, () => _contacts.OrderBy(x => x.Name).ToList() },
                    {OrderType.Email, () =>  _contacts.OrderBy(x => x.Email).ToList() },
                    {OrderType.Phone, () => _contacts.OrderBy(x => x.Phone).ToList() },
                };
                var orderType = (OrderType)cmbOrder.SelectedItem;
                if (orderDictionary.TryGetValue(orderType, out var orderFunction))
                {
                    lvContacts.ItemsSource = orderFunction.Invoke();
                }
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvContacts.SelectedItems != null)
            {
                var contact = lvContacts.SelectedValue as ContactEntity;
                await _jsonService.DeleteDataAsync(contact.Id);
                _contacts = await _jsonService.GetAllContactsAsync();
                lvContacts.DataContext = null;
                lvContacts.ItemsSource = _contacts;
                if (_contacts.Contains(contact))
                {
                    MessageBox.Show("Failed to delete contact.");
                } else
                {
                    MessageBox.Show("Succesfully removed contact.");
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var updateForm = new Create(_jsonService);
            updateForm.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvContacts.SelectedItems != null)
            {
                var contact = lvContacts.SelectedValue as ContactEntity;
                var createForm = new UpdateForm(contact, _jsonService);
                createForm.Show();
                this.Hide();
            }
      
        }
    }
}
