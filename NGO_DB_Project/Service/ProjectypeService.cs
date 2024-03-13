using NGO_DB_Project.Models;

namespace NGO_DB_Project.Service;

public interface ProjectypeService
{
    public List<ProjectType> GetProtype();
    public bool AddPTy(ProjectType pt);
	public int DeletePTy(int id);
}
