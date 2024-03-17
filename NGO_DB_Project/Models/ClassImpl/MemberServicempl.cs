using NGO_DB_Project.Service;

namespace NGO_DB_Project.Models.ClassImpl;

public class MemberServicempl : MemberService
{
    private readonly GiveAidContext _context;
    public MemberServicempl(GiveAidContext context)
    {
        _context = context;
    }
    public bool AddMber(Member mem)
    {
        try
        {
            _context.Members.Add(mem);
            return _context.SaveChanges() > 0;
        }
        catch(Exception )
        {
            return false;
        }
    }
}
