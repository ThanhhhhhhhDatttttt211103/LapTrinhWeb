using Lab1_SinhVien.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab1_SinhVien.Data
{
    public class DbInitializer
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using(var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated(); // Kiểm tra xem có cơ sở dữ liệu chưa thì thêm vào
                // look for any learners
                if(context.Learners.Any())
                {
                    return;
                }
                var majors = new Major[]
                {
                    new Major{MajorName = "IT"},
                    new Major{MajorName = "Enconomics"},
                    new Major{MajorName = "Mathematics"},

                };
                foreach(var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();
                var Learners = new Learner[]
                {
                    new Learner{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01"), MajorID = 1},
                    new Learner{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01"), MajorID = 1},
                    new Learner{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01"), MajorID = 1},
                    new Learner{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01"), MajorID = 2},
                    new Learner{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01"), MajorID = 2},
                    new Learner{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01"), MajorID = 2},
                };
                foreach (var learner in Learners)
                {
                    context.Learners.Add(learner);
                }
                context.SaveChanges();
                var courses = new Course[]
                {
                    new Course{CourseID=1050,Title="Chemistry",Credits=3},
                    new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                    new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                    new Course{CourseID=1045,Title="Calculus",Credits=4},
                    new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                    new Course{CourseID=2021,Title="Composition",Credits=3},
                    new Course{CourseID=2042,Title="Literature",Credits=4}
                };
                foreach (Course course in courses)
                {
                    context.Courses.Add(course);
                }
                context.SaveChanges();
                var enrollments = new Enrollment[]
                {
                    new Enrollment{LearnerID=1,CourseID=1050,Grade=5.7f},
                    new Enrollment{LearnerID=1,CourseID=4022,Grade=7.5f},
                    new Enrollment{LearnerID=1,CourseID=4041,Grade=8f},
                    new Enrollment{LearnerID=2,CourseID=1045,Grade=3.5f},
                    new Enrollment{LearnerID=2,CourseID=3141,Grade=9f},
                    new Enrollment{LearnerID=2,CourseID=2021,Grade=7f},
                    };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
