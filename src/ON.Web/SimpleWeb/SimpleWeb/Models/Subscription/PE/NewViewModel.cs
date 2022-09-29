namespace ON.SimpleWeb.Models.Subscription.PE
{
    public class NewViewModel
    {
        public NewViewModel()
        {
        }

        public NewViewModel(string clientToken, bool isTest)
        {
            ClientToken = clientToken;
            IsTest = isTest;
        }

        public string ClientToken { get; set; }

        public bool IsTest { get; set; }
    }
}
