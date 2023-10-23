using CRUDusingEntityFramework.Data;

namespace CRUDusingEntityFramework.Models
{
    public class StudentDAL
    {
        ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Student> GetStudents()
        {
            // LINQ
            var result = from b in db.Students
                         select b;

            return result;

            // Lambda
            //return db.Books.ToList();
        }
        public Student GetStudent(int id)
        {
            var result = db.Students.Where(x => x.Id == id).SingleOrDefault();
            return result;

            //LINQ
            //var res = from b in db.Books
            //          where b.Id == id
            //          select b;

        }
        public int AddStudent(Student student)
        {
            // added the book object in the DBSet
            db.Students.Add(student);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            int res = 0;
            // find the record from Dbset that we need to modify
            //var result = (from b in db.Books
            //             where b.Id == book.Id
            //             select b).FirstOrDefault();

            var result = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = student.Name; // book contains new data, result contains old data
                result.Percentage = student.Percentage;
                
                res = db.SaveChanges();// update those changes in DB
            }

            return res;
        }
        public int DeleteStudent(int id)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Students.Remove(result); // remove from DbSet
                res = db.SaveChanges();
            }

            return res;
        }
    }

}
    

