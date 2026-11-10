using Aplicada1.Core;
using Finanzas.Data.Context;
using Finanzas.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzas.Services;

public class CategoriasService(
    IDbContextFactory<FinanzasContext> contextFactory
) : IServiceResult<Categoria, int>
{
    public async Task<Result> Guardar(Categoria entidad)
    {
        if (!await Existe(entidad.IdCategoria))
            return Result.Success(await Insertar(entidad));

        return Result.Success(await Modificar(entidad));
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Categorias.AnyAsync(e => e.IdCategoria == id);
    }

    private async Task<bool> Insertar(Categoria entidad)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Categorias.Add(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Categoria entidad)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(entidad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Categoria?>> Buscar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdCategoria == id);
    }

    public async Task<Result<List<Categoria>>> GetList(Expression<Func<Categoria, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Categorias
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Categorias
            .Where(e => e.IdCategoria == id)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }
}