using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace D2R_MULTILAUNCHER
{
    public delegate void onItemFilterBaseEntityUpdatedEventHandler(ItemFilterBaseEntity updated_entity);

    [Serializable]
    public class ItemFilterBaseEntity : ICloneable
    {
        public int id { get; set; }

        public string Key { get; set; }

        public string enUS { get; set; }
        public string zhTW { get; set; }
        public string deDE { get; set; }
        public string esES { get; set; }
        public string frFR { get; set; }
        public string itIT { get; set; }
        public string koKR { get; set; }
        public string plPL { get; set; }
        public string esMX { get; set; }
        public string jaJP { get; set; }
        public string ptBR { get; set; }
        public string ruRU { get; set; }
        public string zhCN { get; set; }


        public ItemFilterBaseEntity() 
        {
            id = 0;
            Key = "";
            enUS = "";
            zhTW = "";
            deDE = "";
            esES = "";
            frFR = "";
            itIT = "";
            koKR = "";
            plPL = "";
            esMX = "";
            jaJP = "";
            ptBR = "";
            ruRU = "";
            zhCN = "";
        }

        public void SetAllLanguageText(string text)
        {
            enUS = text;
            zhTW = text;
            deDE = text;
            esES = text;
            frFR = text;
            itIT = text;
            koKR = text;
            plPL = text;
            esMX = text;
            jaJP = text;
            ptBR = text;
            ruRU = text;
            zhCN = text;
        }

        public void AddPrefixToAllLanguageText(string prefix)
        {
            deDE = prefix + deDE;
            enUS = prefix + enUS;
            esES = prefix + esES;
            esMX = prefix + esMX;
            frFR = prefix + frFR;
            itIT = prefix + itIT;
            koKR = prefix + koKR;
            plPL = prefix + plPL;
            jaJP = prefix + jaJP;
            ptBR = prefix + ptBR;
            ruRU = prefix + ruRU;
            zhCN = prefix + zhCN;
            zhTW = prefix + zhTW;
        }

        public void AddSuffixToAllLanguageText(string suffix)
        {
            deDE = deDE + suffix;
            enUS = enUS + suffix;
            esES = esES + suffix;
            esMX = esMX + suffix;
            frFR = frFR + suffix;
            itIT = itIT + suffix;
            koKR = koKR + suffix;
            plPL = plPL + suffix;
            jaJP = jaJP + suffix;
            ptBR = ptBR + suffix;
            ruRU = ruRU + suffix;
            zhCN = zhCN + suffix;
            zhTW = zhTW + suffix;
        }

        public object Clone() { return this.MemberwiseClone(); }




    }
}
