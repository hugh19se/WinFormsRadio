using System.Text.Json.Serialization;

namespace WinFormsRadio.Forms
{
    public class Station
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("url")]
        public string URL { get; set; }
    }
}