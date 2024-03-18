using NGO_DB_Project.Models;

namespace NGO_DB_Project.Service;

public interface DonationService
{
	public bool AddDona(Donation dona);
	public List<Project> GetPro();
	public List<Donation> GetDona();
	public List<Member> GetMem();
	public (int, int) GetPaginationInfo(int pageSize, int currentPage);
	public List<Donation> GetlistPbyPages(int page, int pageSize);
}
