using De_Lijn.Models;
using De_Lijn.Models.lijnKleur;
using De_Lijn.Models.halteDoorkomsten;
using De_Lijn.Models.haltes;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Timers;

namespace De_Lijn
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiService _apiService;
        private readonly System.Timers.Timer _timer; // Declare the Timer

        public MainPage()
        {
            InitializeComponent();
            _apiService = new ApiService();

            LoadData(); // Load the data when the page is created

            // Initialize the timer to trigger every 5 seconds (5000 ms)
            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += async (sender, e) => await RefreshData();
            _timer.AutoReset = true; // Ensure the timer repeats
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _timer.Start(); // Start the timer when the page appears
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer.Stop(); // Stop the timer when the page disappears
        }

        private async Task RefreshData()
        {
            // Use Dispatcher to ensure LoadData runs on the main thread
            await Dispatcher.DispatchAsync(() => LoadData());
        }

        private async void LoadData()
        {
            Location location = await Geolocation.GetLocationAsync();

            double latitude = location.Latitude;
            double longitude = location.Longitude;

            string url = $"https://api.delijn.be/DLKernOpenData/api/v1/haltes/indebuurt/{latitude},{longitude}?maxAantalHaltes=1&radius=1000";
            string data = await _apiService.FetchDataFromApiAsync(url);

            Haltes haltes = new();

            try
            {
                haltes = JsonConvert.DeserializeObject<Haltes>(data) ?? new Haltes();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }

            if (haltes == null || haltes.haltes.Count == 0)
            {
                return;
            }

            halteNameLabel.Text = haltes.haltes[0].naam;

            // Now search next line approaching the stop
            url = haltes.haltes[0].links[1].url;
            data = await _apiService.FetchDataFromApiAsync(url);

            HalteDoorkomsten halteDoorkomsten = new HalteDoorkomsten();

            try
            {
                halteDoorkomsten = JsonConvert.DeserializeObject<HalteDoorkomsten>(data) ?? new HalteDoorkomsten();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }

            if (halteDoorkomsten == null || halteDoorkomsten.halteDoorkomsten.Count == 0)
            {
                //if there are no upcoming lines, empty the labels
                lijnNummerLabel.Text = "Geen Doorkomsten";
                //set colors transparent
                lijnNummerLabel.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
                lijnNummerBorder.Stroke = new SolidColorBrush(Color.FromRgba(0, 0, 0, 0));
                tijd.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
                bestemmingLabel.Text = "";
                tijd.Text = "";
                verschil.Text = "";
                wachtTijd.Text = "";
                return;
            }

            string entiteitnummer = halteDoorkomsten.halteDoorkomsten[0].doorkomsten[0].entiteitnummer;
            int lijnnummer = halteDoorkomsten.halteDoorkomsten[0].doorkomsten[0].lijnnummer;
            string richting = halteDoorkomsten.halteDoorkomsten[0].doorkomsten[0].richting;
            string bestemming = halteDoorkomsten.halteDoorkomsten[0].doorkomsten[0].bestemming;
            DateTime dienstregelingTijdstip = Convert.ToDateTime(halteDoorkomsten.halteDoorkomsten[0].doorkomsten[0].dienstregelingTijdstip);
            DateTime realtimeTijdstip = Convert.ToDateTime(halteDoorkomsten.halteDoorkomsten[0].doorkomsten[0].realtimeTijdstip);

            // Calculate the time difference between the normal time and the realtime in minutes
            TimeSpan timeDifference = realtimeTijdstip - dienstregelingTijdstip;
            TimeSpan timeUntilArrival = realtimeTijdstip - DateTime.Now;

            // Search for line
            url = $"https://api.delijn.be/DLKernOpenData/api/v1/lijnen/{entiteitnummer}/{lijnnummer}";
            data = await _apiService.FetchDataFromApiAsync(url);

            Lijn lijn = new();

            try
            {
                lijn = JsonConvert.DeserializeObject<Lijn>(data) ?? new Lijn();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }

            if (lijn == null)
            {
                return;
            }

            lijnNummerLabel.Text = lijn.lijnnummerPubliek;
            bestemmingLabel.Text = bestemming;

            string text = "";
            Color textColor = Color.FromRgb(255, 255, 255);
            Color backColor = Color.FromRgb(0, 0, 0);

            if (timeDifference.Minutes == 0)
            {
                text = "Op Tijd";
                textColor = Color.FromRgb(255, 255, 255);
                backColor = Color.FromRgba(117, 255, 102, 190);
            }
            else if (timeDifference.Minutes < 0)
            {
                text = timeDifference.Minutes.ToString();
                textColor = Color.FromRgb(102, 110, 255);
                backColor = Color.FromRgba(102, 110, 255, 190);
            }
            else
            {
                text = "+" + timeDifference.Minutes.ToString();
                textColor = Color.FromRgb(255, 102, 112);
                backColor = Color.FromRgba(255, 102, 112, 190);
            }

            verschil.Text = text;
            verschil.TextColor = textColor;

            //if minutes is only 1 digit, add a 0 to keep the layout consistent
            if (realtimeTijdstip.Minute < 10)
            {
                tijd.Text = realtimeTijdstip.Hour + ":0" + realtimeTijdstip.Minute;
            }
            else
            {
                tijd.Text = realtimeTijdstip.Hour + ":" + realtimeTijdstip.Minute;
            }

            tijd.BackgroundColor = backColor;

            wachtTijd.Text = timeUntilArrival.Minutes.ToString() + " min";

            //get line colors
            url = lijn.links[1].url;
            data = await _apiService.FetchDataFromApiAsync(url);

            LijnKleuren lijnKleuren = new LijnKleuren();

            if (data != null)
            {
                // Deserialize the data to a LijnKleuren object
                lijnKleuren = JsonConvert.DeserializeObject<LijnKleuren>(data);
            }

            string textColorUrl = lijnKleuren.voorgrond.code;
            string backColorUrl = lijnKleuren.achtergrond.code;
            string strokeColorUrl = lijnKleuren.achtergrondRand.code;

            url = lijnKleuren.voorgrond.links[0].url;
            data = await _apiService.FetchDataFromApiAsync(url);

            LijnKleurCode textColorCode = new LijnKleurCode();

            if (data != null)
            {
                // Deserialize the data to a LijnKleurCode object
                textColorCode = JsonConvert.DeserializeObject<LijnKleurCode>(data);
            }

            url = lijnKleuren.achtergrond.links[0].url;
            data = await _apiService.FetchDataFromApiAsync(url);

            LijnKleurCode backColorCode = new LijnKleurCode();

            if (data != null)
            {
                // Deserialize the data to a LijnKleurCode object
                backColorCode = JsonConvert.DeserializeObject<LijnKleurCode>(data);
            }

            url = lijnKleuren.achtergrondRand.links[0].url;
            data = await _apiService.FetchDataFromApiAsync(url);

            LijnKleurCode strokeColorCode = new LijnKleurCode();

            if (data != null)
            {
                // Deserialize the data to a LijnKleurCode object
                strokeColorCode = JsonConvert.DeserializeObject<LijnKleurCode>(data);
            }

            lijnNummerLabel.TextColor = Color.FromHex(textColorCode.hex);
            lijnNummerLabel.BackgroundColor = Color.FromHex(backColorCode.hex);
            lijnNummerBorder.Stroke = new SolidColorBrush(Color.FromHex(strokeColorCode.hex));
        }
    }
}