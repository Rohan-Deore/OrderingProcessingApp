using ViewModel;

namespace OrderProcessing_MAUI;

public partial class OrderDetails : ContentPage
{
    public IUiService UiService { get; } = new UIService();

    private OrderDetailsVM orderDetailsVM;

    public OrderDetails()
	{
		InitializeComponent();
        orderDetailsVM = new OrderDetailsVM(UiService);
		Title = orderDetailsVM.TabName;
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        
    }
}