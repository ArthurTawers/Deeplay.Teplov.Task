using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deeplay.Teplov.TestWork.View
{
    public delegate void IdTableHandler(int i);
    public interface IMainForm
    {
        IAddForm AddForm { get; }
        event EventHandler Initialize;
        event IdTableHandler idTableChange;
        event EventHandler UpdateLine;
        event EventHandler DeleteLine;
        event EventHandler PromotionLine;
        event EventHandler SelectDivision;
       

        DataGridView dgsView { get; set; }
        DataSet dgsDataSet { get; set; }
        int CurrentIdSet { get; set; }
        string CurrentDivision { get; }
        int IdLine { get;  } 
        DateTime DateLine { get; }
        string FioLine { get; }
        string GenderLine { get;  }
        string InfoLine { get;  }
        object[] DivisionItems { set; }

    }

    public partial class MainForm : Form, IMainForm
    {
        DataGridView[] dataGrids;
        DataSet currentDataSet;
        AddForm addForm;
        
        public MainForm()
        {
            addForm = new AddForm();
            InitializeComponent();
            dataGrids = new DataGridView[4] { dataGridView1, dataGridView2, dataGridView3, dataGridView4, };
        }
        public DataGridView dgsView 
        {
            get
            {
                return dataGrids[Lb.SelectedIndex];
            }
            set
            {
                dataGrids[Lb.SelectedIndex] = value;
            }
        }

        public DataSet dgsDataSet { get => currentDataSet; set => currentDataSet = value; }
        public int CurrentIdSet { get; set; }
        public int IdLine {
            get 
            {
                return int.Parse(textBox_id.Text);
            } 

        }
        public DateTime DateLine { 
            get
            {
                DateTime dt;
                if (DateTime.TryParse(textBox_type.Text, out dt))
                    return dt;
                else
                {
                    throw new Exception("Неправильный формат даты!");
                }
            }

        }

        public string FioLine {
            get
            {
                if (textBox_count.Text.Length!=0 || textBox_count.Text.Length<30)
                    return textBox_count.Text;
                else
                {
                    throw new Exception("Неверное кол-во знаков в строке ФИО");
                }
            }

        }
        public string GenderLine {
            get
            {
                if (textBox_postav.Text.Length==3)
                    return textBox_postav.Text;
                else
                {
                    throw new Exception("Неверное кол-во знаков в строке Пол! Введите (муж/жен)");
                }
            }

        }
        public string InfoLine {
            get
            {
                if (textBox_price.Text.Length!=0)
                    return textBox_price.Text;
                else
                {
                    throw new Exception("Неверное кол-во знаков в строке информация! ");
                }
            }

        }

        public IAddForm AddForm 
        { 
            get => addForm;
        }
        public object[] DivisionItems { set { comboBox2.Items.Clear(); comboBox2.Items.AddRange(value); } }

        public string CurrentDivision => comboBox2.Text;

        public event EventHandler Initialize;
        public event IdTableHandler idTableChange;
        public event EventHandler UpdateLine;
        public event EventHandler DeleteLine;
        public event EventHandler PromotionLine;
        public event EventHandler SelectDivision;

        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTableChange(Lb.SelectedIndex);
            Initialize?.Invoke(this, EventArgs.Empty);  
            if(dgsView.Rows.Count!=0)
                textBoxes_TableChanged(dgsView.Rows[dgsView.CurrentCell.RowIndex]);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialize?.Invoke(this, EventArgs.Empty);
        }

        private void but_newPost_Click(object sender, EventArgs e)
        {
            addForm.ShowDialog();
            Initialize?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_IdChanged((DataGridView)sender, e);
        }      
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_IdChanged((DataGridView)sender, e);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_IdChanged((DataGridView)sender, e);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_IdChanged((DataGridView)sender, e);
        }

        private void DataGridView_IdChanged(DataGridView sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<sender.Rows.Count && e.RowIndex>=0)
                CurrentIdSet = e.RowIndex;
            else
            {
                CurrentIdSet = 0;
                return;
            }
                
            DataGridViewRow row = sender.Rows[CurrentIdSet];

            textBoxes_TableChanged(row);
        }

        private void textBoxes_TableChanged(DataGridViewRow row)
        {
            textBox_id.Text = row.Cells[0].Value.ToString();
            textBox_type.Text = $"{((DateTime)row.Cells[1].Value).ToString("d")}";
            textBox_count.Text = row.Cells[2].Value.ToString();
            textBox_postav.Text = row.Cells[3].Value.ToString();
            textBox_price.Text = row.Cells[4].Value.ToString();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(dgsView.Rows.Count != 0 && dgsView.CurrentCell != null)
                textBoxes_TableChanged(dgsView.Rows[dgsView.CurrentCell.RowIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateLine?.Invoke(this, EventArgs.Empty);
            Initialize?.Invoke(this, EventArgs.Empty);
            
        }

        private void but_Del_Click(object sender, EventArgs e)
        {
            DeleteLine?.Invoke(this, EventArgs.Empty);
            Initialize?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PromotionLine?.Invoke(this, EventArgs.Empty);
            Initialize?.Invoke(this, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectDivision?.Invoke(this, EventArgs.Empty);
        }
    }

}
