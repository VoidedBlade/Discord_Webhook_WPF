using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace wpf_discord_connection
{
    public partial class MainWindow : Window
    {
        // allowed file types 
        private List<string> AllowedImageTypes = new List<string>() { ".jpg", ".png", ".gif", ".webp" };
        private List<string> AllowedVideoTypes = new List<string>() { ".webm", ".mp4" }; // doesn't work for some reason so is excluded as an option to be sent

        // for linking it by sending
        private Dictionary<string, string> Webhooks = new Dictionary<string, string>();
        private Dictionary<string, string> Images = new Dictionary<string, string>();


        // visual related links
        public ObservableCollection<Button> WebhookButtons = new ObservableCollection<Button>();
        private ObservableCollection<Button> ImageButtons = new ObservableCollection<Button>();


        public MainWindow()
        {
            InitializeComponent();
            WebhookBox.ItemsSource = WebhookButtons;
            ImageBox.ItemsSource = ImageButtons;
        }

        /// <summary>
        /// Generates the data from all the fields that have been input to be sent over
        /// </summary>
        /// <param name="_Username"></param>
        /// <param name="_Message"></param>
        /// <returns></returns>
        private DiscorData EmbedChecker(string _Username, string _Message)
        {
            Dictionary<string, string> _Links = new Dictionary<string,string>();
            int _ItterationIndex = 0;
            string botimg = BotImage.Text.Contains("https://") ? BotImage.Text : "";


            DiscorData _data = new DiscorData()
            {
                username = _Username,
                content = _Message,
                avatar_url = botimg,
            };

            foreach (KeyValuePair<string, string> keyValuePair in Images)
            {
                foreach (string _ImageType in AllowedImageTypes)
                {
                    if (keyValuePair.Value.ToLower().Contains(_ImageType))
                    {
                        _Links.Add(keyValuePair.Value, "image");
                    }
                }
            }

            _ItterationIndex = 0;

            if (_Links.Count > 0)
            {
                _data.embeds = new DiscordEmbed[_Links.Count];
                foreach (KeyValuePair<string, string> Values in _Links)
                {
                    if (_ItterationIndex > 10) return _data;

                    else if (Values.Value == "image") _data.embeds[_ItterationIndex] = new DiscordEmbed() { image = new DiscordImage() { url = Values.Key } };

                    _ItterationIndex++;
                }
            }

            return _data;
        }

        private void SendSelected(object sender, RoutedEventArgs e)
        {
            using (WebClient _webClient = new WebClient())
            {
                DiscorData _data;

                _data = EmbedChecker(Username.Text, ChatMessage.Text);

                foreach (KeyValuePair<string, string> keyValuePair in Webhooks)
                {
                    _webClient.UploadValues(keyValuePair.Value, new System.Collections.Specialized.NameValueCollection()
                    { 
                        { "payload_json", JsonConvert.SerializeObject(_data)}
                    });
                }

                
            }
        }
        /// <summary>
        /// Adds a webhook using the click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_webhook(object sender, RoutedEventArgs e)
        {
            if (webhookUrl.Text.ToLower().Contains("https://"))
            {
                string TempText = webhookName.Text;
                if (Webhooks.ContainsKey(TempText.ToString())) return;

                Regex reg = new Regex("[^a-zA-Z]");
                string Name = reg.Replace(TempText, string.Empty);

                // create visual representation
                Button NewWebhook = new Button();
                NewWebhook.Name = Name;
                NewWebhook.Content = TempText.ToString();
                NewWebhook.Click += RemoveWebhook;
                NewWebhook.Width = 132;
                NewWebhook.Height = 20;

                WebhookButtons.Add(NewWebhook);
                Webhooks.Add(TempText.ToString(), webhookUrl.Text);

                // reset textboxes
                webhookName.Text = "Name";
                webhookUrl.Text = "URL";
            }
        }

        private void Add_Image(object sender, RoutedEventArgs e)
        {
            if (ImageUrl.Text.ToLower().Contains("https://"))
            {
                string TempText = ImageName.Text;
                if (Images.ContainsKey(TempText)) return;

                Regex reg = new Regex("[^a-zA-Z]");
                string Name = reg.Replace(TempText, string.Empty);

                // create visual representation
                Button NewImage = new Button();
                NewImage.Name = Name;
                NewImage.Content = TempText;
                NewImage.Click += RemoveImage;
                NewImage.Width = 132;
                NewImage.Height = 20;

                Images.Add(Name, ImageUrl.Text);
                ImageButtons.Add(NewImage);

                // reset textboxes
                ImageName.Text = "Name";
                ImageUrl.Text = "URL";
            }
        }

        private void RemoveWebhook(object sender, RoutedEventArgs e)
        {
            Webhooks.Remove(((Button)sender).Name);
            WebhookButtons.Remove((Button)sender);
        }

        private void RemoveImage(object sender, RoutedEventArgs e)
        {
            Images.Remove(((Button)sender).Name);
            ImageButtons.Remove((Button)sender);
        }

        [Serializable]
        private struct DiscorData
        {
            public string username;
            public string avatar_url;
            public string content;
            public DiscordEmbed[] embeds;
        }

        private struct DiscordEmbed
        {
            public DiscordImage image;
//            public DiscordVideo video;
        }

        private struct DiscordImage
        {
            public string url;
        }

        private struct DiscordVideo
        {
            public string url;
        }

    }
}
