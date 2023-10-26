using Hackathon.Data;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services;

public class EnderecoService : BaseService<Endereco>
{
    public EnderecoService (DataContext context) : base(context)
    {
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var model = await _context.Endereco.FindAsync(id);

            if (model == null)
                return false;

            _context.Endereco.Remove(model);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
            
    public override async Task<List<Endereco>> GetAll()
    {
        return await _context.Endereco.ToListAsync();
    }

    public override async Task<Endereco> GetById(int id)
    {
        return await _context.Endereco.FirstOrDefaultAsync(x => x.Id == id);
    }
}