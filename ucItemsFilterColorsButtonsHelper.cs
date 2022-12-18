using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2R_MULTILAUNCHER
{
    public partial class ucItemsFilterColorsButtonsHelper : UserControl
    {
        public ucItemsFilterColorsButtonsHelper()
        {
            InitializeComponent();
        }

        private void btnColorHelper_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(((Button)sender).Text);

            Console.Beep();
        }

        private void ucItemsFilterColorsButtonsHelper_Load(object sender, EventArgs e)
        {

        }
    }
}
