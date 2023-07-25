using ContactManagementSystem.Entities;
using ContactManagementSystem.Helpers;
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
using System.Windows.Shapes;

namespace ContactManagementSystem
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        private readonly IJsonService<ContactEntity> _jsonService;

        public Create(IJsonService<ContactEntity> jsonService)
        {
            _jsonService = jsonService;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFieldsHelper.ValidateContactFields(txtName, txtPhone, txtEmail))
            {
                return;
            }

            try
            {
                await _jsonService.CreateDataAsync(new ContactEntity { Name = txtName.Text, Phone = txtPhone.Text, Email = txtEmail.Text}, txtName.Text);
                MessageBox.Show("Successfully created contact!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the contact: " + ex.Message);
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var mainForm = new MainWindow(_jsonService);
            mainForm.Show();
            this.Close();
        }
    }
}
