using DataClass;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FormsProject
{
    public partial class ShowTest : Form
    {
        public ShowTest(int id)
        {
            InitializeComponent();
            using (ArmyDBContext adb = new ArmyDBContext())
            {
                var test = adb.PsychoTests.Where(p => p.SoldeirDataID == id);
                foreach(var b in test)
                {
                    Test.Text += b.Name + '\n';
                    Test.Text += b.Test + '\n';
                }
            }
        }
    }
}
