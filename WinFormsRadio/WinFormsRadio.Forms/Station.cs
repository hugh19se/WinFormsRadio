using System.Text.Json.Serialization;

namespace WinFormsRadio.Forms
{
    public class Station
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string URL { get; set; } = string.Empty;
    }
}