using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ContactManagementSystem.Helpers
{
    public static class ValidateFieldsHelper
    {
        public static bool ValidateContactFields(TextBox txtName, TextBox txtPhone, TextBox txtEmail)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("All Fields are required!");
                return false;
            }

            if (!EmailHelper.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email is invalid!");
                return false;
            }

            return true;
        }
    }
}
