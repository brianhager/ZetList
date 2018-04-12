using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZetList.Models;

namespace ZetList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DropboxPage : ContentPage
	{
		public DropboxPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            dropboxItemslistView.ItemsSource = await GetDropboxItemsAsync();
        }

        //public async Task<List<Document>> GetDocumentsAsync()
        private async Task<List<DropboxItem>> GetDropboxItemsAsync()
        {
            DropboxClient dbx = new DropboxClient(Constants.DropboxToken);
            List<DropboxItem> dropboxItems = new List<DropboxItem>();

            var full = await dbx.Users.GetCurrentAccountAsync();
            Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);

            var list = await dbx.Files.ListFolderAsync(string.Empty);

            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                DropboxItem dropboxItem = new DropboxItem()
                {
                    ItemName = item.Name,
                    FileOrFolder = "Folder",
                    FileSize = "n/a"
                };
                dropboxItems.Add(dropboxItem);
                //Console.WriteLine("D  {0}/", item.Name);
            }

            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                DropboxItem dropboxItem = new DropboxItem()
                {
                    ItemName = item.Name,
                    FileOrFolder = "File",
                    FileSize = item.AsFile.Size.ToString()
                };
                dropboxItems.Add(dropboxItem);
                //Console.WriteLine("F{0,8} {1}", item.AsFile.Size, item.Name);
            }

            return dropboxItems;
        }

        async void Download_Clicked(object sender, EventArgs e)
        {

            var button = (Button)sender;
            DropboxItem dropboxItemClicked = button.CommandParameter as DropboxItem;

            Document newDocument = new Document();
            if (dropboxItemClicked.FileOrFolder == "File") {
                newDocument.FilePath = "testPath";
                newDocument.Name = dropboxItemClicked.ItemName;
                newDocument.Info2 = "File Size is " + dropboxItemClicked.FileSize;
                newDocument.NameAndFilePath = dropboxItemClicked.ItemName + " " + "testPath";
                await App.Database.SaveItemAsync(newDocument);
            }
            Console.WriteLine("F{0,8} {1}", dropboxItemClicked.FileSize, dropboxItemClicked.ItemName);

            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}