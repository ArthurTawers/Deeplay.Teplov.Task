using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deeplay.Teplov.TestWork.View
{

    public interface IAddForm
    {
        event EventHandler AddLine;
        int idTable { get; set; }
        DateTime DateLine { get; set; }
        string FioLine { get; set; }
        string GenderLine { get; set; }
        string InfoLine { get; set; }

    }

    public partial class AddForm : Form,IAddForm
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public int idTable 
        { 
            get 
            {
                return comboBox1.SelectedIndex;
            } 
            set { }
        }

        public DateTime DateLine
        {
            get
            {
                DateTime dt;
                if (DateTime.TryParse(textBox_date .Text, out dt))
                    return dt;
                else
                {
                    throw new Exception("Неправильный формат даты!");
                }
            }
            set { }
        }

        public string FioLine
        {
            get
            {
                if (textBox_FIO.Text.Length!=0 || textBox_FIO.Text.Length<30)
                    return textBox_FIO.Text;
                else
                {
                    throw new Exception("Неверное кол-во знаков в строке ФИО");
                }
            }
            set { }
        }
        public string GenderLine
        {
            get
            {
                if (textBox_gender.Text.Length==3)
                    return textBox_gender.Text;
                else
                {
                    throw new Exception("Неверное кол-во знаков в строке Пол! Введите (муж/жен)");
                }
            }
            set { }
        }
        public string InfoLine
        {
            get
            {
                if (textBox_info.Text.Length!=0)
                    return textBox_info.Text;
                else
                {
                    throw new Exception("Неверное кол-во знаков в строке информация! ");
                }
            }
            set { }
        }

        public event EventHandler AddLine;

        private void AddForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    label8.Text = "ФИО руководителя";
                    break;
                case 1:
                    label8.Text =  "Название станка";
                    break;
                case 2:
                    label8.Text = "Отдел";
                    break;
                case 3:
                    label8.Text = "Подразделение";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddLine?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
