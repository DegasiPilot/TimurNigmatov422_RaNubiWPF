using System;
using System.Windows;
using System.Windows.Controls;
using TimurNigmatov422_RaNubiWPF.Data;

namespace TimurNigmatov422_RaNubiWPF
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static TimurNigamtov422_RaNubiDBEntities db = new TimurNigamtov422_RaNubiDBEntities();
		public static Frame MainFrame;
		public static Users CurrentUser;

		public static readonly Uri HomePageUri = new Uri("Pages/HomePage.xaml", UriKind.Relative);
	}
}
