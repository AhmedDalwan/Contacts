namespace MauiApp1.Views;

using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact? contact;

    public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    public int ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(value);
            if (contact is not null)
            {
                ContactCtrl.Name = contact.Name;
                ContactCtrl.Phone = contact.Phone;
                ContactCtrl.Email = contact.Email;
                ContactCtrl.Address = contact.Address;
            }
        }
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        if (contact is null)
        {
            return;
        }
        contact.Name = ContactCtrl.Name;
        contact.Phone = ContactCtrl.Phone;
        contact.Email = ContactCtrl.Email;
        contact.Address = ContactCtrl.Address;

        ContactRepository.UpdateContact(contact.Id, contact);

        Shell.Current.GoToAsync("..");
    }

    private void ContactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}