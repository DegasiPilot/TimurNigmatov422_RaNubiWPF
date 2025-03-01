using Microsoft.Win32;
using TimurNigmatov422_RaNubiWPF.Data;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using TimurNigmatov422_RaNubiWPF.Pages;

namespace TimurNigmatov422_RaNubiWPF.ViewModels
{
	internal class AddEditPostViewModel : INotifyPropertyChanged
	{
		private readonly Post _post;

		public AddEditPostViewModel()
		{
			_post = new Post()
			{
				InfoCreator_Id = App.CurrentUser.Id,
			};
			PickImageCommand = new RelayCommand(PickImage);
			SaveCommand = new RelayCommand(Save, CanSave);
			BackCommand = new RelayCommand(Back);
			Pets = App.db.Pet.ToList();
		}

		public RelayCommand PickImageCommand { get; }
		public RelayCommand SaveCommand { get; }
		public RelayCommand BackCommand { get; }

		public List<Pet> Pets { get; }

		public string PostText
		{
			get => _post.Text;
			set => _post.Text = value;
		}

		public Pet Pet
		{
			get => _post.Pet;
			set => _post.Pet = value;
		}

		public byte[] ImageBytes
		{
			get => _post.ImageBytes;
			set
			{
				_post.ImageBytes = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageBytes)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void PickImage(object value)
		{
			OpenFileDialog fileDialog = new OpenFileDialog()
			{
				Filter = "Image Files |*.png; *.jpg; *.jpeg; *.bmp;"
			};
			if (fileDialog.ShowDialog() == true && fileDialog.FileName != null)
			{
				ImageBytes = File.ReadAllBytes(fileDialog.FileName);
			}
		}

		public void Save(object value)
		{
			App.db.Post.Add(_post);
			App.db.SaveChanges();
			App.MainFrame.Navigate(new HomePage());
		}

		public bool CanSave (object val) =>
			!string.IsNullOrWhiteSpace(PostText) && !(Pet is null) && ImageBytes != null;

		public void Back(object value)
		{
			App.MainFrame.GoBack();
		}
	}
}