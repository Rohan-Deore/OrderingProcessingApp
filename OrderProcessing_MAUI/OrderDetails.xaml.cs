using ViewModel;

namespace OrderProcessing_MAUI;

public partial class OrderDetails : ContentPage
{
    public IUiService UiService { get; }

    private OrderDetailsVM orderDetailsVM;

    public OrderDetails(MainPage page)
	{
		InitializeComponent();
        UiService = new UIService(page);
        orderDetailsVM = new OrderDetailsVM(UiService);
		Title = orderDetailsVM.TabName;
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (orderDetailsVM != null && DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            for (int i = 0;  i < orderDetailsVM.Orders.Count; i++)
            {
                var order = orderDetailsVM.Orders[i];
                AddRow(order, i);
            }
        }
    }

    private void AddRow(Order order, int rowCount)
    {
        OrdersGrid.AddRowDefinition(new RowDefinition());

        var newEntry = new Entry();
        newEntry.Text = order.PartID.ToString();
        Grid.SetColumn(newEntry, 0);
        Grid.SetRow(newEntry, rowCount + 1);
        OrdersGrid.Add(newEntry);

        var newEntry1 = new Entry();
        newEntry1.Text = order.PartName;
        Grid.SetColumn(newEntry1, 1);
        Grid.SetRow(newEntry1, rowCount + 1);
        OrdersGrid.Add(newEntry1);
    }
}