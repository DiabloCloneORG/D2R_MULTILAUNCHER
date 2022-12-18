using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace D2R_MULTILAUNCHER
{
    public delegate void onItemFilterEnhancedEntityUpdatedEventHandler(ItemFilterEnhancedEntity updated_entity);

    [Serializable]
    public class ItemFilterEnhancedEntity : ItemFilterBaseEntity, ICloneable
    {
        public bool NoTemplateOveride { get; set; }
        public bool useHideTemplateOveride { get; set; }
        public bool useGrayTemplateOveride { get; set; }
        public bool useWhiteTemplateOveride { get; set; }
        public bool useHighlightTemplateOveride { get; set; }
        public bool useCustomTemplate1Overide { get; set; }
        public bool useCustomTemplate2Overide { get; set; }
        public bool useCustomTemplate3Overide { get; set; }
        public bool useCustomTemplate4Overide { get; set; }
        public bool useCustomTemplate5Overide { get; set; }


        public ItemFilterEnhancedEntity() 
        {
            NoTemplateOveride = true;
            useHideTemplateOveride = false;
            useGrayTemplateOveride = false;
            useWhiteTemplateOveride = false;
            useHighlightTemplateOveride = false;

            useCustomTemplate1Overide = false;
            useCustomTemplate2Overide = false;
            useCustomTemplate3Overide = false;
            useCustomTemplate4Overide = false;
            useCustomTemplate5Overide = false;

        }

        

        public new object Clone() { return this.MemberwiseClone(); }




    }
}
