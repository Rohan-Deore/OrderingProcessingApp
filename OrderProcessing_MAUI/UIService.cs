using ViewModel;


namespace OrderProcessing_MAUI
{
    public class UIService : IUiService
    {
        private MainPage mainPage;

        public UIService(MainPage mainP)
        {
            mainPage = mainP;
        }

        public void ShowUserMessage(string msg)
        {
            mainPage.ShowMessage(msg);
        }
    }
}
