using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NGO_DB_Project.Service;

namespace NGO_DB_Project.Models.ClassImpl;

public class ProjectServicempl : ProjectService
{
    private readonly GiveAidContext _context;
    public ProjectServicempl(GiveAidContext context)
    {
        _context = context;
    }

    //lấy tổng số trang của cái bản projectType 
    public (int, int) GetPaginationInfo(int pageSize, int currentPage)
    {
        try
        {
            int totalItems = _context.Projects.Count();

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
    public List<Project> GetlistPbyPages(int page, int pageSize)
    {
        try
        {

            int skip = (page - 1) * pageSize;

            var projects = _context.Projects
             .OrderByDescending(pt => pt.Id)
             .Skip(skip)
             .Take(pageSize)
             .ToList();

            return projects;
        }
        catch (Exception)
        {
            return [];
        }
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
	//add product
	public bool AddPro(Project pro)
    {
        try
        {
			_context.Projects.Add(pro);
            return _context.SaveChanges() > 0;
        }
        catch(Exception)
        {
            return false;
        }
    }
	public string UploadFile(IFormFile file)
	{
		if (file != null && file.Length > 0)
		{
			try
			{
				// Lấy tên tệp
				string fileName = GetFileName(file.ContentDisposition);

				// Tạo đường dẫn lưu trữ tệp
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

				// Copy tệp vào thư mục lưu trữ
				using (var stream = new FileStream(path, FileMode.Create))
				{
					file.CopyTo(stream);
				}

				// Trả về tên tệp
				return fileName;
			}
			catch (Exception)
			{
				return null; // Xử lý lỗi tải lên file ở đây
			}
		}
		else
		{
			return null; // Xử lý tệp không tồn tại ở đây
		}
	}

	private string GetFileName(string contentDisposition)
	{
		if (contentDisposition == null)
		{
			return null;
		}

		string[] contentDispositionItems = contentDisposition.Split(';');
		foreach (var item in contentDispositionItems)
		{
			if (item.Trim().StartsWith("filename="))
			{
				return item.Substring("filename=".Length).Trim('"');
			}
		}

		return null;
	}
	public bool DeletePro(int id)
	{
		try
		{
			var d = _context.Projects.FirstOrDefault(p => p.Id.Equals(id));
			if (d != null)
			{
				_context.Projects.Remove(d);
				return _context.SaveChanges() > 0;
			}
			return false;
		}catch (Exception)
		{
			return false;
		}
	}


}
