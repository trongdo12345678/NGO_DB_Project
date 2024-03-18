using NGO_DB_Project.Service;

namespace NGO_DB_Project.Models.ClassImpl;

public class DonationServicempl : DonationService
{
	private readonly GiveAidContext _context;
	public DonationServicempl(GiveAidContext context)
	{
		_context = context;
	}
	//adđ donation
	public bool AddDona(Donation dona)
	{
		try
		{
			_context.Donations.Add(dona);
			return _context.SaveChanges() > 0;

		}catch (Exception)
		{
			return false;
		}
	}
	public List<Project> GetPro()
	{
		try
		{
			var res = _context.Projects.ToList();
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
    public List<Donation> GetDona()
    {
        try
        {
            var res = _context.Donations.ToList();
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
	public List<Member> GetMem()
	{
		try
		{
			var res = _context.Members.ToList();
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
	public (int, int) GetPaginationInfo(int pageSize, int currentPage)
	{
		try
		{
			int totalItems = _context.Donations.Count();

			int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

			currentPage = Math.Max(1, Math.Min(currentPage, totalPages));

			return (totalPages, currentPage);
		}
		catch (Exception)
		{
			return (1, 1);
		}
	}
	//lấy projecttype theo từng trang 
	public List<Donation> GetlistPbyPages(int page, int pageSize)
	{
		try
		{

			int skip = (page - 1) * pageSize;

			var done = _context.Donations
			 .OrderByDescending(pt => pt.Id)
			 .Skip(skip)
			 .Take(pageSize)
			 .ToList();

			return done;
		}
		catch (Exception)
		{
			return [];
		}
	}
}
