using System.Collections.Generic;

namespace zaraga.weather.Models
{
    internal class WeatherLanguages
    {
        internal WeatherLanguages()
        {
            Languages = new Dictionary<string, string>()
            {
                {"Arabic","ar"},
                {"Bengali","bn" },
                {"Bulgarian","bg" },
                {"Chinese (Simplified)","zh" },
                {"Chinese (Traditional)","zh-tw" },
                {"Czech","cs" },
                {"Danish","da" },
                {"Dutch","nl" },
                {"English","en" },
                {"Finnish","fi" },
                {"French","fr" },
                {"German","de" },
                {"Greek","el" },
                {"Hindi","hi" },
                {"Hungarian","hu" },
                {"Italian","it" },
                {"Japanese","ja" },
                {"Javanese","jv" },
                {"Korean","ko" },
                {"Mandarin","zh_cmn" },
                {"Marathi","mr" },
                {"Polish","pl" },
                {"Portuguese","pt"},
                {"Punjabi","pa"},
                {"Romanian","ro"},
                {"Russian","ru"},
                {"Serbian","sr"},
                {"Sinhalese","si"},
                {"Slovak","sk"},
                {"Spanish","es"},
                {"Swedish","sv"},
                {"Tamil","ta"},
                {"Telugu ","te"},
                {"Turkish ","tr"},
                {"Ukrainian ","uk"},
                {"Urdu ","ur"},
                {"Vietnamese ","vi"},
                {"Wu (Shanghainese) ","zh_wuu"},
                {"Xiang ","zh_hsn"},
                {"Yue (Cantonese) ","zh_yue"},
                {"Zulu ","zu"},
            };
        }

        public Dictionary<string, string> Languages { get; }
    }
}
