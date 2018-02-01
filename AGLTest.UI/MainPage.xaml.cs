using System;
using System.Threading.Tasks;
using AGLTest.UI.AppSystem;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AGLTest.UI
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
    {
		private string serverUrl = string.Empty;
		private bool dialogBeingShown = false;

        public MainPage()
        {
            this.InitializeComponent();

			serverUrl = AppSettings.ServerUrl;

			string applicationName = Windows.ApplicationModel.Package.Current.DisplayName;
        }

		private async void NavMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
		{
			if (args.IsSettingsSelected)
			{
				if (!dialogBeingShown)
				{
					await ShowSettingsDialog();
				}
			}
			else
			{
				NavigationViewItem item = args.SelectedItem as NavigationViewItem;

				switch (item.Tag)
				{
					case "sortCats":
						ContentFrame.Navigate(typeof(ShowListPage), "Cat", new DrillInNavigationTransitionInfo());
						break;

					case "sortDogs":
						ContentFrame.Navigate(typeof(ShowListPage), "Dog", new DrillInNavigationTransitionInfo());
						break;

					case "sortFish":
						ContentFrame.Navigate(typeof(ShowListPage), "Fish", new DrillInNavigationTransitionInfo());
						break;
				}
			}
		}

		private async void NavigationMenu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			if (args.IsSettingsInvoked && !dialogBeingShown)
			{
				dialogBeingShown = true;
				await ShowSettingsDialog();
				dialogBeingShown = false;
			}
		}

		private async void NavMenu_Loaded(object sender, RoutedEventArgs e)
		{
			//	The server url is stored in local storage. If it has not been stored there, then need to 
			//	display setting page
			if (serverUrl.Length == 0)
			{
				await ShowSettingsDialog();
			}
			else
			{
				foreach (NavigationViewItem item in NavigationMenu.MenuItems)
				{
					if (item.Tag.ToString() == "sortCats")
					{
						NavigationMenu.SelectedItem = item;
						break;
					}
				}
			}
		}

		private async Task ShowSettingsDialog()
		{
			SetMenuItemsEnabled(false);

			SettingsDialog dialog = new SettingsDialog();
			ContentDialogResult result = await dialog.ShowAsync();

			SetMenuItemsEnabled(dialog.Url.Length > 0);
		}

		private void SetMenuItemsEnabled(bool isEnabled)
		{
			foreach (NavigationViewItem item in NavigationMenu.MenuItems)
			{
				item.IsEnabled = isEnabled;
			}
		}
	}
}
