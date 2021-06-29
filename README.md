# DD-EXTRACONTROL - Distinctive Development

A **FiveM** resource coded in **C#** to get some hotkeys/keybinds to toggle extras on vehicles.

The resource includes 4 keybinds which can be setup for separate vehicles. So keybind 1 will use extra 1 on vehicle X and keybind 1 will use extra 5 on vehicle Y. They are FiveM keybinds, so they can be set in the menu so the players can customize the keybinds to their preference. The default keybinds and the description can be setup in the config.

Join our Discord if you are looking for support or just want to talk!
https://discord.distinctive-dev.com/

FiveM forum post: 

<p align="center">
  <a href="https://www.youtube.com/watch?v=0AygtwevKKQ">
    <img src="https://distinctive-dev.com/github/images/DD-EXTRACONTROL/DD-EXTRACONTROL-YT.png" target="_blank" width="500" >
  </a>
</p>
Vehicle used in the video:[2017SilveradoDOTTruck](https://www.lcpdfr.com/downloads/gta5mods/vehiclemodels/30534-non-els-fivem-ready-2017-silverado-dot-truck-moveable-arrowboard/ "2017 Silverado DOT Truck")


## Installation
1. Download the latest release [HERE](https://github.com/DistinctiveDevelopment/DD-EXTRACONTROL/releases "DD-EXTRACONTROL Releases")
2. Move the "DD-EXTRACONTROL" folder to your server resources.
3. Add “DD-EXTRACONTROL” to your server.cfg with start or ensure
4. Configure the config
5. Start the resource or reboot the server

## CONFIG
There are two configs in the resource, one for to setup the vehicles and one to setup the default keybinds and description for the keybinds. Make sure you are following the format. The script looks for the "gameName" in the meta files for the vehicle, be sure to setup the config with the same "gameName" as in the vehicle meta.

If you are testing out the resource and finding that the default keybinds are not changeing, this is because FiveM saves these keybinds.
You can find these keybinds here:
1. Go to C:\Users\[USERNAME]\AppData\Roaming\CitizenFX
2. Open fivem.cfg
3. Remove the lines with this resource name.
4. Restart Fivem. Keybinds will be set back to default values set in the config.

## Source Code
The source code is included inside the "source" folder

## Feedback
Any feedback on the resource is appreciated, this includes bugs, suggestions and improvements to the code.

## Changelog
**V1.0.0**
- Initial release
