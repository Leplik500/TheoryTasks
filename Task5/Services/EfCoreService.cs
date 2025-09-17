using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task5.Data;
using Task5.Models;

namespace Task5.Services;

public class EfCoreService : IAnimeService
{
    private readonly AnimePortalContext _context;

    public EfCoreService(string connectionString)
    {
        var options = new DbContextOptionsBuilder<AnimePortalContext>()
            .UseSqlServer(connectionString)
            .Options;
        
        _context = new AnimePortalContext(options);
    }

    public async Task<Guid> CreateAnimeAsync(Anime anime)
    {
        anime.AnimeID = Guid.NewGuid();
        anime.CreatedDate = DateTime.Now;

        await _context.Anime.AddAsync(anime);
        await _context.SaveChangesAsync();

        Console.WriteLine($"[EF Core] Created anime: {anime.Title} (ID: {anime.AnimeID})");
        return anime.AnimeID;
    }

    public async Task<List<Anime>> GetAllAnimeAsync()
    {
        var animeList = await _context.Anime
            .AsNoTracking() 
            .OrderByDescending(a => a.CreatedDate)
            .ToListAsync();

        Console.WriteLine($"[EF Core] Retrieved {animeList.Count} anime records");
        return animeList;
    }

    public async Task<Anime?> GetAnimeByIdAsync(Guid id)
    {
        var anime = await _context.Anime
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AnimeID == id);

        if (anime != null)
        {
            Console.WriteLine($"[EF Core] Found anime: {anime.Title}");
        }

        return anime;
    }

    public async Task<bool> UpdateAnimeAsync(Anime anime)
    {
        // Проверяем, отслеживается ли уже сущность с этим ID
        var trackedEntity = _context.ChangeTracker.Entries<Anime>()
            .FirstOrDefault(e => e.Entity.AnimeID == anime.AnimeID);
        
        if (trackedEntity != null)
        {
            trackedEntity.State = EntityState.Detached;
        }

        _context.Anime.Update(anime);
        var rowsAffected = await _context.SaveChangesAsync();

        Console.WriteLine($"[EF Core] Updated anime: {anime.Title}");
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAnimeAsync(Guid id)
    {
        var anime = await _context.Anime.FindAsync(id);
        if (anime == null) return false;

        _context.Anime.Remove(anime);
        var rowsAffected = await _context.SaveChangesAsync();

        Console.WriteLine($"[EF Core] Deleted anime: {anime.Title}");
        return rowsAffected > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
