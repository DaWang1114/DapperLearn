using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperLearn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //实例化PersonService类的对象
            PersonService person = new PersonService();
            List<Person> list = person.FindListByLastName(this.txtSet.Text.Trim());

            //绑定数据源
            listContent.DataSource = list;

            //显示成员
            listContent.DisplayMember = "email";
        }
    }
}
