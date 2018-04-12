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
	public partial class DocumentsPage : ContentPage
	{
		public DocumentsPage ()
		{
			InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            documentsListView.ItemsSource = await App.Database.GetDocumentsAsync();
        }

        async void AddDropboxItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new DropboxPage());
            await Navigation.PushAsync(new DropboxPage());
        }
    }
}