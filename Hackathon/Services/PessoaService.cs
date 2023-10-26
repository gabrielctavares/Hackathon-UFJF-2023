using Hackathon.Data;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services;

public class PessoaService : BaseService<Pessoa>
{
    public PessoaService (DataContext context) : base(context)
    {
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var model = await _context.Pessoa.FindAsync(id);

            if (model == null)
                return false;

            _context.Pessoa.Remove(model);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
            
    public override async Task<List<Pessoa>> GetAll()
    {
        return await _context.Pessoa.ToListAsync();
    }

    public override async Task<Pessoa> GetById(int id)
    {
        return await _context.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
    }
}