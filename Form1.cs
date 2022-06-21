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

        /// <summary>
        /// 添加数据的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonService personService = new PersonService();

            //Person person= new Person();    
            //person.first_name =this.txtFirstName.Text;
            //person.last_name =this.txtLastName.Text;
            //person.email = this.tetEamil.Text;
            //person.time = DateTime.Now;//现在的系统时间


            //C# 3.0语法 对象初始化器
            Person person = new Person()
            {
                first_name = this.txtFirstName.Text,
                last_name = this.txtLastName.Text,
                email = this.txtEmail.Text,
                time = DateTime.Now,
            };

            //可以调用PersonService 的InsertData方法传person对象
            var success = personService.InsertData(person);

            //条件判断
            //三元运算符 三目运算符
            MessageBox.Show(success ? "插入操作成功" : "插入操作失败");

        }

        /// <summary>
        /// 搜索按钮的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PersonService ps = new PersonService();
            int perID = int.Parse(this.txtSearch.Text.Trim());//获取用户输入的 id
            Person person=ps.FindByPersonId(perID);//

            //
            this.txtFirstNameupdat.Text = person.first_name;
            this.txtLastNameupdate.Text = person.last_name;
            this.txtEmailupdate.Text = person.email;
        }

        /// <summary>
        /// 更新按钮的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void  btnUpdate_Click(object sender, EventArgs e)
        {
            PersonService personService=new PersonService();

            Person person = new Person
            {
                id =Convert.ToInt32(this.txtSearch.Text.Trim()),//此id可以不写
                first_name = this.txtFirstNameupdat.Text,
                last_name=this.txtLastNameupdate.Text,
                email=this.txtEmailupdate.Text,
                time=DateTime.Now,
            };

            bool success = personService.UpdateDate(person);//调用更新方法

            MessageBox.Show(success ? "更新操作成功":"更新操作失败");
        }

        /// <summary>
        /// 删除按钮的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            PersonService ps = new PersonService();
            int perID = int.Parse(this.txtDelete.Text.Trim());//获取删除输入的 id
            bool success = ps.DeleteDate(perID);
            MessageBox.Show(success ? "删除成功" : "删除失败"); 
        }
    }
}
