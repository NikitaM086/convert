using cs;

namespace TestProject1
{
    public class Tests
    {
        static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Title = "Основы C#", Instructor = "Н. А. Мухин", StudentCount = 25, Rating = 5 },
            new Course { Id = 4, Title = "Печь пирожки", Instructor = "Мария Иванова", StudentCount = 86, Rating = 4.8 },
        };

        Class1 baza = new Class1();
        FileManager fileManager = new FileManager();
        CsvHandler csvHandler = new CsvHandler();
        Course course = new Course();
        string path = "test.json";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadData_Test1()
        {
            Class1.LoadData();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void SaveData_Test1()
        {
            Class1.SaveData();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void DisplayCourses_Test1()
        {
            Class1.DisplayCourses();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void SortCourses_Test1()
        {
            Class1.SortCourses();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void SearchCourses_Test1()
        {
            Class1.SearchCourses();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void AddCourse_Test1()
        {
            Class1.AddCourse();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void DeleteCourse_Test1()
        {
            Class1.DeleteCourse();
            Assert.IsTrue(Class1.Success);
        }

        [Test]
        public void EditCourse_Test1()
        {
            Class1.EditCourse();
            Assert.IsTrue(Class1.Success);
        }


    }
}