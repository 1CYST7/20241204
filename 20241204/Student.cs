using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241204
{
    internal class Student  // 定義 Student 類別
    {
        public String StudentId { get; set; }  // 學生ID屬性，用來儲存學生的唯一識別碼
        public String StudentName { get; set; }  // 學生名稱屬性，用來儲存學生的名字

        // 重寫 ToString 方法，讓學生物件可以以字串形式表示
        public override string ToString()
        {
            return $"{StudentId} {StudentName}";  // 返回學生ID和學生名稱的字串表示
        }
    }
}
