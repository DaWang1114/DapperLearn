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
    }
}
