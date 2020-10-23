using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using UnivApp.Models;
using UnivApp.DAL;

namespace UnivApp.Models
{
    public static class CreateSampleData
    {
        static UnivAppContext context = new UnivAppContext();

        public static void CreateStudents()
        {
            var listCount = context.Students.ToList().Count;

            if (listCount != 0)
            {
                return;
            }

            var students = new List<Student>
            {
                new Student {FirstMidName = "Ahmet", LastName = "Altın"},
                new Student {FirstMidName = "Tuğçe", LastName = "Altaş"},
                new Student {FirstMidName = "Begüm", LastName = "Altıparmak"},
                new Student {FirstMidName = "Büşra", LastName = "Gül"},
                new Student {FirstMidName = "Ramazan", LastName = "Aral"},
                new Student {FirstMidName = "Ali", LastName = "Arıkan"},
                new Student {FirstMidName = "Şeyda", LastName = "Arpacı"},
                new Student {FirstMidName = "Sevginur", LastName = "Aslan"},
                new Student {FirstMidName = "Sevtap", LastName = "Avşar"},
                new Student {FirstMidName = "Güneş", LastName = "Aydoğan"},
                new Student {FirstMidName = "Gökhan", LastName = "Alkan"},
                new Student {FirstMidName = "Taylan", LastName = "Yaman"},
                new Student {FirstMidName = "Ayla", LastName = "Balkan"},
                new Student {FirstMidName = "Berfin", LastName = "Güler"},
                new Student {FirstMidName = "Hulki", LastName = "Akar"},
                new Student {FirstMidName = "Ayşe", LastName = "Buyuran"},
                new Student {FirstMidName = "Saliha", LastName = "Büyükfırat"},
                new Student {FirstMidName = "Mustafa", LastName = "Akçaözoğlu"},
                new Student {FirstMidName = "Seyit", LastName = "Cemoğlu"},
                new Student {FirstMidName = "Armağan", LastName = "Bilgen"},
                new Student {FirstMidName = "Şansal", LastName = "Civan"},
                new Student {FirstMidName = "Efecan", LastName = "Çetintaş"},
                new Student {FirstMidName = "Rıdvan", LastName = "Güzel"},
                new Student {FirstMidName = "Hilal", LastName = "Birol"},
                new Student {FirstMidName = "Çağrı", LastName = "Dağhan"},
                new Student {FirstMidName = "Ezgi", LastName = "Dalkılıç"},
                new Student {FirstMidName = "Aysun", LastName = "Sezeroğlu"},
                new Student {FirstMidName = "Sema", LastName = "Demırören"},
                new Student {FirstMidName = "Goncagül", LastName = "Demir"},
                new Student {FirstMidName = "Firuze", LastName = "Durmuşoğlu"},
                new Student {FirstMidName = "Volkan", LastName = "Ağkan"},
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
        } // ok

        public static void CreateDepartments()
        {
            var listCount = context.Departments.ToList().Count;

            if (listCount != 0)
            {
                return;
            }


            var departments = new List<Department>
            {
            new Department { Name = "Arkeoloji"},
            new Department { Name = "İlköğretim Matematik Öğretmenliği"},
            new Department { Name = "Özel Eğitim Öğretmenliği"},
            new Department { Name = "Rehberlik ve Psikolojik Danışmanlık"},
            new Department { Name = "Biyoloji"},
            new Department { Name = "Fizik"},
            new Department { Name = "Kimya"},
            new Department { Name = "Biyoloji"},
            new Department { Name = "Matematik"},
            new Department { Name = "Tarih"},
            new Department { Name = "İşletme"},
            new Department { Name = "Mimarlık"},
            new Department { Name = "Elektrik-Elektronik Mühendisliği"},
            new Department { Name = "Gıda Mühendisliği"},
            new Department { Name = "Tıp"},
            new Department { Name = "Endüstri Mühendisliği"},
            new Department { Name = "Beslenme ve Diyetetik"},
            new Department { Name = "Rehberlik ve Psikolojik Danışmanlık"},
            new Department { Name = "Türkçe Öğretmenliği"},
            new Department { Name = "Sanat Tarihi"},
            new Department { Name = "Sosyoloji"},
            new Department { Name = "İktisat"},
            new Department { Name = "Ekonomi ve Finans"},
            new Department { Name = "Turizm Rehberliği"},
            new Department { Name = "Peyzaj Mimarlığı"},
            new Department { Name = "Zootekni"},
            new Department { Name = "Çağdaş Türk Lehçeleri ve Edebiyatları"},
            new Department { Name = "Moleküler Biyoloji ve Genetik"},
            new Department { Name = "Çevre Mühendisliği"},
            new Department { Name = "Maden Mühendisliği"},
            new Department { Name = "Otomotiv Mühendisliği"},
            new Department { Name = "Hemşirelik"}

        }; 
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        } // ok

        public static void CreateCourses()
        {
            UnivAppContext context = new UnivAppContext();

            var listCount = context.Courses.ToList().Count;

            if (listCount != 0)
            {
                return;
            }

            var depList = context.Departments.ToList();
            HashSet<int> hashSet = new HashSet<int>();

            foreach (var item in depList)
            {
                hashSet.Add(item.DepartmentID);
            }

            Random random = new Random();
            int[] asArray = hashSet.ToArray();
            int randomDepartmentId1 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId2 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId3 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId4 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId5 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId6 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId7 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId8 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId9 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId10 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId11 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId12 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId13 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId14 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId15 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId16 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId17 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId18 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId19 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId20 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId21 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId22 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId23 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId24 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId25 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId26 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId27 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId28 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId29 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId30 = asArray[random.Next(asArray.Length)];
            int randomDepartmentId31 = asArray[random.Next(asArray.Length)];

            var courses = new List<Course>
            {
                //new Course{CourseID=1050,Title="Chemistry",Credits=3, DepartmentID = randomDepartmentId1},
                //new Course{CourseID=4022,Title="Microeconomics",Credits=3, DepartmentID = randomDepartmentId2},
                //new Course{CourseID=4041,Title="Macroeconomics",Credits=3, DepartmentID = randomDepartmentId3},
                //new Course{CourseID=1045,Title="Calculus",Credits=4, DepartmentID = randomDepartmentId4},
                //new Course{CourseID=3141,Title="Trigonometry",Credits=4, DepartmentID = randomDepartmentId5},
                //new Course{CourseID=2021,Title="Composition",Credits=3, DepartmentID = randomDepartmentId6},
                //new Course{CourseID=2042,Title="Literature",Credits=4, DepartmentID = randomDepartmentId7}
                
                
                new Course{CourseID=1,Title="İngilizce-I",Credits=3, DepartmentID = randomDepartmentId1},
                new Course{CourseID=2,Title="Fizik-I",Credits=4, DepartmentID = randomDepartmentId2},
                new Course{CourseID=3,Title="Kimya",Credits=4, DepartmentID = randomDepartmentId3},
                new Course{CourseID=4,Title="Makine Mühendisliğine Giriş",Credits=4, DepartmentID = randomDepartmentId4},
                new Course{CourseID=5,Title="Matematik-I",Credits=3, DepartmentID = randomDepartmentId5},
                new Course{CourseID=6,Title="Türk Dili-I",Credits=4, DepartmentID = randomDepartmentId6},
                new Course{CourseID=7,Title="Atatürk İlkeleri ve İnkılap Tarihi-I",Credits=4, DepartmentID = randomDepartmentId7},
                new Course{CourseID=8,Title="Atatürk İlkeleri ve İnkılap Tarihi-II",Credits=4, DepartmentID = randomDepartmentId8},
                new Course{CourseID=9,Title="Fizik-II",Credits=4, DepartmentID = randomDepartmentId9},
                new Course{CourseID=10,Title="İngilizce-II",Credits=4, DepartmentID = randomDepartmentId10},
                new Course{CourseID=11,Title="İş Sağlığı ve Güvenliği",Credits=4, DepartmentID = randomDepartmentId11},
                new Course{CourseID=12,Title="Lineer Cebir",Credits=4, DepartmentID = randomDepartmentId12},
                new Course{CourseID=13,Title="Malzeme Bilimi",Credits=3, DepartmentID = randomDepartmentId13},
                new Course{CourseID=14,Title="Mukavemet-I",Credits=3, DepartmentID = randomDepartmentId14},
                new Course{CourseID=15,Title="Termodinamik-I",Credits=3, DepartmentID = randomDepartmentId15},
                new Course{CourseID=16,Title="Diferansiyel Denklemler",Credits=4, DepartmentID = randomDepartmentId16},
                new Course{CourseID=17,Title="Elektrik Mühendisliği Prensipleri",Credits=4, DepartmentID = randomDepartmentId17},
                new Course{CourseID=18,Title="Eleştirel Düşünme, Yaratıcılık ve Girişimcilik",Credits=4, DepartmentID = randomDepartmentId18},
                new Course{CourseID=19,Title="Kalite Yönetim Sistemleri",Credits=4, DepartmentID = randomDepartmentId19},
                new Course{CourseID=20,Title="Mühendislik Malzemeleri",Credits=4, DepartmentID = randomDepartmentId20},
                new Course{CourseID=21,Title="Pazarlama İlkeleri",Credits=4, DepartmentID = randomDepartmentId21},
                new Course{CourseID=22,Title="İstatistik",Credits=4, DepartmentID = randomDepartmentId22},
                new Course{CourseID=23,Title="Üretim Yönetimi",Credits=3, DepartmentID = randomDepartmentId23},
                new Course{CourseID=24,Title="Yönetim Sistemleri",Credits=4, DepartmentID = randomDepartmentId24},
                new Course{CourseID=25,Title="Finansal Yönetim",Credits=4, DepartmentID = randomDepartmentId25},
                new Course{CourseID=26,Title="Java Programlama",Credits=3, DepartmentID = randomDepartmentId26},
                new Course{CourseID=27,Title="Örgüt Kültürü",Credits=4, DepartmentID = randomDepartmentId27},
                new Course{CourseID=28,Title="İnsan Kaynakları Yönetimi",Credits=4, DepartmentID = randomDepartmentId28},
                new Course{CourseID=29,Title="Örgütsel Davranış",Credits=4, DepartmentID = randomDepartmentId29},
                new Course{CourseID=30,Title="Araştırma Yöntemleri",Credits=4, DepartmentID = randomDepartmentId30},
                new Course{CourseID=31,Title="Muhasebe",Credits=4, DepartmentID = randomDepartmentId31},


            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
        }

        public static void CreateEnrollments()
        {
            var listCount = context.Enrollments.ToList().Count;

            if (listCount != 0)
            {
                return;
            }

            var studentList = context.Students.ToList();
            HashSet<int> hashSet = new HashSet<int>();

            foreach (var item in studentList)
            {
                hashSet.Add(item.ID);
            }
            Random random = new Random();
            int[] asArray = hashSet.ToArray();
            int randomStudentId1 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId1).ToArray();

            int randomStudentId2 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId2).ToArray();

            int randomStudentId3 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId3).ToArray();

            int randomStudentId4 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId4).ToArray();

            int randomStudentId5 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId5).ToArray();

            int randomStudentId6 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId6).ToArray();

            int randomStudentId7 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId7).ToArray();

            int randomStudentId8 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId8).ToArray();

            int randomStudentId9 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId9).ToArray();

            int randomStudentId10 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId10).ToArray();

            int randomStudentId11 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId11).ToArray();

            int randomStudentId12 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId12).ToArray();

            int randomStudentId13 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId13).ToArray();

            int randomStudentId14 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId14).ToArray();

            int randomStudentId15 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId15).ToArray();

            int randomStudentId16 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId16).ToArray();

            int randomStudentId17 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId17).ToArray();

            int randomStudentId18 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId18).ToArray();

            int randomStudentId19 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId19).ToArray();

            int randomStudentId20 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId20).ToArray();

            int randomStudentId21 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId21).ToArray();

            int randomStudentId22 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId22).ToArray();

            int randomStudentId23 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId23).ToArray();

            int randomStudentId24 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId24).ToArray();

            int randomStudentId25 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId25).ToArray();

            int randomStudentId26 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId26).ToArray();

            int randomStudentId27 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId27).ToArray();

            int randomStudentId28 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId28).ToArray();

            int randomStudentId29 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId29).ToArray();

            int randomStudentId30 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomStudentId30).ToArray();

            /////

            var courseList = context.Courses.ToList();
            HashSet<int> hashSet2 = new HashSet<int>();

            foreach (var item in courseList)
            {
                hashSet2.Add(item.CourseID);
            }

            Random random2 = new Random();
            int[] asArray2 = hashSet2.ToArray();
            int randomCourseId1 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId1).ToArray();

            int randomCourseId2 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId2).ToArray();

            int randomCourseId3 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId3).ToArray();

            int randomCourseId4 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId4).ToArray();

            int randomCourseId5 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId5).ToArray();

            int randomCourseId6 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId6).ToArray();

            int randomCourseId7 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId7).ToArray();

            int randomCourseId8 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId8).ToArray();

            int randomCourseId9 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId9).ToArray();

            int randomCourseId10 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId10).ToArray();

            int randomCourseId11 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId11).ToArray();

            int randomCourseId12 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId12).ToArray();

            int randomCourseId13 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId13).ToArray();

            int randomCourseId14 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId14).ToArray();

            int randomCourseId15 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId15).ToArray();

            int randomCourseId16 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId16).ToArray();

            int randomCourseId17 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId17).ToArray();

            int randomCourseId18 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId18).ToArray();

            int randomCourseId19 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId19).ToArray();

            int randomCourseId20 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId20).ToArray();

            int randomCourseId21 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId21).ToArray();

            int randomCourseId22 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId22).ToArray();

            int randomCourseId23 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId23).ToArray();

            int randomCourseId24 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId24).ToArray();

            int randomCourseId25 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId25).ToArray();

            int randomCourseId26 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId26).ToArray();

            int randomCourseId27 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId27).ToArray();

            int randomCourseId28 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId28).ToArray();

            int randomCourseId29 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId29).ToArray();

            int randomCourseId30 = asArray2[random.Next(asArray2.Length)];
            asArray2 = asArray2.Where(val => val != randomCourseId30).ToArray();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {StudentID = randomStudentId1, CourseID = randomCourseId1, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId2, CourseID = randomCourseId2, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId3, CourseID = randomCourseId3, Grade = Grade.B},
                new Enrollment {StudentID = randomStudentId4, CourseID = randomCourseId4, Grade = Grade.B},
                new Enrollment {StudentID = randomStudentId5, CourseID = randomCourseId5, Grade = Grade.F},
                new Enrollment {StudentID = randomStudentId6, CourseID = randomCourseId6, Grade = Grade.F},
                new Enrollment {StudentID = randomStudentId7, CourseID = randomCourseId7},
                new Enrollment {StudentID = randomStudentId8, CourseID = randomCourseId8},
                new Enrollment {StudentID = randomStudentId9, CourseID = randomCourseId9, Grade = Grade.F},
                new Enrollment {StudentID = randomStudentId10, CourseID = randomCourseId10, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId11, CourseID = randomCourseId11},
                new Enrollment {StudentID = randomStudentId12, CourseID = randomCourseId12, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId13, CourseID = randomCourseId13, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId14, CourseID = randomCourseId14, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId15, CourseID = randomCourseId15, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId16, CourseID = randomCourseId16, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId17, CourseID = randomCourseId17, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId18, CourseID = randomCourseId18, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId19, CourseID = randomCourseId19, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId20, CourseID = randomCourseId20, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId21, CourseID = randomCourseId21, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId22, CourseID = randomCourseId22, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId23, CourseID = randomCourseId23, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId24, CourseID = randomCourseId24, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId25, CourseID = randomCourseId25, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId26, CourseID = randomCourseId26, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId27, CourseID = randomCourseId27, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId28, CourseID = randomCourseId28, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId29, CourseID = randomCourseId29, Grade = Grade.B},
                new Enrollment {StudentID = randomStudentId30, CourseID = randomCourseId30, Grade = Grade.F},

                new Enrollment {StudentID = randomStudentId1, CourseID = randomCourseId2, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId2, CourseID = randomCourseId3, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId3, CourseID = randomCourseId4, Grade = Grade.B},
                new Enrollment {StudentID = randomStudentId4, CourseID = randomCourseId5, Grade = Grade.B},
                new Enrollment {StudentID = randomStudentId5, CourseID = randomCourseId6, Grade = Grade.F},
                new Enrollment {StudentID = randomStudentId6, CourseID = randomCourseId7, Grade = Grade.F},
                new Enrollment {StudentID = randomStudentId7, CourseID = randomCourseId8},
                new Enrollment {StudentID = randomStudentId8, CourseID = randomCourseId9},
                new Enrollment {StudentID = randomStudentId9, CourseID = randomCourseId10, Grade = Grade.F},
                new Enrollment {StudentID = randomStudentId10, CourseID = randomCourseId11, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId11, CourseID = randomCourseId12},
                new Enrollment {StudentID = randomStudentId12, CourseID = randomCourseId13, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId13, CourseID = randomCourseId14, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId14, CourseID = randomCourseId15, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId15, CourseID = randomCourseId16, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId16, CourseID = randomCourseId17, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId17, CourseID = randomCourseId18, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId18, CourseID = randomCourseId19, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId19, CourseID = randomCourseId20, Grade = Grade.C},
                new Enrollment {StudentID = randomStudentId20, CourseID = randomCourseId21, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId21, CourseID = randomCourseId22, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId22, CourseID = randomCourseId23, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId23, CourseID = randomCourseId24, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId24, CourseID = randomCourseId25, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId25, CourseID = randomCourseId26, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId26, CourseID = randomCourseId27, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId27, CourseID = randomCourseId28, Grade = Grade.D},
                new Enrollment {StudentID = randomStudentId28, CourseID = randomCourseId29, Grade = Grade.A},
                new Enrollment {StudentID = randomStudentId29, CourseID = randomCourseId30, Grade = Grade.B},
                new Enrollment {StudentID = randomStudentId30, CourseID = randomCourseId15, Grade = Grade.F},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }

        public static void CreateInstructors()
        {
            var listCount = context.Instructors.ToList().Count;

            if (listCount != 0)
            {
                return;
            }

            var courseList = context.Courses.ToList();
            HashSet<Course> hashSet = new HashSet<Course>();

            foreach (var item in courseList)
            {
                hashSet.Add(item);
            }
            Random random = new Random();
            Course[] asArray = hashSet.ToArray();
            Course randomCourse1 = asArray[random.Next(asArray.Length)];
            Course randomCourse2 = asArray[random.Next(asArray.Length)];
            Course randomCourse3 = asArray[random.Next(asArray.Length)];
            Course randomCourse4 = asArray[random.Next(asArray.Length)];
            Course randomCourse5 = asArray[random.Next(asArray.Length)];
            Course randomCourse6 = asArray[random.Next(asArray.Length)];
            Course randomCourse7 = asArray[random.Next(asArray.Length)];

            var list = new List<Course>();
            list.Add(randomCourse1);
            list.Add(randomCourse2);
            list.Add(randomCourse3);

            var list2 = new List<Course>();
            list2.Add(randomCourse4);
            list2.Add(randomCourse5);

            var list3 = new List<Course>();
            list3.Add(randomCourse6);

            //var instructorList = context.Instructors.ToList();
            //HashSet<int> hashSet2 = new HashSet<int>();

            //foreach (var item in instructorList)
            //{
            //    hashSet2.Add(item.ID);
            //}
            ////bozuk oablilir
            //Random random2 = new Random();
            //int[] asArray2 = hashSet2.ToArray();
            //int randomInstructorId1 = asArray2[random.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructorId1).ToArray();

            //int randomInstructorId2 = asArray2[random.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructorId2).ToArray();

            //int randomInstructorId3 = asArray2[random.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructorId3).ToArray();

            //int randomInstructorId4 = asArray2[random.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructorId4).ToArray();

            //int randomInstructorId5 = asArray2[random.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructorId5).ToArray();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName = "Mustafa",     LastName = "Özkul", Courses = list},
                new Instructor { FirstMidName = "Ahmet",     LastName = "Özpak", Courses = list},
                new Instructor { FirstMidName = "Giray",     LastName = "Teker", Courses = list},
                new Instructor { FirstMidName = "Eren",     LastName = "Tecer", Courses = list},
                new Instructor { FirstMidName = "Necati",     LastName = "Tatlısu", Courses = list},
                new Instructor { FirstMidName = "Nusret",     LastName = "Tekşan", Courses = list},
                new Instructor { FirstMidName = "Cihad",     LastName = "Terzi", Courses = list},
                new Instructor { FirstMidName = "Evren",     LastName = "Tolunay", Courses = list},
                new Instructor { FirstMidName = "Dilara",     LastName = "Topalan", Courses = list},
                new Instructor { FirstMidName = "Utku",     LastName = "Türkoğlu", Courses = list},
                new Instructor { FirstMidName = "Nurseli",     LastName = "Tüfekci", Courses = list},
                new Instructor { FirstMidName = "Ayşe",     LastName = "Uçar", Courses = list},
                new Instructor { FirstMidName = "Fatma",     LastName = "Ubay", Courses = list},
                new Instructor { FirstMidName = "Günnaz",     LastName = "Uluhan", Courses = list},
                new Instructor { FirstMidName = "Simge",     LastName = "Ustabaşı", Courses = list},
                new Instructor { FirstMidName = "Işıl",     LastName = "Uzun", Courses = list},
                new Instructor { FirstMidName = "Necmettin",     LastName = "Yurtsever", Courses = list},
                new Instructor { FirstMidName = "Sevde",     LastName = "Yıldızdöken", Courses = list},
                new Instructor { FirstMidName = "Kaan",     LastName = "Yücekayalı", Courses = list},
                new Instructor { FirstMidName = "Seyhan",     LastName = "Zilan", Courses = list},
                new Instructor { FirstMidName = "Sevda",     LastName = "Zorkirişçi", Courses = list},
                new Instructor { FirstMidName = "Yunus",     LastName = "Yürükgil", Courses = list},
                new Instructor { FirstMidName = "İlknur",     LastName = "Yörüten", Courses = list},
                new Instructor { FirstMidName = "Gülselin",     LastName = "Yıldızoğlu", Courses = list},
                new Instructor { FirstMidName = "Mustafa",     LastName = "Yerlikaya", Courses = list},
                new Instructor { FirstMidName = "Seher",     LastName = "Yapar", Courses = list},
                new Instructor { FirstMidName = "Tarık",     LastName = "Yakupoğlu", Courses = list},
                new Instructor { FirstMidName = "Furkan",     LastName = "Ünlü", Courses = list},
                new Instructor { FirstMidName = "Pınar",     LastName = "Uşak", Courses = list},
                new Instructor { FirstMidName = "Ümmühan",     LastName = "Ulutaş", Courses = list},
                new Instructor { FirstMidName = "Güven",     LastName = "Tüdeş", Courses = list},
                new Instructor { FirstMidName = "Hale",     LastName = "Turna", Courses = list},
                new Instructor { FirstMidName = "Alp",     LastName = "Toygar", Courses = list},
                new Instructor { FirstMidName = "Muhammed",     LastName = "Tokgöz", Courses = list},
                
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            CreateSampleData.CreateAdministratorsForDepartments(); 

        }

        public static void CreateOfficeAssignments()
        {
            var listCount = context.OfficeAssignments.ToList().Count;

            if (listCount != 0)
            {
                return;
            }

            var instructorList = context.Instructors.ToList();
            HashSet<int> hashSet = new HashSet<int>();

            foreach (var item in instructorList)
            {
                hashSet.Add(item.ID);
            }

            Random random = new Random();
            int[] asArray = hashSet.ToArray();
            int randomInstructorId1 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId1).ToArray();

            int randomInstructorId2 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId2).ToArray();

            int randomInstructorId3 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId3).ToArray();

            int randomInstructorId4 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId4).ToArray();

            int randomInstructorId5 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId5).ToArray();

            int randomInstructorId6 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId6).ToArray();

            int randomInstructorId7 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId7).ToArray();

            int randomInstructorId8 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId8).ToArray();

            int randomInstructorId9 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId9).ToArray();

            int randomInstructorId10 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId10).ToArray();

            int randomInstructorId11 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId11).ToArray();

            int randomInstructorId12 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId12).ToArray();

            int randomInstructorId13 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId13).ToArray();

            int randomInstructorId14 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId14).ToArray();

            int randomInstructorId15 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId15).ToArray();

            int randomInstructorId16 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId16).ToArray();

            int randomInstructorId17 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId17).ToArray();

            int randomInstructorId18 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId18).ToArray();

            int randomInstructorId19 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId19).ToArray();

            int randomInstructorId20 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId20).ToArray();

            int randomInstructorId21 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId21).ToArray();

            int randomInstructorId22 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId22).ToArray();

            int randomInstructorId23 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId23).ToArray();

            int randomInstructorId24 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId24).ToArray();

            int randomInstructorId25 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId25).ToArray();

            int randomInstructorId26 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId26).ToArray();

            int randomInstructorId27 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId27).ToArray();

            int randomInstructorId28 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId28).ToArray();

            int randomInstructorId29 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId29).ToArray();

            int randomInstructorId30 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId30).ToArray();

            int randomInstructorId31 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId31).ToArray();

            int randomInstructorId32 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId32).ToArray();

            int randomInstructorId33 = asArray[random.Next(asArray.Length)];
            asArray = asArray.Where(val => val != randomInstructorId33).ToArray();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { InstructorID = randomInstructorId1, Location = "Alibeyköy"},
                new OfficeAssignment { InstructorID = randomInstructorId2, Location = "Akfırat"},
                new OfficeAssignment { InstructorID = randomInstructorId3, Location = "Akaretler"},
                new OfficeAssignment { InstructorID = randomInstructorId4, Location = "Ahırkapı"},
                new OfficeAssignment { InstructorID = randomInstructorId5, Location = "Acıbadem"},
                new OfficeAssignment { InstructorID = randomInstructorId6, Location = "Aksaray"},
                new OfficeAssignment { InstructorID = randomInstructorId7, Location = "Altımermer"},
                new OfficeAssignment { InstructorID = randomInstructorId8, Location = "Anadoluhisarı"},
                new OfficeAssignment { InstructorID = randomInstructorId9, Location = "Ataköy"},
                new OfficeAssignment { InstructorID = randomInstructorId10, Location = "Ayakapı"},
                new OfficeAssignment { InstructorID = randomInstructorId11, Location = "Ayazağa"},
                new OfficeAssignment { InstructorID = randomInstructorId12, Location = "Ayrılıkçeşme"},
                new OfficeAssignment { InstructorID = randomInstructorId13, Location = "Azapkapı"},
                new OfficeAssignment { InstructorID = randomInstructorId14, Location = "Bağlarbaşı"},
                new OfficeAssignment { InstructorID = randomInstructorId15, Location = "Bahariye"},
                new OfficeAssignment { InstructorID = randomInstructorId16, Location = "Balat"},
                new OfficeAssignment { InstructorID = randomInstructorId17, Location = "Baltalimanı"},
                new OfficeAssignment { InstructorID = randomInstructorId18, Location = "Bebek"},
                new OfficeAssignment { InstructorID = randomInstructorId19, Location = "Belgradkapı"},
                new OfficeAssignment { InstructorID = randomInstructorId20, Location = "Beşyüzevler"},
                new OfficeAssignment { InstructorID = randomInstructorId21, Location = "Bomonti"},
                new OfficeAssignment { InstructorID = randomInstructorId22, Location = "Büyüklanga"},
                new OfficeAssignment { InstructorID = randomInstructorId23, Location = "Camlıkahve"},
                new OfficeAssignment { InstructorID = randomInstructorId24, Location = "Cihangir"},
                new OfficeAssignment { InstructorID = randomInstructorId25, Location = "Çarşıkapı"},
                new OfficeAssignment { InstructorID = randomInstructorId26, Location = "Çemberlitaş"},
                new OfficeAssignment { InstructorID = randomInstructorId27, Location = "Çiftecevizler"},
                new OfficeAssignment { InstructorID = randomInstructorId28, Location = "Dikilitaş"},
                new OfficeAssignment { InstructorID = randomInstructorId29, Location = "Dolapdere"},
                new OfficeAssignment { InstructorID = randomInstructorId30, Location = "Dudullu"},
                new OfficeAssignment { InstructorID = randomInstructorId31, Location = "Eminönü"},
                new OfficeAssignment { InstructorID = randomInstructorId32, Location = "Etiler"},
                new OfficeAssignment { InstructorID = randomInstructorId33, Location = ""},
            };

            officeAssignments.ForEach(o=>context.OfficeAssignments.Add(o));
            context.SaveChanges();

        }

        public static void CreateAdministratorsForDepartments()
        {


            var instructorList = context.Instructors.ToList();
            HashSet<Instructor> hashSet2 = new HashSet<Instructor>();

            foreach (var item in instructorList)
            {
                hashSet2.Add(item);
            }

            Random random2 = new Random();
            Instructor[] asArray2 = hashSet2.ToArray();
            //Instructor randomInstructor1 = asArray2[random2.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructor1).ToArray();

            //Instructor randomInstructor2 = asArray2[random2.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructor2).ToArray();

            //Instructor randomInstructor3 = asArray2[random2.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructor3).ToArray();

            //Instructor randomInstructor4 = asArray2[random2.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructor4).ToArray();

            //Instructor randomInstructor5 = asArray2[random2.Next(asArray2.Length)];
            //asArray2 = asArray2.Where(val => val != randomInstructor5).ToArray();

            var departmentsList = context.Departments.ToList();
            foreach (var department in departmentsList)
            {
                if (department.Administrator == null)
                {
                    Random random3 = new Random();
                   Instructor randomInstructor = asArray2[random2.Next(asArray2.Length)];
                   asArray2 = asArray2.Where(val => val != randomInstructor).ToArray();
                   department.Administrator = randomInstructor;
                   department.InstructorID = randomInstructor.ID; //gerek yokmuş?
                   context.SaveChanges();

                   //if (department.InstructorID == 19)
                   //{
                   //    department.Administrator = null;
                   //}
                }

                Department randomDepartment53 = context.Departments.FirstOrDefault();
                randomDepartment53.Administrator = null;
            }

        }
    }
}
