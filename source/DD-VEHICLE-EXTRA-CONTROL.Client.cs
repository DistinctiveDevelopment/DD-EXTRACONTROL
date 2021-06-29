//MIT License

//Copyright (c) 2021 Distinctive Development - https://discord.distinctive-dev.com/

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

// INPUTS LIST
// https://docs.fivem.net/docs/game-references/input-mapper-parameter-ids/keyboard/
//
// Find fivem keybinds cfg to reset local keybinds for this resource
// 1. Go to C:\Users\[USERNAME]\AppData\Roaming\CitizenFX
// 2. Open fivem.cfg
// 3. Remove lines with this recourse name
// 4. Restart Fivem. Keybinds will be set back to default values

using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.Native.API;
using Newtonsoft.Json;

namespace DD_ExtraControl
{
    public class DD_ExtraControl : BaseScript
    {
        internal class Config
        {
            public string Extra1_Description { get; set; }
            public string Extra1_Input { get; set; }

            public string Extra2_Description { get; set; }
            public string Extra2_Input { get; set; }

            public string Extra3_Description { get; set; }
            public string Extra3_Input { get; set; }

            public string Extra4_Description { get; set; }
            public string Extra4_Input { get; set; }
        }

        internal class Whitelist
        {
            public string Model { get; set; }

            public int Extra1 { get; set; }
            public int Extra2 { get; set; }
            public int Extra3 { get; set; }
            public int Extra4 { get; set; }
        }

        private Config _config = new Config();
        private List<Whitelist> _whitelist = new List<Whitelist>();

        private enum ExtraHotkey
        {
            Extra1,
            Extra2,
            Extra3,
            Extra4,
        }

        public DD_ExtraControl()
        {
            LoadConfig();
        }

        private async void LoadConfig()
        {
            string controls = LoadResourceFile(GetCurrentResourceName(), "config-controls.json") ?? "[]";
            _config = JsonConvert.DeserializeObject<Config>(controls);
            string extras = LoadResourceFile(GetCurrentResourceName(), "config-extras.json") ?? "[]";
            _whitelist = JsonConvert.DeserializeObject<List<Whitelist>>(extras);

            await Delay(50);
            Commands();
        }

        private void Commands()
        {
            RegisterKeyMapping("DD-ExtraControl-1", _config.Extra1_Description, "keyboard", _config.Extra1_Input);
            RegisterKeyMapping("DD-ExtraControl-2", _config.Extra2_Description, "keyboard", _config.Extra2_Input);
            RegisterKeyMapping("DD-ExtraControl-3", _config.Extra3_Description, "keyboard", _config.Extra3_Input);
            RegisterKeyMapping("DD-ExtraControl-4", _config.Extra4_Description, "keyboard", _config.Extra4_Input);

            RegisterCommand("DD-ExtraControl-1", new Action<int, List<object>, string>((src, args, raw) => ToggleExtra(ExtraHotkey.Extra1)), false);
            RegisterCommand("DD-ExtraControl-2", new Action<int, List<object>, string>((src, args, raw) => ToggleExtra(ExtraHotkey.Extra2)), false);
            RegisterCommand("DD-ExtraControl-3", new Action<int, List<object>, string>((src, args, raw) => ToggleExtra(ExtraHotkey.Extra3)), false);
            RegisterCommand("DD-ExtraControl-4", new Action<int, List<object>, string>((src, args, raw) => ToggleExtra(ExtraHotkey.Extra4)), false);
        }

        private void ToggleExtra(ExtraHotkey ExtraType)
        {
            Ped playerPed = Game.PlayerPed;
            if (IsPedInAnyVehicle(playerPed.Handle, false))
            {
                Vehicle vehicle = playerPed.CurrentVehicle;
                //SetVehicleAutoRepairDisabled(vehicle.Handle, true);

                if (Entity.Exists(vehicle))
                {
                    Whitelist searchModel = _whitelist.Find((Whitelist v) => string.Equals(v.Model, vehicle.DisplayName, StringComparison.OrdinalIgnoreCase));
                    if (searchModel != null)
                    {
                        switch (ExtraType)
                        {
                            case ExtraHotkey.Extra1:
                                if (searchModel.Extra1 != 0)
                                {
                                    ToggelExtra(vehicle, searchModel.Extra1);
                                }
                                break;
                            case ExtraHotkey.Extra2:
                                if (searchModel.Extra2 != 0)
                                {
                                    ToggelExtra(vehicle, searchModel.Extra2);
                                }
                                break;
                            case ExtraHotkey.Extra3:
                                if (searchModel.Extra3 != 0)
                                {
                                    ToggelExtra(vehicle, searchModel.Extra3);
                                }
                                break;
                            case ExtraHotkey.Extra4:
                                if (searchModel.Extra4 != 0)
                                {
                                    ToggelExtra(vehicle, searchModel.Extra4);
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void ToggelExtra(Vehicle vehicle, int extra)
        {
            if (vehicle.IsExtraOn(extra))
            {
                vehicle.ToggleExtra(extra, false);
            }
            else
            {
                vehicle.ToggleExtra(extra, true);
            }
        }
    }
}
