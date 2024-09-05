namespace OrderProcessing_MAUI;
using CommunityToolkit.Maui.Views;

public partial class SimplePopup : Popup
{
	public SimplePopup(string msg)
	{
		InitializeComponent();
		UserMessage.Text = msg;
	}
}