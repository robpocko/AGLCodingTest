using Windows.UI.Popups;

namespace AGLTest.UI.Utility
{
	/// <summary>
	/// Simplified interface to the MessageDialog
	/// </summary>
	/// <remarks>
	/// We just need a message box that has a Default and / or Cancel button. The text of the default
	/// button can be set through the DefaultButtonText property. The default button (if present)
	/// can be activated simply by pressing the ENTER key. The cancel button (if present) can be 
	/// activated by pressing the ESC key
	/// </remarks>
	internal class MessageDialogFacade
	{
		internal bool	HasDefaulButton { get; set; }
		internal string DefaultButtonText { get; set; }
		internal bool	HasCancelButton { get; set; }

		internal MessageDialog BuildMessageDialog(string message, string title)
		{
			MessageDialog dialog = new MessageDialog(message, title);

			if (HasDefaulButton && DefaultButtonText!= null && DefaultButtonText.Length > 0)
			{
				dialog.Commands.Add(new UICommand(DefaultButtonText));
				dialog.DefaultCommandIndex = 0;
			}

			if (HasCancelButton)
			{
				dialog.Commands.Add(new UICommand("Cancel"));
				dialog.CancelCommandIndex = HasDefaulButton ? (uint)1 : 0;
			}

			return dialog;
		}
	}
}
