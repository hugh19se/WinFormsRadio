# WinFormsRadio
Basic Radio App Using Windows Forms And [NAudio](https://github.com/naudio/NAudio)

![Application Screenshot](https://github.com/hugh19se/WinFormsRadio/blob/main/ReadmeScreenshot.png?raw=true)

 ## Station Files

Each station has an associated .station file. This is just a JSON file with a different extension. Below is an example:
```
{
  "name": "Radio X London",
  "icon": "https://cdn6.aptoide.com/imgs/9/3/c/93ceba9f75a2ef91b6dddab2f87dbaf0_icon.png",
  "url": "https://media-ice.musicradio.com/RadioXLondonMP3"
}
```
The default path for these files is set in the App.Config file:
```
<add key="StationsPath" value="./Stations"/>
```
