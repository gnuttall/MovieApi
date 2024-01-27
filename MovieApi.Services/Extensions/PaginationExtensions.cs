using Microsoft.EntityFrameworkCore;
using MovieApi.Data.Entities.Common;
using MovieApi.Services.Enums;
using MovieApi.Services.Models;

namespace MovieApi.Services.Extensions;

public static class PaginationExtensions
{
    public static async Task<Pagination<TResult>> PaginateAsync<TResult>(
        this IQueryable<TResult> query, int currentPage, int pageSize) where TResult : BaseEntity
    {
        var skip = (currentPage - 1) * pageSize;

        var totalResults = await query.CountAsync();
        var results = await query.Skip(skip).Take(pageSize).ToListAsync();

        return new Pagination<TResult>
        {
            Results = results,
            CurrentPage = currentPage,
            TotalResults = totalResults,
            TotalPages = RoundUp(totalResults, pageSize)
        };
    }

    private static int RoundUp(int x, int y)
    {
        var (quotient, remainder) = Math.DivRem(x, y);
        return remainder == 0 ? quotient : quotient + 1;
    }

    public static IQueryable<TEntity> Sort<TEntity, TSortBy>(this IQueryable<TEntity> query, TSortBy sortBy, OrderBy orderBy) where TEntity : BaseEntity where TSortBy : Enum 
    {
        switch (orderBy)
        {
            case OrderBy.Descending:
                query = query.OrderByDescending(x => EF.Property<object>(x, sortBy.ToString()));
                break;
            default:
                query = query.OrderBy(x => EF.Property<object>(x, sortBy.ToString()));
                break;
        }

        return query;
    }
}