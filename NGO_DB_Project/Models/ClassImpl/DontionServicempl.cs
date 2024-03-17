using NGO_DB_Project.Service;

namespace NGO_DB_Project.Models.ClassImpl;

public class DontionServicempl : DontionService
{
	private readonly GiveAidContext _context;
	public DontionServicempl(GiveAidContext context)
	{
		_context = context;
	}
}
