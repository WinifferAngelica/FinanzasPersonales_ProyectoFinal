using Aplicada1.Core;
using Finanzas.Data.Context;
using Finanzas.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzas.Services;

public class CuentasService(
    IDbContextFactory<FinanzasContext> contextFactory
) : IServiceResult<Cuenta, int>
{
    public async Task<Result> Guardar(Cuenta entidad)
    {
        if (!await Existe(entidad.IdCuenta))
            return Result.Success(await Insertar(entidad));

        return Result.Success(await Modificar(entidad));
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Cuentas.AnyAsync(e => e.IdCuenta == id);
    }

    private async Task<bool> Insertar(Cuenta entidad)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Cuentas.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cuenta entidad)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Cuenta?>> Buscar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Cuentas
            .Include(e => e.IdMonedaNavigation)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdCuenta == id);
    }

    public async Task<Result<List<Cuenta>>> GetList(Expression<Func<Cuenta, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Cuentas
            .Include(e => e.IdMonedaNavigation)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Cuentas
            .Where(e => e.IdCuenta == id)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }
}