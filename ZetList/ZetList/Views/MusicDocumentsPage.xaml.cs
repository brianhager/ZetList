using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZetList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MusicDocumentsPage : ContentPage
	{
		public MusicDocumentsPage ()
		{
			InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetMusicDocumentsAsync();
        }
    }
}