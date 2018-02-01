using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using AGLTest.BusFacade;
using AGLTest.HttpConnect;
using AGLTest.Model;
using AGLTest.UI.AppSystem;
using AGLTest.UI.Utility;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AGLTest.UI
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ShowListPage : Page
	{
		public ShowListPage()
		{
			this.InitializeComponent();
		}

		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			if (e.Parameter != null)
			{
				string ending = string.Empty;
				if (e.Parameter.ToString() != "Fish") ending = "s";

				PageTitle.Text = $"List of {e.Parameter.ToString()}{ending}";

				List<PersonAPI> peoplePets = null;
				try
				{
					peoplePets = await PeopleConnector.Fetch(AppSettings.ServerUrl);
				}
				catch (HttpRequestException)
				{
					var message = new StringBuilder("A problem has been encountered while trying to access the internet. ");
					message.Append("Please check that your internet connection is working. ");
					message.Append("If it is, then check 'Settings' to ensure that the correct URL has been set");

					var dialog = new MessageDialogFacade
					{
						HasDefaulButton = true,
						HasCancelButton = false,
						DefaultButtonText = "OK"

					}.BuildMessageDialog(message.ToString(), "Internet Issue");

					await dialog.ShowAsync();
					return;
				}

				var pets = PetBF.GetPetsByGender(peoplePets, e.Parameter.ToString());

				FemalePets.ItemsSource = pets.Where(p => p.Gender == "Female");
				FemalePets.DisplayMemberPath = "PetName";

				MalePets.ItemsSource = pets.Where(p => p.Gender == "Male");
				MalePets.DisplayMemberPath = "PetName";
			}
		}
	}
}
