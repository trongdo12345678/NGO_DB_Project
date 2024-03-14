using NGO_DB_Project.Models;

namespace NGO_DB_Project.Service;

public interface ProjectypeService
{
    public List<ProjectType> GetProtype();
    public bool AddPTy(ProjectType pt);
	public bool DeletePTy(int id);
    public bool UpdatePTy(ProjectType pt);
	public ProjectType GetPT(int id);
    public (int, int) GetPaginationInfo(int pageSize, int currentPage);
    public List<ProjectType> GetlistPbyPages(int page, int pageSize);
}
