using System.Collections.Generic;
using TimurNigmatov422_RaNubiWPF.Data;
using System.Linq;
using TimurNigmatov422_RaNubiWPF.Pages;
using System.ComponentModel;

namespace TimurNigmatov422_RaNubiWPF.ViewModels
{
	internal class HomeViewModel : INotifyPropertyChanged
	{
		public HomeViewModel()
		{
			Users = App.db.Users.ToList();
			Users.Add(_emptyUser);
			PostsSource = App.db.Post.Where(post => post.Pet_Id == App.CurrentUser.Pet_Id).ToList();
			Refresh();
			AddPostCommand = new RelayCommand(AddPost);
		}

		public void Refresh()
		{
			IEnumerable<Post> results = PostsSource;
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				results = results.Where(r => r.Text.ToLower().Contains(SearchText.Trim().ToLower()));
			}
			if(SelectedUser != null && SelectedUser != _emptyUser)
			{
				results = results.Where(r => r.InfoCreator_Id == SelectedUser.Id);
			}
			Posts = results.ToList();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Posts)));
		}

		public List<Post> Posts { get; set; }
		public List<Users> Users { get; }
		public List<Post> PostsSource;

		public RelayCommand AddPostCommand { get; }

		public void AddPost(object value)
		{
			App.MainFrame.Navigate(new AddEditPostPage());
		}

		private string _searchText;
		public string SearchText
		{
			get => _searchText;
			set
			{
				_searchText = value;
				Refresh();
			}
		}

		private Users _selectedUset;
		public Users SelectedUser
		{
			get => _selectedUset;
			set
			{
				_selectedUset = value;
				Refresh();
			}
		}
		private static Users _emptyUser = new Users() { Name = "Все пользователи" };

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
