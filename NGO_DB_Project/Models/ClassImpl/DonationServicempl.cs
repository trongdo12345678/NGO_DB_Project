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
	public bool AddDonaAdmin(Donation dona)
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
}
