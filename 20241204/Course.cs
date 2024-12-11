using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241204
{
    internal class Course  // 定義課程類別
    {
        public String CourseId { get; set; }  // 課程ID屬性，用來標識課程
        public String CourseName { get; set; }  // 課程名稱屬性，存放課程名稱
        public String CourseDescription { get; set; }  // 課程描述屬性，存放課程內容描述
        public String Type { get; set; }  // 課程類型屬性，標識課程是必修還是選修
        public int Points { get; set; }  // 課程學分屬性，存放課程的學分數
        public String OpeningClass { get; set; }  // 開設班級屬性，存放開設該課程的班級名稱
        public Teacher Tutor { get; set; }  // 指定授課老師的屬性，與 Teacher 類別建立關聯

        // Course 類別的建構函數，接收一個 Teacher 物件並將其設為課程的授課老師
        public Course(Teacher tutor)
        {
            Tutor = tutor;  // 將傳入的 Teacher 物件賦值給屬性 Tutor
        }
    }
}
