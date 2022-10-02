using Windows.UI.Xaml.Controls;


namespace Contacts_Connect.Strings.en_us
{
    public sealed partial class AddContactDialog : ContentDialog
    {
        public AddContactDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DataAccess db = new DataAccess();

            db.insertContact(newContactFirstName.Text, newContactLastName.Text, newContactPhoneNumber.Text);
        }
    }
}
