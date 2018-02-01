using Windows.Storage;

namespace AGLTest.UI.AppSystem
{
	public class AppSettings
    {
		public static string ServerUrl
		{
			get
			{
				return (ApplicationData.Current.LocalSettings.Values["serverUrl"] ?? string.Empty).ToString();
			}

			set
			{
				ApplicationData.Current.LocalSettings.Values["serverUrl"] = value;
			}
		}

	}
}
