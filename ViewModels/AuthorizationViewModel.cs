using System.Linq;
using System.Windows;
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
				Users user = App.db.Users.FirstOrDefault(u => u.Name == Name.Trim().ToLower());
				if(user != null)
				{
					if (user.Password == Password)
					{
						App.CurrentUser = user;
						App.MainFrame.Navigate(App.HomePageUri);
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