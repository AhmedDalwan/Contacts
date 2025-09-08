using Contacts.Maui.Models;

namespace MauiApp1.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("..");
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Contacts.Maui.Models.Contact
        {
            Name = ContactCtrl.Name,
            Address = ContactCtrl.Address,
            Email = ContactCtrl.Email,
            Phone = ContactCtrl.Phone,
        });
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}