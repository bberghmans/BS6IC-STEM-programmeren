using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace SteamGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainRoot dataViewModel = new MainRoot();
        private Dictionary<int, Appnews> appnews = new Dictionary<int, Appnews>();

        const string SteamID = "76561199789007208";
        const string SteamKey = "8A8B489A2727D8FBADE868AD210E4E23";

        public MainWindow()
        {
            InitializeComponent();
            LoadGameCollection(SteamID, SteamKey);
        }


        private async void LoadGameCollection(string steamID, string steamKey)
        {
            string URL = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={steamKey}&steamid={steamID}&format=json";
            string result = await DownloadPage(URL);
            dataViewModel.rootGameCollection = JsonSerializer.Deserialize<RootGameCollection>(result);
            dataViewModel.rootNews = new RootNewsForGame();
            this.DataContext = dataViewModel;
        }

        private async void LoadGameNews(int appID)
        {
            /*
            MainRoot resultdata = (MainRoot)this.DataContext;
            resultdata.rootGameCollection = dataViewModel.rootGameCollection;
            resultdata.rootNews = new RootNewsForGame();
            */

            MainRoot result = (MainRoot)this.DataContext;

            if (appnews.ContainsKey(appID))
            {
                result.RootNews.Appnews = appnews[appID];
            }
            else
            {
                string URL = $"http://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid={appID}&count=3&maxlength=300&format=json";
                string resultstring = await DownloadPage(URL);
                result.RootNews = JsonSerializer.Deserialize<RootNewsForGame>(resultstring);

                // sanity check
                if (result.RootNews.appnews.appid == appID)
                {
                    appnews.Add(appID, result.RootNews.appnews);
                }
            }
            //this.DataContext = result;
            //dataViewModel.rootNews = resultdata.rootNews;
        }

        private async Task<string> DownloadPage(string url)
        {
            Debug.Write($"Downloading {url}");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("DONE");
                    return result;
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataViewModel.rootGameCollection.response == null) return;
            ListBox listBox = sender as ListBox;

            int selectedValue =  Convert.ToInt32(listBox.SelectedValue);

            LoadGameNews(selectedValue);

        }
    }
}