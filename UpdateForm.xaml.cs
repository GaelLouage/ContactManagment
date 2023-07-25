using ContactManagementSystem.Entities;
using ContactManagementSystem.Helpers;
using ContactManagementSystem.Services.Classes;
using ContactManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

namespace ContactManagementSystem
{
    /// <summary>
    /// Interaction logic for UpdateForm.xaml
    /// </summary>
    public partial class UpdateForm : Window
    {
        private ContactEntity _contact;
        private readonly IJsonService<ContactEntity> _jsonService;


        public UpdateForm(ContactEntity contact, IJsonService<ContactEntity> jsonService)
        {
            _contact = contact;
            _jsonService = jsonService;
            InitializeComponent();
        }

      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = _contact.Name;
            txtPhone.Text = _contact.Phone;
            txtEmail.Text = _contact.Email;
        }
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFieldsHelper.ValidateContactFields(txtName,txtPhone,txtEmail))
            {
                return;
            }

            try
            {
                await UpdateContactAsync();
                MessageBox.Show("Successfully updated contact!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the contact: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var mainForm = new MainWindow(_jsonService);
            mainForm.Show();
            this.Close();
        }
        private async Task UpdateContactAsync()
        {
            _contact.Name = txtName.Text;
            _contact.Phone = txtPhone.Text;
            _contact.Email = txtEmail.Text;
            await _jsonService.UpdateDataAsync(_contact, _contact.Id);
        }

    }
}
