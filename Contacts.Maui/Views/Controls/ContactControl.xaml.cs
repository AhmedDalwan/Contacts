namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

	public ContactControl()
	{
		InitializeComponent();
	}

    public string Name
	{
		get
		{
			return txtName.Text;
		}
		set
		{
			txtName.Text = value;
		}
	}
    public string Phone
    {
        get
        {
            return txtPhone.Text;
        }
        set
        {
            txtPhone.Text = value;
        }
    }
    public string Email
    {
        get
        {
            return txtEmail.Text;
        }
        set
        {
            txtEmail.Text = value;
        }
    }
    public string Address
    {
        get
        {
            return txtAddress.Text;
        }
        set
        {
            txtAddress.Text = value;
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is requied.");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors!)
            {
                OnError?.Invoke(sender, error!.ToString()!);
            }
            return;
        }
        OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}