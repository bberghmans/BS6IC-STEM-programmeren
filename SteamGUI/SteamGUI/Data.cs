using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamGUI
{
    public class Game
    {
        public int appid { get; set; }
        public int playtime_forever { get; set; }
        public int playtime_windows_forever { get; set; }
        public int playtime_mac_forever { get; set; }
        public int playtime_linux_forever { get; set; }
        public int playtime_deck_forever { get; set; }
        public int rtime_last_played { get; set; }
        public int playtime_disconnected { get; set; }
    }

    public class Response
    {
        public int game_count { get; set; }
        
        public int GameCount {
            get {
                return game_count;
            }
        } 
        
        public List<Game>? games { get; set; }
        
        public ObservableCollection<int>? GameIDs
        {
            get {
                if (games == null) return null;
                return new ObservableCollection<int>(games.Select(x=>x.appid));
            }
        }

    }

    public class RootGameCollection
    {
        public Response? response { get; set; }
        
        public Response? Response
        { 
            get {
                return response;
            }
        }
    }


    public class Appnews
    {
        public int appid { get; set; }
        public List<Newsitem> newsitems { get; set; }
        public Newsitem FirstItem { get { return newsitems[0]; } }
        public int count { get; set; }
    }

    public class Newsitem
    {
        public string gid { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public bool is_external_url { get; set; }
        public string author { get; set; }
        public string contents { get; set; }
        public string feedlabel { get; set; }
        public int date { get; set; }
        public string feedname { get; set; }
        public int feed_type { get; set; }
        public int appid { get; set; }
        public List<string> tags { get; set; }
    }

    public class RootNewsForGame: INotifyPropertyChanged
    {
        public Appnews appnews { get; set; }
        public Appnews Appnews
        {
            get { return appnews; }
            set
            {
                appnews = value;
                OnPropertyChanged(nameof(Appnews));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainRoot: INotifyPropertyChanged
    {
        public RootNewsForGame rootNews { get; set; }
        public RootGameCollection rootGameCollection { get; set; }

        public RootNewsForGame RootNews
        {
            get { return rootNews; }
            set
            {
                rootNews = value;
                OnPropertyChanged(nameof(rootNews));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
