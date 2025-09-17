using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task5.Models;

namespace Task5.Services;

public interface IAnimeService
{
    Task<Guid> CreateAnimeAsync(Anime anime);
    Task<List<Anime>> GetAllAnimeAsync();
    Task<Anime?> GetAnimeByIdAsync(Guid id);
    Task<bool> UpdateAnimeAsync(Anime anime);
    Task<bool> DeleteAnimeAsync(Guid id);
}