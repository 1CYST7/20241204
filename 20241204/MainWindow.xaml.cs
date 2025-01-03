using Microsoft.Win32;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace _20241204
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();
        List<Teacher> teachers = new List<Teacher>();
        List<Record> records = new List<Record>();


        Student selectedStudent = null;
        Course selectedCourse = null;
        Teacher selectedTeacher = null;
        Record selectedRecord = null;
        public MainWindow()
        {
            InitializeComponent();
            InitializeData();  // 初始化資料，將學生、老師、課程等資料加入清單中
            cmbStudent.ItemsSource = students;  // 將學生資料設定為 ComboBox 的資料來源
            cmbStudent.SelectedIndex = 0;  // 預設選擇第一位學生
            // 將以教師分類的課程清單設定為 TreeView 的資料來源
            tvTeacher.ItemsSource = teachers;
        }
        private void InitializeData()
        {
            // 新增學生資料
            students.Add(new Student { StudentId = "S001", StudentName = "陳小明" });  // 新增學生資料 S001
            students.Add(new Student { StudentId = "S002", StudentName = "林小華" });  // 新增學生資料 S002
            students.Add(new Student { StudentId = "S003", StudentName = "張小英" });  // 新增學生資料 S003
            students.Add(new Student { StudentId = "S004", StudentName = "王小強" });  // 新增學生資料 S004

            // 新增老師資料
            Teacher teacher1 = new Teacher("陳定宏");  // 創建一位老師
            // 為老師陳定宏新增課程資料
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseId = "C001", CourseName = "視窗程式設計", CourseDescription = "本課程使用WPF類別庫和C#語言來設計桌面視窗應用程式", Type = "必修", Points = 6, OpeningClass = "五專資工三甲" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseId = "C002", CourseName = "視窗程式設計", CourseDescription = "本課程使用WPF類別庫和C#語言來設計桌面視窗應用程式", Type = "選修", Points = 3, OpeningClass = "四技資工二甲" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseId = "C003", CourseName = "計算機程式", CourseDescription = "程式設計是資訊工程學生的基礎課程，本課程主要希望帶領學生能夠瞭解並開始學習程式設計，此課程主要教授以C語言為主。", Type = "必修", Points = 2, OpeningClass = "四技資工一丙" });

            Teacher teacher2 = new Teacher("張鴻德");  // 創建一位老師
            // 為老師張鴻德新增課程資料
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseId = "C004", CourseName = "網頁程式設計", CourseDescription = "本課程使用HTML5、CSS3、JavaScript、jQuery、Bootstrap等技術來設計網頁程式", Type = "必修", Points = 6, OpeningClass = "五專資工三甲" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseId = "C005", CourseName = "網頁程式設計", CourseDescription = "本課程使用HTML5、CSS3、JavaScript、jQuery、Bootstrap等技術來設計網頁程式", Type = "選修", Points = 3, OpeningClass = "四技資工二甲" });

            Teacher teacher3 = new Teacher("洪國鈞");  // 創建一位老師
            // 為老師洪國鈞新增課程資料
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseId = "C006", CourseName = "資料庫程式設計", CourseDescription = "本課程使用SQL Server資料庫和C#語言來設計資料庫應用程式", Type = "必修", Points = 6, OpeningClass = "五專資工三甲" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseId = "C007", CourseName = "智慧型系統應用", CourseDescription = "本課程完整而淺顯地介紹研習人工智慧技術、智慧型系統與相關機電資領域所需的專業基礎，並詳細探討各種新進的智慧型系統應用技術。", Type = "選修", Points = 3, OpeningClass = "四技控晶四甲, 四技控晶四乙" });
            // 將新增的老師資料加入教師清單中
            teachers.AddRange(new Teacher[] { teacher1, teacher2, teacher3 });

            foreach (Teacher teacher in teachers)
            {
                foreach (Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }
            lbCourse.ItemsSource = courses;
        }
        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = cmbStudent.SelectedItem as Student;
            labelStatus.Content = $"選擇學生：{selectedStudent.StudentName}";
        }
        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 當課程列表中的選擇項目改變時觸發
            selectedCourse = lbCourse.SelectedItem as Course;
            // 更新狀態欄顯示選擇的課程名稱
            labelStatus.Content = $"選擇課程：{selectedCourse.CourseName}";
        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // 當教師樹狀視圖中的選擇項目改變時觸發
            if (tvTeacher.SelectedItem is Course)
            {
                // 如果選擇的是課程，更新選擇的課程
                selectedCourse = tvTeacher.SelectedItem as Course;
                // 更新狀態欄顯示選擇的課程名稱
                labelStatus.Content = $"選擇課程：{selectedCourse.CourseName}";
            }
            else if (tvTeacher.SelectedItem is Teacher)
            {
                // 如果選擇的是教師，更新選擇的教師
                selectedTeacher = tvTeacher.SelectedItem as Teacher;
                // 更新狀態欄顯示選擇的教師名稱
                labelStatus.Content = $"選擇教師：{selectedTeacher.TeacherName}";
            
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // 當點擊 "選課" 按鈕時觸發
            if (selectedStudent == null || selectedCourse == null)
            {
                // 如果未選擇學生或課程，顯示提示訊息
                MessageBox.Show("請選取學生或課程");
                return;
            }
            else
            {
                // 創建新的選課紀錄
                Record newRecord = new Record
                {
                    SelectedStudent = selectedStudent,
                    SelectedCourse = selectedCourse
                };

                // 檢查是否已經存在相同的選課紀錄
                foreach (Record r in records)
                {
                    if (r.Equals(newRecord))
                    {
                        // 如果已經存在，顯示提示訊息
                        MessageBox.Show("此學生已選取此課程");
                        return;
                    }
                }
                // 將新的選課紀錄加入紀錄清單
                records.Add(newRecord);
                // 更新選課紀錄列表的資料來源
                lvRecord.ItemsSource = records;
                // 刷新選課紀錄列表
                lvRecord.Items.Refresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // 當點擊 "退選" 按鈕時觸發
            if (selectedRecord == null)
            {
                // 如果未選擇紀錄，顯示提示訊息
                MessageBox.Show("請選取紀錄");
                return;
            }
            else
            {
                // 從紀錄清單中移除選擇的紀錄
                records.Remove(selectedRecord);
                // 更新選課紀錄列表的資料來源
                lvRecord.ItemsSource = records;
                // 刷新選課紀錄列表
                lvRecord.Items.Refresh();
            }
        }

        private void lvRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 當選課紀錄列表中的選擇項目改變時觸發
            if (lvRecord.SelectedItem is Record)
            {
                // 更新選擇的紀錄
                selectedRecord = lvRecord.SelectedItem as Record;
                // 更新狀態欄顯示選擇的紀錄資訊
                labelStatus.Content = $"選擇紀錄：{selectedRecord.SelectedStudent.StudentName} - {selectedRecord.SelectedCourse.CourseName}";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // 當點擊 "儲存紀錄" 按鈕時觸發
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // 設定檔案篩選器
            saveFileDialog.Filter = "Json Files(*.json)|*.json|All Files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                // 設定 JSON 序列化選項
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                // 將紀錄清單序列化為 JSON 字串
                string json = JsonSerializer.Serialize(records, options);
                // 將 JSON 字串寫入選擇的檔案
                File.WriteAllText(saveFileDialog.FileName, json);
                // 顯示提示訊息
                MessageBox.Show("資料已儲存");
            }
        }
    }
    
}