using AGLTest.UI.AppSystem;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AGLTest.UI
{
	public sealed partial class SettingsDialog : ContentDialog
    {
		public string Url { get; private set; }
		private const string DEFAULT_URL = "http://agl-developer-test.azurewebsites.net/people.json";

        public SettingsDialog()
        {
            this.InitializeComponent();

			Url = AppSettings.ServerUrl;

			// for convenience, have hard-coded url
			if (Url.Length == 0) Url = DEFAULT_URL;

			TextBoxServerUrl.Text = Url;

		}

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
			AppSettings.ServerUrl = Url = TextBoxServerUrl.Text.Trim();
		}

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
			Url = AppSettings.ServerUrl;
        }
    }
}
