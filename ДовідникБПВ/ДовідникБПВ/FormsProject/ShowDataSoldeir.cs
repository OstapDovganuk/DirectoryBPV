using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DataClass;
using FormsProject;

namespace DanoSoldatBPV
{
    public partial class ShowDataSoldeir : Form
    {
        SoldierData soldeir = new SoldierData();
        public ShowDataSoldeir(SoldierData soldeir_data)
        {
            InitializeComponent();
            soldeir = soldeir_data;
            if (soldeir != null)
            {
                rank.Text = soldeir.rank;
                post.Text = soldeir.post;
                name.Text = soldeir.name;
                data.Text = soldeir.data;
                adress.Text = soldeir.adress;
                education.Text = soldeir.education;
                maritalstatus.Text = soldeir.maritalstatus;
                father.Text = soldeir.father;
                mother.Text = soldeir.mother;
                brother.Text = soldeir.brother.Replace('$', '\n');
                rota.Text = soldeir.rota;
                grandmm.Text = soldeir.grandmm;
                broughtup.Text = soldeir.broughtup;
                crime.Text = soldeir.crime;
                border.Text = soldeir.border;
                commissariat.Text = soldeir.commissariat;
                health.Text = soldeir.health;
                hobby.Text = soldeir.hobby;
                future.Text = soldeir.future;
                familyKiev.Text = soldeir.familyKiev;
                familyborder.Text = soldeir.familyborder;
                grandfm.Text = soldeir.grandfm;
                grandmf.Text = soldeir.grandmf;
                grandff.Text = soldeir.grandff;
                postponement.Text = soldeir.postponement;
                comboBox1.Text = soldeir.serve;
            }
        }
        private void ShowTest_Click(object sender, EventArgs e)
        {
            ShowTest st = new ShowTest(soldeir.SoldierDataID);
            st.ShowDialog();
        }
        private void AddTest_Click(object sender, EventArgs e)
        {
            AddTest add_test = new AddTest(soldeir.SoldierDataID);
            add_test.ShowDialog();
        }
        private void Update_Click(object sender, EventArgs e)
        {
            using (ArmyDBContext adb = new ArmyDBContext())
            {
                var ASD = adb.SoldierDatas.FirstOrDefault(p => p.SoldierDataID == soldeir.SoldierDataID);
                if (ASD != null)
                {
                    ASD.rank = rank.Text;
                    ASD.post = post.Text;
                    ASD.name = name.Text;
                    ASD.data = data.Text;
                    ASD.adress = adress.Text;
                    ASD.education = education.Text;
                    ASD.maritalstatus = maritalstatus.Text;
                    ASD.father = father.Text;
                    ASD.mother = mother.Text;
                    ASD.brother = brother.Text.Replace('\n', '$');
                    ASD.grandmm = grandmm.Text;
                    ASD.grandfm = grandfm.Text;
                    ASD.grandmf = grandmf.Text;
                    ASD.grandff = grandff.Text;
                    ASD.broughtup = broughtup.Text;
                    ASD.crime = crime.Text;
                    ASD.border = border.Text;
                    ASD.familyborder = familyborder.Text;
                    ASD.commissariat = commissariat.Text;
                    ASD.postponement = postponement.Text;
                    ASD.health = health.Text;
                    ASD.hobby = hobby.Text;
                    ASD.future = future.Text;
                    ASD.familyKiev = familyKiev.Text;
                    ASD.rota = rota.Text;
                    ASD.serve = comboBox1.Text;
                    adb.SaveChanges();
                }
            }
        }
    }
}
