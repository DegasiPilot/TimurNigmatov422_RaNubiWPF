using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TimurNigmatov422_RaNubiWPF.Data
{
	public partial class Post
	{
		//private static ImageSourceConverter _imageConverter = new ImageSourceConverter();

		//public ImageSource ImageSource => _imageConverter.ConvertFrom(ImageBytes);

		public override string ToString()
		{
			return Text;
		}
	}
}
