using DataClass;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DanoSoldatBPV
{
    public partial class AddSoldeir : Form
    {
        public AddSoldeir()
        {
            InitializeComponent();
            data3.Items.Clear();
            int year = DateTime.Now.Year - 18;
            for (int i = 0; i < 60; i++)
            {
                data3.Items.Add(year - i);
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            using (ArmyDBContext adb = new ArmyDBContext())
            {
                var exist_soldeir = adb.SoldierDatas.FirstOrDefault(p=>p.name==name.Text);
                if (exist_soldeir == null)
                {
                    SoldierData ASD = new SoldierData();
                    ASD.rank = rank.Text;
                    ASD.post = post.Text;
                    ASD.name = name.Text;
                    ASD.data = data1.Text + ' ' + data2.Text + ' ' + data3.Text;
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
                    adb.SoldierDatas.Add(ASD);
                    adb.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Такий солдат вже доданий до бази даних!!!");
                }
            }              
        }       
    }
}
