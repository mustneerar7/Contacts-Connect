using Contacts_Connect.Strings.en_us;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Contacts_Connect
{
    public sealed partial class MainPage : Page
    {
        // list of objects [Person] created from database query
        List<Person> people = new List<Person>();

        // defining reference [DataAccess]
        DataAccess db;

        public MainPage()
        {
            this.InitializeComponent();

            // get data from database by sending a query to server
            // and returning a list of results of type [Person]
            db = new DataAccess();

            // saves the returned list into list [people]
            people = db.getAllPeople();

            // sets listbox datasource to list
            ContactsListBox.ItemsSource = people;
            ContactsListBox.DisplayMemberPath = "fullInfo";
        }

        private void lastNameSearchButton_Click(object sender, RoutedEventArgs e)
        {
            // saves the returned list into list [people]
            people = db.getPeopleByLastName(lastNameTextBox.Text);

            // refresh listbox data
            ContactsListBox.ItemsSource = people;
        }

        private void listViewResetButton_Click(object sender, RoutedEventArgs e)
        {
            people = db.getAllPeople();
            ContactsListBox.ItemsSource = people;
        }

        // opens a dialog for adding a new contact
        private async void createNewContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new AddContactDialog();
            var result = await dialog.ShowAsync();
        }
    }
}
