using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using ORM_ConsoleApp1.Models;
using System.Reflection;

class Program
{
    private static void Main(string[] args)
    {
        string connStr = "datasource=localhost;port=3306;username=root;password=Susitha@1997;database=students";
        var config = new Configuration();
        config.DataBaseIntegration(d => {
            d.ConnectionString = connStr;
            d.Dialect<MySQL57Dialect>();
            d.Driver<MySqlDataDriver>();
            d.LogSqlInConsole = true;
        });

        config.AddAssembly(Assembly.GetExecutingAssembly());
        var sessionFactory = config.BuildSessionFactory();

        using(var session = sessionFactory.OpenSession())
        {
           /*// Write data to MySql Server
            var student = new Student { StudentName = "Susintha", Reg = "16APC2348", Class = "M8", Section = "Sew" };
            session.Save(student);

            //Read data in MySql Server
            var products = session.CreateCriteria<Student>().List<Student>();
            products.ToList().ForEach(x =>
            {
                Console.WriteLine(x.StudentName + " " + x.Reg + " " + x.Reg + " " + x.Class + " " + x.Section);
            });*/


            //Write data to MySql Server
            using (var tx = session.BeginTransaction())
            {

                var student1 = new Student
                {
                    StudentName = "Kamalanath",
                    Reg = "16APC2348",
                    Class = "M8",
                    Section = "Sew"
                };

                var student2 = new Student
                {
                    StudentName = "Anil Premasiri",
                    Reg = "16APC3448",
                    Class = "M8",
                    Section = "Two"
                };

                session.Save(student1);
                session.Save(student2);
                tx.Commit();
            }

            //Read data from MySql Server
             using (var tx = session.BeginTransaction())
            {
                var students = session.CreateCriteria<Student>().List<Student>();
                students.ToList().ForEach(student =>
                {
                    Console.WriteLine("{0} \t{1} \t{2}", student.ID, student.StudentName, student.Reg);
                });

                var student = session.Get<Student>(3);
                Console.WriteLine("{0} \t{1} \t{2}", student.ID, student.StudentName, student.Reg);
                tx.Commit();
            }

           // Update data from MySql Server
           using (var tx = session.BeginTransaction())
            {
                var student = session.Get<Student>(3);
                student.StudentName = "Susitha Athapaththu";
                session.Update(student);

                Console.WriteLine("{0} \t{1} \t{2}", student.ID, student.StudentName, student.Reg);
                tx.Commit();
            }

            //Delete data from MySql Server
            using (var tx = session.BeginTransaction())
            {
                var student = session.Get<Student>(3);
                session.Delete(student);

                tx.Commit();
            }

        }
    }
}