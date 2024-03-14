using Microsoft.EntityFrameworkCore;
using NGO_DB_Project.Service;
using System.Diagnostics;

namespace NGO_DB_Project.Models.ClassImpl;

public class ProjectTypeServiceImpl : ProjectypeService
{
    private readonly GiveAidContext _context;
    public ProjectTypeServiceImpl(GiveAidContext context)
    {
        _context = context;
    }
    public List<ProjectType> GetProtype()
    {
        try
        {
            var res = _context.ProjectTypes.ToList();
            if (res != null) 
            { 
                return res;
            }
            return [];
        }
        catch (Exception)
        {
            
            return [];
        }
    }
    public bool AddPTy(ProjectType pt)
    {
        try
        {
            _context.ProjectTypes.Add(pt);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public bool DeletePTy(int id)
    {
        try
        {
            var d = _context.ProjectTypes.FirstOrDefault(p => p.Id.Equals(id));
            if (d != null)
			{
				_context.ProjectTypes.Remove(d);
				
				return _context.SaveChanges()  > 0;
			}
			return false;
		}catch (Exception)
        {
            
            return false;
        }
    }
	public ProjectType GetPT(int id)
	{
		try
		{
			var projectType = _context.ProjectTypes

				.FirstOrDefault(p => p.Id == id);
			if (projectType != null) return projectType;
			return new ProjectType();
		}
		catch (Exception)
		{
			return new ProjectType();
		}
	}
	public bool UpdatePTy(ProjectType pt)
    {
        try
        {

            var e = _context.ProjectTypes.FirstOrDefault(e => e.Id == pt.Id);

            if (e != null)
            {

                e.TypeName = pt.TypeName;
                return _context.SaveChanges() > 0;
            }
            return false;

        }
        catch (Exception)
        {
            return false;
        }
    }

}
