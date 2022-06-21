using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLearn
{
    public class DBHelper
    {
        /// <summary>
        /// 从配置文件中读取数据库的连接字符串
        /// </summary>
        public static string ConnStrings
        {
            //get { return ConnString; }
            get { return ConfigurationManager.ConnectionStrings["connString"].ConnectionString; }
        }
    }
}
