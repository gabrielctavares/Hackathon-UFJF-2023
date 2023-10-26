using Hackathon.Data;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services;

public class ClienteService : BaseService<Cliente>
{
    public ClienteService (DataContext context) : base(context)
    {
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var model = await _context.Cliente.FindAsync(id);

            if (model == null)
                return false;

            _context.Cliente.Remove(model);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
            
    public override async Task<List<Cliente>> GetAll()
    {
        return await _context.Cliente.ToListAsync();
    }

    public override async Task<Cliente> GetById(int id)
    {
        return await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id);
    }
}