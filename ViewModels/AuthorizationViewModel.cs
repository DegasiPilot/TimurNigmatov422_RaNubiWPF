using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TimurNigmatov422_RaNubiWPF.Data;

namespace TimurNigmatov422_RaNubiWPF.ViewModels
{
	internal class AuthorizationViewModel
	{
		public AuthorizationViewModel()
		{
			TryEnterCommand = new RelayCommand(TryEnter, CanTryEnter);
		}

		public string Name { get; set; }
		public string Password { get; set; }
		public RelayCommand TryEnterCommand { get; }

		public void TryEnter(object value)
		{
			if(CanTryEnter(value))
			{
				Users users = App.db.Users.FirstOrDefault(user => user.Name == Name.Trim().ToLower());
				if(users != null)
				{
					if (users.Password == Password)
					{
						App.MainFrame.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
					}
					else
					{
						MessageBox.Show("Неверный пароль");
					}
				}
				else
				{
					MessageBox.Show("Нет пользователя с таким именем");
				}
			}
			else
			{
				MessageBox.Show("Сначала заполните все поля!");
			}
		}

		public bool CanTryEnter(object value)
		{
			return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password);
		}
	}
}