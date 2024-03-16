using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;

namespace NGO_DB_Project.Service;

public interface ProjectService
{
	public List<ProjectType> GetProtype();
    public (int, int) GetPaginationInfo(int pageSize, int currentPage);
    public List<Project> GetlistPbyPages(int page, int pageSize);
    public bool AddPro(Project pro);
	public string UploadFile(IFormFile file);
	public bool DeletePro(int id);
	public bool UpdatePro(Project pro);
	public Project GetPro(int id);
}
