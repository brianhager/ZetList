using ZetList.Views;
using Xamarin.Forms;
using ZetList.Data;
using System.Diagnostics;

namespace ZetList
{
	public partial class App : Application
	{

        static ZetListDatabase database;

        public App ()
		{
			InitializeComponent();


            MainPage = new MainPage();
        }

        public static ZetListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    // Changes here by @cwrea for adaptation to EF Core.
                    var databasePath = DependencyService.Get<IFileHelper>().GetLocalFilePath("ZetListSQLite.db");
                    Debug.WriteLine("databasePath: " + databasePath);
                    database = ZetListDatabase.Create(databasePath);
                }
                return database;
            }


        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
