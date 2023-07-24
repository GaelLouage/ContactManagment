using ContactManagementSystem.Entities;
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

        public MainWindow(IJsonService<ContactEntity> jsonService)
        {
            _jsonService = jsonService;
        }

        public MainWindow() : this(new JsonService<ContactEntity>("contacts"))
        {
            InitializeComponent();



        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var toCreate = new ContactEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Tester2",
            };
            try
            {
                var obj = await _jsonService.CreateDataAsync(toCreate, toCreate.Name);
                if (obj != null)
                {
                    MessageBox.Show(obj.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
