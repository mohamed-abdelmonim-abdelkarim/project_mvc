using task1.data;
using task1.Models;

namespace task1.repo
{
    public interface Idepartrepoe
    {
        public List<department> getall();
        public department getid(int id);
        public void add(department department);
        public void delete(int id);
        public void update(department department);
    }
    public class departrepo : Idepartrepoe
    {
        dbcontext dbobj =new dbcontext();
        public void add(department department)
        {
           dbobj.departments.Add(department);
            dbobj.SaveChanges();
        }

        public void delete(int? id)
        {
            var del = dbobj.departments.FirstOrDefault(i=>i.dept_Id==id);
            dbobj.departments.Remove(del);
            dbobj.SaveChanges();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<department> getall()
        {
            return dbobj.departments.ToList();
        }

        public department getid(int id)
        {
            return dbobj.departments.FirstOrDefault(i => i.dept_Id == id);
        }

        public void update(department department)
        {
           dbobj.departments.Update(department);
            dbobj.SaveChanges();
        }
    }
}
