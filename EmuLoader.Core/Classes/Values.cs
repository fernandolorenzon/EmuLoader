using System;
using System.Collections.Generic;

namespace EmuLoader.Core.Classes
{
    public static class Values
    {
        public static string xmlPath = "data";
        //public static string xmlFile = "data.xml";
        public static string xmlFilePlatforms = "platforms.xml";
        public static string xmlFileLabels = "labels.xml";
        public static string xmlFileGenres = "genres.xml";
        public static string xmlFileRoms = "roms.xml";
        public static string xmlFileConfig = "config.xml";
        public static string xmlFileRomStatus = "romstatus.xml";
        public static string xmlFileRomLabels = "romlabels.xml";

        public static List<string> Status = new List<string>() { "Queue", "Playing", "Played", "Finished"};
        
        public static string apikeyfile = "apikey.txt";
        public static string PicturesPath = "pictures";
        public static int max = 255 * 3;
        public static int Threshold = Convert.ToInt32(max / 2);
        public static string BoxartFolder = "boxart";
        public static string TitleFolder = "title";
        public static string GameplayFolder = "gameplay";
        public static string DefaultCommand = "%EMUPATH% %ROMPATH%";
        public static string PublishersFile = "publishers.json";
        public static string DevelopersFile = "developers.json";
        public static string JsonFolder = "json";
        public static string BackupFolder = "backup";
        public static string RetroarchCommand = "%EMUPATH% -L cores\\[CORE] %ROMPATH%";
        public static string BaseAPIURL = "https://api.thegamesdb.net";
        public static Dictionary<string, string> MAMERomNames = null;
        public static string PlatformsXML =
            @"<Data>
            <Platforms>
                <Platform>
                    <id>25</id>
                    <name>3DO</name>
                    <alias>3do</alias>
                </Platform>
                <Platform>
                    <id>4911</id>
                    <name>Amiga</name>
                    <alias>amiga</alias>
                </Platform>
                <Platform>
                    <id>4914</id>
                    <name>Amstrad CPC</name>
                    <alias>amstrad-cpc</alias>
                </Platform>
                <Platform>
                    <id>23</id>
                    <name>Arcade</name>
                    <alias>arcade</alias>
                </Platform>
                <Platform>
                    <id>22</id>
                    <name>Atari 2600</name>
                    <alias>atari-2600</alias>
                </Platform>
                <Platform>
                    <id>26</id>
                    <name>Atari 5200</name>
                    <alias>atari-5200</alias>
                </Platform>
                <Platform>
                    <id>27</id>
                    <name>Atari 7800</name>
                    <alias>atari-7800</alias>
                </Platform>
                <Platform>
                    <id>28</id>
                    <name>Atari Jaguar</name>
                    <alias>atari-jaguar</alias>
                </Platform>
                <Platform>
                    <id>29</id>
                    <name>Atari Jaguar CD</name>
                    <alias>atari-jaguar-cd</alias>
                </Platform>
                <Platform>
                    <id>30</id>
                    <name>Atari XE</name>
                    <alias>atari-xe</alias>
                </Platform>
                <Platform>
                    <id>31</id>
                    <name>Colecovision</name>
                    <alias>colecovision</alias>
                </Platform>
                <Platform>
                    <id>40</id>
                    <name>Commodore 64</name>
                    <alias>commodore-64</alias>
                </Platform>
                <Platform>
                    <id>32</id>
                    <name>Intellivision</name>
                    <alias>intellivision</alias>
                </Platform>
                <Platform>
                    <id>37</id>
                    <name>Mac OS</name>
                    <alias>mac-os</alias>
                </Platform>
                <Platform>
                    <id>14</id>
                    <name>Microsoft Xbox</name>
                    <alias>microsoft-xbox</alias>
                </Platform>
                <Platform>
                    <id>15</id>
                    <name>Microsoft Xbox 360</name>
                    <alias>microsoft-xbox-360</alias>
                </Platform>
                <Platform>
                    <id>24</id>
                    <name>NeoGeo</name>
                    <alias>neogeo</alias>
                </Platform>
                <Platform>
                    <id>4923</id>
                    <name>Neo Geo Pocket Color</name>
                    <alias>neo-geo-pocket-color</alias>
                </Platform>
                <Platform>
                    <id>4912</id>
                    <name>Nintendo 3DS</name>
                    <alias>nintendo-3ds</alias>
                </Platform>
                <Platform>
                    <id>3</id>
                    <name>Nintendo 64</name>
                    <alias>nintendo-64</alias>
                </Platform>
                <Platform>
                    <id>8</id>
                    <name>Nintendo DS</name>
                    <alias>nintendo-ds</alias>
                </Platform>
                <Platform>
                    <id>7</id>
                    <name>Nintendo Entertainment System (NES)</name>
                    <alias>nintendo-entertainment-system-nes</alias>
                </Platform>
                <Platform>
                    <id>4</id>
                    <name>Nintendo Game Boy</name>
                    <alias>nintendo-gameboy</alias>
                </Platform>
                <Platform>
                    <id>5</id>
                    <name>Nintendo Game Boy Advance</name>
                    <alias>nintendo-gameboy-advance</alias>
                </Platform>
                <Platform>
                    <id>41</id>
                    <name>Nintendo Game Boy Color</name>
                    <alias>nintendo-gameboy-color</alias>
                </Platform>
                <Platform>
                    <id>2</id>
                    <name>Nintendo GameCube</name>
                    <alias>nintendo-gamecube</alias>
                </Platform>
                <Platform>
                    <id>9</id>
                    <name>Nintendo Wii</name>
                    <alias>nintendo-wii</alias>
                </Platform>
                <Platform>
                    <id>38</id>
                    <name>Nintendo Wii U</name>
                    <alias>nintendo-wii-u</alias>
                </Platform>
                <Platform>
                    <id>1</id>
                    <name>PC</name>
                    <alias>pc</alias>
                </Platform>
                <Platform>
                    <id>33</id>
                    <name>Sega 32X</name>
                    <alias>sega-32x</alias>
                </Platform>
                <Platform>
                    <id>21</id>
                    <name>Sega CD</name>
                    <alias>sega-cd</alias>
                </Platform>
                <Platform>
                    <id>16</id>
                    <name>Sega Dreamcast</name>
                    <alias>sega-dreamcast</alias>
                </Platform>
                <Platform>
                    <id>20</id>
                    <name>Sega Game Gear</name>
                    <alias>sega-game-gear</alias>
                </Platform>
                <Platform>
                    <id>18</id>
                    <name>Sega Genesis</name>
                    <alias>sega-genesis</alias>
                </Platform>
                <Platform>
                    <id>35</id>
                    <name>Sega Master System</name>
                    <alias>sega-master-system</alias>
                </Platform>
                <Platform>
                    <id>36</id>
                    <name>Sega Mega Drive</name>
                    <alias>sega-mega-drive</alias>
                </Platform>
                <Platform>
                    <id>17</id>
                    <name>Sega Saturn</name>
                    <alias>sega-saturn</alias>
                </Platform>
                <Platform>
                    <id>4913</id>
                    <name>Sinclair ZX Spectrum</name>
                    <alias>sinclair-zx-spectrum</alias>
                </Platform>
                <Platform>
                    <id>10</id>
                    <name>Sony Playstation</name>
                    <alias>sony-playstation</alias>
                </Platform>
                <Platform>
                    <id>11</id>
                    <name>Sony Playstation 2</name>
                    <alias>sony-playstation-2</alias>
                </Platform>
                <Platform>
                    <id>12</id>
                    <name>Sony Playstation 3</name>
                    <alias>sony-playstation-3</alias>
                </Platform>
                <Platform>
                    <id>39</id>
                    <name>Sony Playstation Vita</name>
                    <alias>sony-playstation-vita</alias>
                </Platform>
                <Platform>
                    <id>13</id>
                    <name>Sony PSP</name>
                    <alias>sony-psp</alias>
                </Platform>
                <Platform>
                    <id>6</id>
                    <name>Super Nintendo (SNES)</name>
                    <alias>super-nintendo-snes</alias>
                </Platform>
                <Platform>
                    <id>34</id>
                    <name>TurboGrafx 16</name>
                    <alias>turbografx-16</alias>
                </Platform>
                <Platform>
                    <id>4955</id>
                    <name>TurboGrafx CD</name>
                    <alias>turbo-grafx-cd</alias>
                </Platform>
                <Platform>
                    <id>4936</id>
                    <name>Famicom Disk System</name>
                    <alias>fds</alias>
                </Platform>
               <Platform>
                    <id>4956</id>
                    <name>Neo Geo CD</name>
                    <alias>neo-geo-cd</alias>
                </Platform>
               <Platform>
                    <id>4929</id>
                    <name>MSX</name>
                    <alias>msx</alias>
                </Platform>
               <Platform>
                    <id>4924</id>
                    <name>Atari Lynx</name>
                    <alias>atari-lynx</alias>
                </Platform>
               <Platform>
                    <id>4925</id>
                    <name>WonderSwan</name>
                    <alias>wonderswan</alias>
                </Platform>
               <Platform>
                    <id>4926</id>
                    <name>WonderSwan Color</name>
                    <alias>wonderswan-color</alias>
                </Platform>
               <Platform>
                    <id>4927</id>
                    <name>Magnavox Odyssey 2</name>
                    <alias>magnavox-odyssey-2</alias>
                </Platform>
               <Platform>
                    <id>4928</id>
                    <name>Fairchild Channel F</name>
                    <alias>fairchild</alias>
                </Platform>
               <Platform>
                    <id>4930</id>
                    <name>PC-FX</name>
                    <alias>pcfx</alias>
                </Platform>
               <Platform>
                    <id>4931</id>
                    <name>Sharp X68000</name>
                    <alias>x68</alias>
                </Platform>
            </Platforms>
        </Data>";
    }
}