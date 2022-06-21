using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper; 
using System.Data.SqlClient;
using System.Data;

namespace DapperLearn
{
    /// <summary>
    /// PersonService类，实现相关 的业务逻辑
    /// 由于Dapper ORM的操作实际上是对IDbConnection类的拓展，所有的方法都是该类的拓展方法
    /// 所以在使用之前先实例化一个IDBConnection对象
    /// </summary>
    public class PersonService
    {
        public bool DeleteDate(int personId)
        {
            using (IDbConnection dbConnection = new SqlConnection(DBHelper.ConnStrings))
            {
                string sql = "delete from Person where id = @Id";
                
                int result = dbConnection.Execute(sql, new {Id = personId}); //执行删除功能
               
                return result > 0;
            }
        }

        /// <summary>
        /// 根据id 更新数据的方法
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool UpdateDate(Person person)
        {
            using(IDbConnection dbConnection = new SqlConnection(DBHelper.ConnStrings))
            {
                //准备更新语句
                string sql = "update Person set first_name= @first_name,last_name =@last_name, email= @email where id=@id  ";
                //执行更新语句
                int result = dbConnection.Execute(sql,person);

                return result > 0;
            }

        }

        /// <summary>
        /// 根据id 查询数据内容
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Person FindByPersonId(int personId)
        {
            using (IDbConnection dbConnection = new SqlConnection(DBHelper.ConnStrings))
            {
                string sql = "select * from Person where id = @id";
                IEnumerable<Person> persons = dbConnection.Query<Person>(sql, new { id = personId }); //执行查询功能
                return persons.FirstOrDefault();//返回序列中的第一个元素
            }
        }

        /// <summary>
        /// 根据用户查询用户集合
        /// </summary>
        /// <param name="lastname">用户姓氏</param>
        /// <returns></returns>
        public List<Person> FindListByLastName(string lastname)
        {
            //查询
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrings))
            {
                //1、 string sql = "select* from Person where last_name = 'Nias'";

                //2、 字符串拼接
                //string sql = "select* from Person where last_name = '" + lastname + "'";

                //3、Format格式化
                //string sql = string.Format("select* from Person where last_name = '{0}'", lastname);

                //4、C#6语法 $
                //string sql = $"select* from Person where last_name = '{lastname}'";
                //IEnumerable<Person> lst = db.Query<Person>(sql);//Query为db对象的拓展方法，返回值类型

                //string sql = $"select* from Person where last_name = 'kee' or '1' = '1' ";  //SQL注入问题

                //5、解决SQL注入问题
                string sql = $"select* from Person where last_name = @Lastname";
                IEnumerable<Person> lst = db.Query<Person>(sql, new { Lastname =lastname });

                return lst.ToList();//转化为List的类型返回
            }
        }

        /// <summary>
        /// 向数据库插入数据
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool InsertData(Person person)
        {
            using (IDbConnection dbConnection = new SqlConnection(DBHelper.ConnStrings))
            {
                //准备插入 的SQL语句
                string sql = "insert into Person( first_name, last_name, email, time) values ( @first_name, @last_name, @email, @time )";

                //调用Dapper中的IDbconnction的拓展方法Excute()来执行插入
                int result = dbConnection.Execute(sql, person);//第一个参数SQL语句 第二个参数据Person对象

                //bool sucess= true;//默认为true

                //if (result > 0)
                //{
                //    sucess = true;
                //}
                //else
                //{
                //   sucess= false;
                //}

                return result > 0;

            }
        }
    }
}
