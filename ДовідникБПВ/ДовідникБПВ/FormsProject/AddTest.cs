using System;
using System.Drawing;
using System.Windows.Forms;
using DataClass;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DanoSoldatBPV
{
    public partial class AddTest : Form
    {
        int id_soldeir;
        public AddTest(int id)
        {
            InitializeComponent();
            id_soldeir = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (ArmyDBContext adb = new ArmyDBContext())
            {
                PsychoTest pt = new PsychoTest();
                pt.Name = test_name.Text;
                pt.Test = test.Text;
                pt.SoldeirDataID = id_soldeir;
                adb.PsychoTests.Add(pt);
                adb.SaveChanges();
            }
            Close();
        }
    }
}
