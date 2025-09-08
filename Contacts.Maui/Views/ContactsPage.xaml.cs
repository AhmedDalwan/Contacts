using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Contact = Contacts.Maui.Models.Contact;

namespace MauiApp1.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).Id}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        if (menuItem != null)
        {
            var contact = menuItem.CommandParameter as Contact;
            if (contact != null)
            {
                ContactRepository.DeleteContact(contact.Id);
                LoadContacts();
            }
        }
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchBar = sender as SearchBar;
        if (searchBar != null)
        {
            var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(searchBar.Text));
            listContacts.ItemsSource = contacts;
        }
    }
}