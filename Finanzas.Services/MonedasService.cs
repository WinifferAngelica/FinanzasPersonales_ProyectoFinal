using Aplicada1.Core;
using Finanzas.Data.Context;
using Finanzas.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzas.Services;

public class MonedasService(
    IDbContextFactory<FinanzasContext> contextFactory
) : IServiceResult<Moneda, int>
{
    public async Task<Result> Guardar(Moneda entidad)
    {
        if (!await Existe(entidad.IdMoneda))
            return Result.Success(await Insertar(entidad));

        return Result.Success(await Modificar(entidad));
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Monedas.AnyAsync(e => e.IdMoneda == id);
    }

    private async Task<bool> Insertar(Moneda entidad)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Monedas.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Moneda entidad)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Moneda?>> Buscar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Monedas
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdMoneda == id);
    }

    public async Task<Result<List<Moneda>>> GetList(Expression<Func<Moneda, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Monedas
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Monedas
            .Where(e => e.IdMoneda == id)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }
}