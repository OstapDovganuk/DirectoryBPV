using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using DataClass;
using System.Linq;

namespace DanoSoldatBPV
{
    public partial class Main : Form
    {
       
        public Main()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "Звання";
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Name = "Прізвище, імя, по-батькові";
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Name = "Рота";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[4].Name = "Служба";
            ShowDataGrid();
            DataGridViewCheckBoxColumn chb = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chb);
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            foreach(var t in comboBox1.Items)
            {
                stringCollection.Add(t.ToString());
            }
            comboBox1.AutoCompleteCustomSource = stringCollection;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;        
            AutoCompleteStringCollection stringCollectionData = new AutoCompleteStringCollection();
            using (ArmyDBContext armyDB = new ArmyDBContext())
            {
                var sold = armyDB.SoldierDatas;
                foreach (var t in sold)
                {
                    stringCollectionData.Add(t.name.ToString());
                }
                Search_text.AutoCompleteCustomSource = stringCollectionData;
                Search_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Search_text.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
            
        }
        public void ShowDataGrid()
        {
            dataGridView1.Rows.Clear();
            string[] rows = new string[5];
            using (ArmyDBContext armyDB = new ArmyDBContext())
            {
                var sold = armyDB.SoldierDatas;
                foreach (var t in sold)
                {
                    rows[0] = t.SoldierDataID.ToString();
                    rows[1] = t.rank;
                    rows[2] = t.name;
                    rows[3] = t.rota;
                    rows[4] = t.serve;
                    dataGridView1.Rows.Add(rows);
                }
            }
        }
        private void AddSoldeir_Click(object sender, EventArgs e)
        {
            AddSoldeir adds = new AddSoldeir();
            adds.ShowDialog();
            ShowDataGrid();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            ShowDataGrid(Search_text.Text);
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Точно видалити?", "Видалити", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                using (ArmyDBContext adb = new ArmyDBContext())
                {
                    string name;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[dataGridView1.Columns[5].Name].Value) == true)
                        {
                            name = row.Cells["Прізвище, імя, по-батькові"].Value.ToString();

                            var sd = adb.SoldierDatas.FirstOrDefault(p => p.name == name);
                            var tests = adb.PsychoTests.Where(p => p.SoldeirDataID == sd.SoldierDataID);
                            if (tests != null)
                            {
                                foreach (var test in tests)
                                {
                                    adb.PsychoTests.Remove(test);
                                }
                            }
                            adb.SoldierDatas.Remove(sd);
                            adb.SaveChanges();
                        }
                    }
                    ShowDataGrid();
                }
            }
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idsoldeir;
            try
            {
                idsoldeir = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                SoldierData sd = new SoldierData();
                using (ArmyDBContext adb = new ArmyDBContext())
                {
                    sd = adb.SoldierDatas.FirstOrDefault(p => p.name == idsoldeir);
                }
                ShowDataSoldeir sds = new ShowDataSoldeir(sd);
                sds.ShowDialog();
                ShowDataGrid();
            }
            catch { }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Усі")
                {
                    ShowDataGrid();
                }
                else
                {
                    ShowDataGrid(comboBox1.SelectedItem.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Помилка даних фільтру");
            }
        }
        private void ShowDataGrid(string sort)
        {           
            dataGridView1.Rows.Clear();
            string[] rows = new string[5];
            using (ArmyDBContext armyDB = new ArmyDBContext())
            {
                var sold = armyDB.SoldierDatas.Where(p => p.rank == sort || p.rota==sort || p.name==sort);
                foreach (var t in sold)
                {
                    rows[0] = t.SoldierDataID.ToString();
                    rows[1] = t.rank;
                    rows[2] = t.name;
                    rows[3] = t.rota;
                    rows[4] = t.serve;
                    dataGridView1.Rows.Add(rows);
                }
            }
        }
        private void Search_text_TextChanged(object sender, EventArgs e)
        {
            ShowDataGrid();
        }
    }
}
