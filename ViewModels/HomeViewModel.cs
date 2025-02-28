using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimurNigmatov422_RaNubiWPF.Data;

namespace TimurNigmatov422_RaNubiWPF.ViewModels
{
	internal class HomeViewModel
	{
		public HomeViewModel()
		{
			Posts = new ObservableCollection<Post>(App.db.Post);
		}

		public ObservableCollection<Post> Posts;
	}
}
