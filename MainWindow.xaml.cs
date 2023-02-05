using System;
using System.Net.Http;
using System.Windows;

namespace GotYourWebhook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		HttpClient client = new HttpClient();

		public async void DeleteWebhook(object sender, RoutedEventArgs e)
		{
			string url = WebhookUrl.Text;

			if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
			{
				try
				{
					using (HttpResponseMessage response = await client.DeleteAsync(url))
					{
						if (response.StatusCode == System.Net.HttpStatusCode.OK)
						{
							MessageBox.Show("Webhook successfully deleted");
						}
					}
				}
				catch (HttpRequestException err)
				{
					MessageBox.Show($"Error: {err.Message}");
				}
			} else
			{
				MessageBox.Show("Enter a valid URL");
			}
		}

		public MainWindow()
		{
			InitializeComponent();
		}
	}
}