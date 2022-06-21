using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperLearn
{
    public class Person
    {
        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime time { get; set; }

    }
}
