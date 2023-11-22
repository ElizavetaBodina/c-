using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace ЛР_5
{
    public partial class Form1 : Form
    {
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            bs.DataSource = GetStartList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bs;
            var col1 = new DataGridViewTextBoxColumn
            {
                Width = 180,
                Name = "PlanetName",
                HeaderText = "Планета",
                DataPropertyName = "PlanetName"
            };
            dataGridView1.Columns.Add(col1);
            var col2 = new DataGridViewTextBoxColumn
            {
                Width = 100,
                Name = "Year",
                HeaderText = "Год открытия",
                DataPropertyName = "Year"
            };
            dataGridView1.Columns.Add(col2);
            var col3 = new DataGridViewTextBoxColumn
            {
                Width = 180,
                Name = "Size",
                HeaderText = "Размер",
                DataPropertyName = "Size"
            };
            dataGridView1.Columns.Add(col3);
           
            var col4 = new DataGridViewTextBoxColumn
            {
                Width = 180,
                Name = "PathToSun",
                HeaderText = "Расстояние до Солнца",
                DataPropertyName = "PathToSun"
            };
            dataGridView1.Columns.Add(col4);
            
            var col5 = new DataGridViewTextBoxColumn
            {
                Width = 200,
                Name = "Group",
                HeaderText = "Группа",
                DataPropertyName = "Group"
            };
            dataGridView1.Columns.Add(col5);

            bindingNavigator1.BindingSource = bs;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.DataBindings.Add("ImageLocation", bs, "img", true);
            pictureBox1.DoubleClick += PictureBox_DoubleClick;

            propertyGrid1.DataBindings.Add("SelectedObject", bs, "");
            DataBindings.Add("Text", bs, "PlanetName");

            chart1.DataSource = from w in bs.DataSource as List<Planet>
                                             group w by w.Group into g
                                             select new { Group = g.Key, Avg = g.Average(w => w.Size) };
            chart1.Series[0].XValueMember = "Group";
            chart1.Series[0].YValueMembers = "Avg";
            chart1.Legends.Clear();
            chart1.Titles.Add("Средний размер по разным группам");
            bs.CurrentChanged += (o, e) => chart1.DataBind();


        }

        private List<Planet> GetStartList() => new List<Planet>
        {
            new Planet("Марс", 1534 ,"../../images/mars.jpeg",144000000, 228000000, "Земная"),
            new Planet("Венера",1865 ,"../../images/venera.jpg",460000000,108000000, "Земная"),
            new Planet("Юпитер", 1610 ,"../../images/jup.png", 62179000000,778000000, "Гиганты"),
            new Planet("Уран", 1781 ,"../../images/uran.jpeg",8115000000, 2800000000, "Гиганты"),
            new Planet("Меркурий", 1631 ,"../../images/merc.jpg",74000000, 58000000, "Земная")
        };
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Картинка в формате jpg|*.jpg|Картинка в формате jpeg|*.jpeg"
            };
            if (opf.ShowDialog() == DialogResult.OK)
            {
                (bs.Current as Planet).Img = opf.FileName;
                bs.ResetBindings(false);
            }
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.InitialDirectory = System.Environment.CurrentDirectory;
                sfd.Filter = "Файл в bin|*.bin|Файл в xml|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    Stream sw = new FileStream(sfd.FileName, FileMode.Open);
                    {
                        bs.DataSource = (List<Planet>)bin.Deserialize(sw);
                    }
                }
            }
            catch { }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = System.Environment.CurrentDirectory;
                sfd.Filter = "Файл в bin|*.bin|Файл в xml|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            BinarySerialize(sfd.FileName);
                            break;
                        case 2:
                            SaveXml(sfd.FileName);
                            break;
                    }
                }
            }
            catch { }
        }

        private void SaveXml(string file)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Planet>));
                Stream sw = new FileStream(file, FileMode.Create);
                {
                    ser.Serialize(sw, bs.DataSource);

                }
                sw.Close();
            }
            catch
            {

            }
        }

        private void BinarySerialize(string file)
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                Stream sw = new FileStream(file, FileMode.Create);
                {
                    bin.Serialize(sw, bs.DataSource);
                }
                sw.Close();
            }
            catch
            {

            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string s = toolStripTextBox1.Text;
            foreach (var v in dataGridView1.Rows)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (s != null)
                    {

                        if (r.Cells[0].Value != null)
                        {

                            if (r.Cells[0].Value.ToString().Contains(s))
                            {

                                r.Visible = true;
                            }
                            else
                            {
                                dataGridView1.CurrentCell = null;
                                r.Visible = false;

                            }

                        }

                        if (r.Cells[4].Value != null)
                        {

                            if (r.Cells[4].Value.ToString().Contains(s))
                            {

                                r.Visible = true;
                            }
                            else
                            {
                                dataGridView1.CurrentCell = null;
                                r.Visible = false;

                            }

                        }

                    }
                }
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {


        }
    }
}
