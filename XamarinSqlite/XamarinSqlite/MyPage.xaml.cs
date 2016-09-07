using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinSqlite
{
    /// <summary>
    /// Just for testing purposes, to show how to have the access to SQlite in Xamarin. It's also not being considered MVVM.
    /// </summary>
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();

            using (var data = new DataAccess())
            {
                this.Contacts.ItemsSource = data.GetContacts();
            }
            
        }

        protected void SaveClicked(object sender, EventArgs e)
        {
            var contact = new Contact()
            {
                Name = this.Name.Text,
                Email = this.Email.Text,
                Phone = this.Phone.Text
            };

            using (var data = new DataAccess())
            {
                data.Insert(contact);
                this.Contacts.ItemsSource = data.GetContacts();
            }
        }
    }
}
