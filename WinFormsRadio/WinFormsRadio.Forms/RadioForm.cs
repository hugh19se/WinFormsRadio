using System.Configuration;
using System.Text.Json;
using NAudio.Wave;

namespace WinFormsRadio.Forms
{
    public partial class RadioForm : Form
    {
        public WaveOutEvent WaveOutEvent;
        public RadioForm()
        {
            InitializeComponent();
            WaveOutEvent = new WaveOutEvent();
            WaveOutEvent.Volume = 0.5f;//change to use slider
        }

        private void RadioForm_Load(object sender, EventArgs e)
        {
            //check if stations path exists, prompt user if not
            string stationsPath = ConfigurationManager.AppSettings["StationsPath"] ?? string.Empty;
            if (string.IsNullOrEmpty(stationsPath) || !Path.Exists(stationsPath))
            {
                //prompt user for new path
            }

            //Get all files in the stations path with the .station extension
            List<string> stationFiles = Directory.GetFiles(stationsPath).Where(x => x.EndsWith(".station")).ToList();

            //Iterate over stationFiles, deserialize to station class and add it to a list of stations
            int xCoordinate = 12;
            int yCoordinate = 12;
            int itemSpacingFactor = 6;

            foreach (var station in stationFiles)
            {
                //Read .station file, deserialize to Station class
                var stationString = File.ReadAllText(station);
                Station? thisStation = JsonSerializer.Deserialize<Station>(stationString);

                //Create station label
                int labelWidth = this.Width;
                int labelHeight = 15;
                Size labelSize = new Size(labelWidth, labelHeight);
                Point labelLocation = new(xCoordinate, yCoordinate);
                Label stationLabel = new()
                {
                    Text = thisStation.Name,
                    Size = labelSize,
                    Location = labelLocation,
                };
                Controls.Add(stationLabel);
                yCoordinate += 20;

                //Create play button
                int buttonWidth = 75;
                int buttonHeight = 75;
                Size buttonSize = new(buttonWidth, buttonHeight);
                Point buttonLocation = new(xCoordinate, yCoordinate);
                Button playButton = new Button()
                {
                    Text = "Play",
                    Size = buttonSize,
                    Location = buttonLocation,
                    Tag = thisStation.URL
                };
                playButton.Click += new EventHandler(PlaybackToggle);
                Controls.Add(playButton);


                //Create station icon
                int pictureBoxWidth = 75;
                int pictureBoxHeight = 75;
                Size pictureBoxSize = new(pictureBoxWidth, pictureBoxHeight);
                Point pictureBoxLocation = new(xCoordinate + buttonWidth + itemSpacingFactor, yCoordinate);
                PictureBox pictureBox = new()
                {
                    ImageLocation = thisStation.Icon,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = pictureBoxSize,
                    Location = pictureBoxLocation
                };
                Controls.Add(pictureBox);

                //increment y coordinate value to avoid controls overlapping
                yCoordinate += (buttonHeight + itemSpacingFactor);
            }

            Height = yCoordinate + 75;
        }
        public void PlaybackToggle(Object sender, EventArgs e)
        {
            Button playbackButton = sender as Button;

            if (WaveOutEvent.PlaybackState == PlaybackState.Playing && playbackButton.Text == "Play")
            {
                MessageBox.Show("Please Stop Current Stream Before Starting Another", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (playbackButton.Text == "Play")
            {
                string stationURL = playbackButton.Tag as string;
                MediaFoundationReader mediaFoundationReader = new(stationURL);
                WaveOutEvent.Init(mediaFoundationReader);
                WaveOutEvent.Play();

                playbackButton.Text = "Stop";
            }
            else
            {
                WaveOutEvent.Stop();

                playbackButton.Text = "Play";
            }
        }

        private void VolumeSliderBar_ValueChanged(object sender, EventArgs e)
        {
            float currentVolume = VolumeSliderBar.Value;
            float newVolume = 0f;
            if (currentVolume != 0)
            {
                newVolume = currentVolume / 100;
            }
            WaveOutEvent.Volume = newVolume;
        }
    }
}
