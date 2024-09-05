using Microsoft.EntityFrameworkCore;
using task1.data;
using task1.Models;

namespace task1.repo
{
    public interface Irepostudent
    {
        public List<student> getall();
        public student getid(int id);
        public void add(student student);
        public void delete(int id);
        public void update(student student);
    }
    public class studentrepo : Irepostudent
    {
        dbcontext objstud=new dbcontext();

        public void add(student student)
        {
            objstud.Add(student);
            objstud.SaveChanges();
        }

        public void delete(int id)
        {
            var del = objstud.departments.FirstOrDefault(i => i.dept_Id == id);
            objstud.departments.Remove(del);
            objstud.SaveChanges();
        }
        //public void delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<student> getall()
        {
            return objstud.students. ToList();
        }

        public student getid(int id)
        {
            return objstud.students.FirstOrDefault(i => i.dept_id == id);
        }

        public void update(student student)
        {
            objstud.students.Update(student);
            objstud.SaveChanges();
        }
    }
}
