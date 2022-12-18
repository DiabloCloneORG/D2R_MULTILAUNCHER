using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2R_MULTILAUNCHER
{
    [Serializable]
    public class ConfigurationEntity : ICloneable
    {
        public bool ChangeD2RWindowTitle { get; set; }
        public bool KeepMultiLauncherWindowOnTop { get; set; }
        public bool UseDirectTxt { get; set; }
        public bool UseNoSound { get; set; }
        public bool UseLowQuality { get; set; }
        public bool UseWindowedMode { get; set; }
        public bool UseItemFilter { get; set; }
        public int DefaultRealmIndex { get; set; }

        public string ItemsFilterHideTemplateReplacement { get; set; }

        public string ItemsFilterCustomTemplate1Name { get; set; }
        public string ItemsFilterCustomTemplate1Preffix { get; set; }
        public string ItemsFilterCustomTemplate1Suffix { get; set; }
        public string ItemsFilterCustomTemplate2Name { get; set; }
        public string ItemsFilterCustomTemplate2Preffix { get; set; }
        public string ItemsFilterCustomTemplate2Suffix { get; set; }

        public string ItemsFilterCustomTemplate3Name { get; set; }
        public string ItemsFilterCustomTemplate3Preffix { get; set; }
        public string ItemsFilterCustomTemplate3Suffix { get; set; }
        public string ItemsFilterCustomTemplate4Name { get; set; }
        public string ItemsFilterCustomTemplate4Preffix { get; set; }
        public string ItemsFilterCustomTemplate4Suffix { get; set; }
        public string ItemsFilterCustomTemplate5Name { get; set; }
        public string ItemsFilterCustomTemplate5Preffix { get; set; }
        public string ItemsFilterCustomTemplate5Suffix { get; set; }



        public ConfigurationEntity() 
        {
            ChangeD2RWindowTitle = true;
            KeepMultiLauncherWindowOnTop = false;
            UseDirectTxt = true;
            UseNoSound = false;
            UseLowQuality = true;
            UseWindowedMode = true;
            UseItemFilter = false;
            DefaultRealmIndex = 0;

            ItemsFilterCustomTemplate1Name = "Icy Cellar";
            ItemsFilterCustomTemplate1Preffix = "ÿcT[ÿcN";
            ItemsFilterCustomTemplate1Suffix = "ÿcT]ÿc0";
            
            ItemsFilterCustomTemplate2Name = "Melting Lava";
            ItemsFilterCustomTemplate2Preffix = "ÿcS[ÿc8";
            ItemsFilterCustomTemplate2Suffix = "ÿcS]ÿc0";

            ItemsFilterCustomTemplate3Name = "Purple Candy"; 
            ItemsFilterCustomTemplate3Preffix = "ÿcO[ÿc;";
            ItemsFilterCustomTemplate3Suffix = "ÿcO]ÿc0";

            ItemsFilterCustomTemplate4Name = "Greedy Gold"; 
            ItemsFilterCustomTemplate4Preffix = "ÿc7[ÿc4";
            ItemsFilterCustomTemplate4Suffix = "ÿc7]ÿc0";
            
            ItemsFilterCustomTemplate5Name = "Dark Shadow";
            ItemsFilterCustomTemplate5Preffix = "ÿc5Xÿc6";
            ItemsFilterCustomTemplate5Suffix = "ÿc5]ÿc5";
            
            ItemsFilterHideTemplateReplacement = "_";
        }

        public static void SaveConfiguration<T>(ConfigurationEntity entity)
        {
            string filePath = "configuration.json";

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.WriteIndented = true;
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(stream, entity, jso);
            }
        }

        public void SaveConfiguration()
        {
            if (this == null) { return; }
            string filePath = "configuration.json";

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.WriteIndented = true;
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(stream, this, jso);
            }
        }

        public static ConfigurationEntity ReadConfiguration<T>()
        {
            ConfigurationEntity entity = null;
            string filePath = "configuration.json";
            
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                entity = (ConfigurationEntity)JsonSerializer.Deserialize(stream, typeof(ConfigurationEntity));
                System.GC.Collect();
            }

            return entity;
        }

        public void ReadConfiguration()
        {
            ConfigurationEntity entity = new ConfigurationEntity();
            string filePath = "configuration.json";

            try
            {
                using (Stream stream = File.Open(Application.StartupPath + @"\" + filePath, FileMode.Open))
                {
                    entity = (ConfigurationEntity)JsonSerializer.Deserialize(stream, typeof(ConfigurationEntity));
                }
                System.GC.Collect();
            }
            catch (System.IO.FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex.Message);
            }

            this.ChangeD2RWindowTitle = entity.ChangeD2RWindowTitle;
            this.DefaultRealmIndex = entity.DefaultRealmIndex;
            this.KeepMultiLauncherWindowOnTop = entity.KeepMultiLauncherWindowOnTop;
            this.UseDirectTxt = entity.UseDirectTxt;
            this.UseItemFilter = entity.UseItemFilter;
            this.UseLowQuality = entity.UseLowQuality;
            this.UseNoSound = entity.UseNoSound;
            this.UseWindowedMode = entity.UseWindowedMode;

            this.ItemsFilterCustomTemplate1Preffix = entity.ItemsFilterCustomTemplate1Preffix;
            this.ItemsFilterCustomTemplate1Suffix = entity.ItemsFilterCustomTemplate1Suffix;
            this.ItemsFilterCustomTemplate2Preffix = entity.ItemsFilterCustomTemplate2Preffix;
            this.ItemsFilterCustomTemplate2Suffix = entity.ItemsFilterCustomTemplate2Suffix;
            this.ItemsFilterCustomTemplate3Preffix = entity.ItemsFilterCustomTemplate3Preffix;
            this.ItemsFilterCustomTemplate3Suffix = entity.ItemsFilterCustomTemplate3Suffix;
            this.ItemsFilterCustomTemplate4Preffix = entity.ItemsFilterCustomTemplate4Preffix;
            this.ItemsFilterCustomTemplate4Suffix = entity.ItemsFilterCustomTemplate4Suffix;
            this.ItemsFilterCustomTemplate5Preffix = entity.ItemsFilterCustomTemplate5Preffix;
            this.ItemsFilterCustomTemplate5Suffix = entity.ItemsFilterCustomTemplate5Suffix;
            this.ItemsFilterHideTemplateReplacement = entity.ItemsFilterHideTemplateReplacement;

            this.ItemsFilterCustomTemplate1Name = entity.ItemsFilterCustomTemplate1Name;
            this.ItemsFilterCustomTemplate2Name = entity.ItemsFilterCustomTemplate2Name;
            this.ItemsFilterCustomTemplate3Name = entity.ItemsFilterCustomTemplate3Name;
            this.ItemsFilterCustomTemplate4Name = entity.ItemsFilterCustomTemplate4Name;
            this.ItemsFilterCustomTemplate5Name = entity.ItemsFilterCustomTemplate5Name;

            return;
        }

        public object Clone() { return this.MemberwiseClone(); }




    }
}
