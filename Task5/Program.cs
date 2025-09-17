using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Task5.Models;
using Task5.Services;

namespace Task5;

internal abstract class Program
{
    private static async Task Main()
    {
        Directory.SetCurrentDirectory("../../../");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Connection string not found in appsettings.json");
            return;
        }

        Console.WriteLine($"Connection: {connectionString[..Math.Min(50, connectionString.Length)]}...\n");

        var testAnime = new Anime
        {
            Title = "Test Anime",
            OriginalTitle = "Test Anime Original",
            Description = "This is a test anime created by the console utility.",
            EpisodeCount = 12,
            Duration = 24.5m,
            ReleaseDate = DateTime.Now.AddDays(-30),
            AverageRating = 8.5m,
            IsCompleted = true,
            PosterURL = "https://example.com/test-anime-poster.jpg"
        };

        try
        {
            Console.WriteLine("=== ADO.NET Service Demo ===");
            await DemoAdoNetService(connectionString, testAnime);

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Console.WriteLine("=== Entity Framework Core Service Demo ===");
            await DemoEfCoreService(connectionString, testAnime);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }

    private static async Task DemoAdoNetService(string connectionString, Anime testAnime)
    {
        var adoService = new AdoNetService(connectionString);

        var newId = await adoService.CreateAnimeAsync(testAnime);

        var allAnime = await adoService.GetAllAnimeAsync();
        Console.WriteLine($"Total anime count: {allAnime.Count}");

        var foundAnime = await adoService.GetAnimeByIdAsync(newId);
        if (foundAnime != null)
        {
            Console.WriteLine($"Found anime: {foundAnime.Title} ({foundAnime.EpisodeCount} episodes)");

            foundAnime.Title = "Updated Test Anime (ADO.NET)";
            foundAnime.AverageRating = 9.0m;
            await adoService.UpdateAnimeAsync(foundAnime);

            var updatedAnime = await adoService.GetAnimeByIdAsync(newId);
            Console.WriteLine($"After update: {updatedAnime?.Title} (Rating: {updatedAnime?.AverageRating})");

            await adoService.DeleteAnimeAsync(newId);
            
            var deletedAnime = await adoService.GetAnimeByIdAsync(newId);
            Console.WriteLine($"After deletion - Anime found: {deletedAnime != null}");
        }
    }

    private static async Task DemoEfCoreService(string connectionString, Anime testAnime)
    {
        var efService = new EfCoreService(connectionString);

        var efTestAnime = new Anime
        {
            Title = testAnime.Title + " (EF)",
            OriginalTitle = testAnime.OriginalTitle,
            Description = testAnime.Description,
            EpisodeCount = testAnime.EpisodeCount,
            Duration = testAnime.Duration,
            ReleaseDate = testAnime.ReleaseDate,
            AverageRating = testAnime.AverageRating,
            IsCompleted = testAnime.IsCompleted,
            PosterURL = testAnime.PosterURL
        };

        var newId = await efService.CreateAnimeAsync(efTestAnime);

        var allAnime = await efService.GetAllAnimeAsync();
        Console.WriteLine($"Total anime count: {allAnime.Count}");

        var foundAnime = await efService.GetAnimeByIdAsync(newId);
        if (foundAnime != null)
        {
            Console.WriteLine($"Found anime: {foundAnime.Title} ({foundAnime.EpisodeCount} episodes)");

            foundAnime.Title = "Updated Test Anime (EF Core)";
            foundAnime.AverageRating = 9.5m;
            await efService.UpdateAnimeAsync(foundAnime);

            var updatedAnime = await efService.GetAnimeByIdAsync(newId);
            Console.WriteLine($"After update: {updatedAnime?.Title} (Rating: {updatedAnime?.AverageRating})");

            await efService.DeleteAnimeAsync(newId);
            
            var deletedAnime = await efService.GetAnimeByIdAsync(newId);
            Console.WriteLine($"After deletion - Anime found: {deletedAnime != null}");
        }

        efService.Dispose();
    }
}
