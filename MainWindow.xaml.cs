using System;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using GotYourWebhook.Pages;

namespace GotYourWebhook
{
	/// <summary>
	/// Main window logic
	/// </summary>
	public partial class MainWindow : Window
	{

		// Please dont create a client for every request ;)
		public static HttpClient client = new HttpClient();

		private void Setup()
		{
			Main.Content = new Spammer();

			foreach (Button button in MenuBtns.Children.OfType<Button>())
			{
				button.Click += ButtonHandler;
			}
		}

		public void ButtonHandler(object sender, RoutedEventArgs args)
		{
			switch (((Button)sender).Tag.ToString())
			{
				case "Spammer":
					Main.Content = new Spammer();
					break;
				case "Controller":
					Main.Content = new Controller();
					break;
				case "Destroyer":
					Main.Content = new Destroyer();
					break;
				case "Disaster":
					Main.Content = new Disaster();
					break;
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			Setup();
		}
	}
}