using System;
class Person
{
    public string Ad;
    public string Soyad;
    public int Yas;
    public string Email;
    public string Id;
    public Person(string ad, string soyad, int yas, string email, string id)
    {
        this.Ad = ad;
        this.Soyad = soyad;
        this.Yas = yas;
        this.Email = email;
        this.Id = id;
    }
    public string GetFullName()
    {
        return Ad + " " + Soyad;
    }
    public void ShowBasicInfo()
    {
        Console.WriteLine("Ad Soyad: " + GetFullName());
        Console.WriteLine("Yas: " + Yas);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("ID: " + Id);
    }
}
class Student : Person
{
    public string TelebeNomresi;
    public string Fakulte;
    public double GPA;
    public int Kurs;
    public Student(string ad, string soyad, int yas, string email, string id,
                   string telebeNomresi, string fakulte, double gpa, int kurs)
        : base(ad, soyad, yas, email, id)
    {
        this.TelebeNomresi = telebeNomresi;
        this.Fakulte = fakulte;
        this.GPA = gpa;
        this.Kurs = kurs;
    }
    public void ShowStudentInfo()
    {
        ShowBasicInfo();
        Console.WriteLine("Telebe nomresi: " + TelebeNomresi);
        Console.WriteLine("Fakulte: " + Fakulte);
        Console.WriteLine("GPA: " + GPA);
        Console.WriteLine("Kurs: " + Kurs);
    }
    public double CalculateScholarship()
    {
        if (GPA >= 90)
            return 500;
        else if (GPA >= 80)
            return 350;
        else if (GPA >= 70)
            return 200;
        else
            return 0;
    }
}
class Teacher : Person
{
    public string Kafedra;
    public string Fenn;
    public decimal Maas;
    public int Tecrube;
    public Teacher(string ad, string soyad, int yas, string email, string id,
                   string kafedra, string fenn, decimal maas, int tecrube)
        : base(ad, soyad, yas, email, id)
    {
        this.Kafedra = kafedra;
        this.Fenn = fenn;
        this.Maas = maas;
        this.Tecrube = tecrube;
    }
    public void ShowTeacherInfo()
    {
        ShowBasicInfo();
        Console.WriteLine("Kafedra: " + Kafedra);
        Console.WriteLine("Esas fenn: " + Fenn);
        Console.WriteLine("Baza maas: " + Maas);
        Console.WriteLine("Tecube ili: " + Tecrube);
    }
    public decimal CalculateSalary()
    {
        return Maas + (Tecrube * 50);
    }
}
class Administrator : Person
{
    public string Vezife;
    public string Sobe;
    public int AccessLevel;
    public Administrator(string ad, string soyad, int yas, string email, string id,
                         string vezife, string sobe, int accessLevel)
        : base(ad, soyad, yas, email, id)
    {
        this.Vezife = vezife;
        this.Sobe = sobe;
        this.AccessLevel = accessLevel;
    }
    public void ShowAdminInfo()
    {
        ShowBasicInfo();
        Console.WriteLine("Vezife: " + Vezife);
        Console.WriteLine("Sobe: " + Sobe);
        Console.WriteLine("Access Level: " + AccessLevel);
    }
    public void GrantAccess(Student student)
    {
        Console.WriteLine(student.GetFullName() + " telebesine sisteme giris icazesi verildi.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Yusif", "Besirzade", 20, "ali@gmail.com", "S001",
                                 "ST1001", "ITT", 88.5, 3);
        Student s2 = new Student("Ramiz", "Eliyev", 21, "nigar@gmail.com", "S002",
                                 "ST1002", "ITT", 92.0, 4);
        Student s3 = new Student("Kamran", "Huseynov", 19, "kamran@gmail.com", "S003",
                                 "ST1003", "ITT", 68.5, 2);
        Teacher t1 = new Teacher("Rashad", "Karimov", 40, "rashad@gmail.com", "T001",
                                 "ITT", "IT", 800, 15);
        Teacher t2 = new Teacher("Leyla", "Suleymanova", 35, "leyla@gmail.com", "T002",
                                 "ITT", "Riyaziyyat", 800, 8);
        Administrator admin = new Administrator("Elchin", "Aliyev", 50,
                                                 "elchin@gmail.com", "A001",
                                                 "Dekan", "IT", 5);
        Console.WriteLine("STUDENTS");
        s1.ShowStudentInfo();
        Console.WriteLine("Teqaud: " + s1.CalculateScholarship());
        Console.WriteLine();
        s2.ShowStudentInfo();
        Console.WriteLine("Teqaud: " + s2.CalculateScholarship());
        Console.WriteLine();
        s3.ShowStudentInfo();
        Console.WriteLine("Teqaud: " + s3.CalculateScholarship());
        Console.WriteLine();
        Console.WriteLine("TEACHERS");
        t1.ShowTeacherInfo();
        Console.WriteLine("Maas: " + t1.CalculateSalary());
        Console.WriteLine();
        t2.ShowTeacherInfo();
        Console.WriteLine("Maas: " + t2.CalculateSalary());
        Console.WriteLine();
        Console.WriteLine("ADMIN");
        admin.ShowAdminInfo();
        Console.WriteLine();
        admin.GrantAccess(s1);
        double totalScholarship =
            s1.CalculateScholarship() +
            s2.CalculateScholarship() +
            s3.CalculateScholarship();
        decimal totalSalary =
            t1.CalculateSalary() +
            t2.CalculateSalary();
        Console.WriteLine();
        Console.WriteLine("STATISTICS");
        Console.WriteLine("Umumi teqaud xerci: " + totalScholarship);
        Console.WriteLine("Umumi maas xerci: " + totalSalary);
    }
}