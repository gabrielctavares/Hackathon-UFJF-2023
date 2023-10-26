using Hackathon.Data;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services;

public class PessoaJuridicaService : BaseService<PessoaJuridica>
{
    public PessoaJuridicaService (DataContext context) : base(context)
    {
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var model = await _context.PessoaJuridica.FindAsync(id);

            if (model == null)
                return false;

            _context.PessoaJuridica.Remove(model);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
            
    public override async Task<List<PessoaJuridica>> GetAll()
    {
        return await _context.PessoaJuridica.ToListAsync();
    }

    public override async Task<PessoaJuridica> GetById(int id)
    {
        return await _context.PessoaJuridica.FirstOrDefaultAsync(x => x.Id == id);
    }
}