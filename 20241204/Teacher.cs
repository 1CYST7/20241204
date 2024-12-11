using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241204
{
    internal class Teacher  // 定義 Teacher 類別
    {
        public String TeacherName { get; set; }  // 學教師名稱屬性，用來儲存老師的名字

        public ObservableCollection<Course> TeachingCourses { get; set; }  // 學教師所教課程的可觀察集合，存儲老師教授的所有課程

        // Teacher 類別的建構函數，接收一個教師名稱，並初始化 TeachingCourses 為一個空的 ObservableCollection
        public Teacher(String TeacherName)
        {
            this.TeacherName = TeacherName;  // 設定教師名稱屬性
            TeachingCourses = new ObservableCollection<Course>();  // 初始化 TeachingCourses 為一個空的可觀察集合
        }

        // 重寫 ToString 方法，讓老師名稱可以以字串形式返回
        public override string ToString()
        {
            return TeacherName;  // 返回老師的名稱
        }
    }
}
