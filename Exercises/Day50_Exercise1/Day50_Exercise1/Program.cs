namespace Day50_Exercise1
{
     public class Student
    {
        public int SId { get; set; }

        public string SName { get; set; }

        public override bool Equals(object? obj)
        {
            var temp = obj as Student;
            return this.SId == temp.SId && this.SName == temp.SName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SId, SName);
        }

        public Student(int sid, string sname)
        {
            SId = sid;
            SName = sname;

        }
    }



    public class Mgmt
    {
        static Dictionary<Student, int> dict = new Dictionary<Student, int>();

        public static void Add(Student s, int marks)
        {
            if (!dict.ContainsKey(s))
            {
                dict.Add(s, marks);
            }
            else if (dict[s] < marks)
            {
                dict[s] = marks;
            }
        }

        public void Display()
        {
            foreach (var v in dict)
                Console.WriteLine($"{v.Key.SId}, {v.Key.SName}, {v.Value}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(1, "HK");
            Mgmt.Add(s1, 58);

            Student s2 = new Student(2, "LK");
            Mgmt.Add(s2, 63);

            Student s3 = new Student(3, "MK");
            Mgmt.Add(s3, 78);

            Student s4 = new Student(3, "MK");
            Mgmt.Add(s4, 83);

            Mgmt m1 = new Mgmt();
            m1.Display();
        }
    }
}


