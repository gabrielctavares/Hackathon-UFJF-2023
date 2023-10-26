using Hackathon.Data;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services;

public class PessoaFisicaService : BaseService<PessoaFisica>
{
    public PessoaFisicaService (DataContext context) : base(context)
    {
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var model = await _context.PessoaFisica.FindAsync(id);

            if (model == null)
                return false;

            _context.PessoaFisica.Remove(model);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
            
    public override async Task<List<PessoaFisica>> GetAll()
    {
        return await _context.PessoaFisica.ToListAsync();
    }

    public override async Task<PessoaFisica> GetById(int id)
    {
        return await _context.PessoaFisica.FirstOrDefaultAsync(x => x.Id == id);
    }
}