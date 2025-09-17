using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Task5.Models;

namespace Task5.Services;

public class AdoNetService(string connectionString)
        : IAnimeService
{
    public async Task<Guid> CreateAnimeAsync(Anime anime)
    {
        anime.AnimeID = Guid.NewGuid();
        anime.CreatedDate = DateTime.Now;

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = """

                                       INSERT INTO Anime (AnimeID, Title, OriginalTitle, Description, EpisodeCount, Duration, 
                                                        ReleaseDate, EndDate, AverageRating, IsCompleted, PosterURL, CreatedDate)
                                       VALUES (@AnimeID, @Title, @OriginalTitle, @Description, @EpisodeCount, @Duration,
                                              @ReleaseDate, @EndDate, @AverageRating, @IsCompleted, @PosterURL, @CreatedDate)
                           """;

        await using var command = new SqlCommand(sql, connection);
        
        command.Parameters.AddWithValue("@AnimeID", anime.AnimeID);
        command.Parameters.AddWithValue("@Title", anime.Title);
        command.Parameters.AddWithValue("@OriginalTitle", (object?)anime.OriginalTitle ?? DBNull.Value);
        command.Parameters.AddWithValue("@Description", (object?)anime.Description ?? DBNull.Value);
        command.Parameters.AddWithValue("@EpisodeCount", anime.EpisodeCount);
        command.Parameters.AddWithValue("@Duration", anime.Duration);
        command.Parameters.AddWithValue("@ReleaseDate", anime.ReleaseDate);
        command.Parameters.AddWithValue("@EndDate", (object?)anime.EndDate ?? DBNull.Value);
        command.Parameters.AddWithValue("@AverageRating", (object?)anime.AverageRating ?? DBNull.Value);
        command.Parameters.AddWithValue("@IsCompleted", anime.IsCompleted);
        command.Parameters.AddWithValue("@PosterURL", (object?)anime.PosterURL ?? DBNull.Value);
        command.Parameters.AddWithValue("@CreatedDate", anime.CreatedDate);

        await command.ExecuteNonQueryAsync();
        
        Console.WriteLine($"[ADO.NET] Created anime: {anime.Title} (ID: {anime.AnimeID})");
        return anime.AnimeID;
    }

    public async Task<List<Anime>> GetAllAnimeAsync()
    {
        var animeList = new List<Anime>();

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = "SELECT * FROM Anime ORDER BY CreatedDate DESC";
        await using var command = new SqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var anime = new Anime
            {
                AnimeID = reader.GetGuid("AnimeID"),
                Title = reader.GetString("Title"),
                OriginalTitle = await reader.IsDBNullAsync("OriginalTitle") ? null : reader.GetString("OriginalTitle"),
                Description = await reader.IsDBNullAsync("Description") ? null : reader.GetString("Description"),
                EpisodeCount = reader.GetInt32("EpisodeCount"),
                Duration = reader.GetDecimal("Duration"),
                ReleaseDate = reader.GetDateTime("ReleaseDate"),
                EndDate = await reader.IsDBNullAsync("EndDate") ? null : reader.GetDateTime("EndDate"),
                AverageRating = await reader.IsDBNullAsync("AverageRating") ? null : reader.GetDecimal("AverageRating"),
                IsCompleted = reader.GetBoolean("IsCompleted"),
                PosterURL = await reader.IsDBNullAsync("PosterURL") ? null : reader.GetString("PosterURL"),
                CreatedDate = reader.GetDateTime("CreatedDate")
            };
            animeList.Add(anime);
        }

        Console.WriteLine($"[ADO.NET] Retrieved {animeList.Count} anime records");
        return animeList;
    }

    public async Task<Anime?> GetAnimeByIdAsync(Guid id)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = "SELECT * FROM Anime WHERE AnimeID = @AnimeID";
        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AnimeID", id);

        await using var reader = await command.ExecuteReaderAsync();
        
        if (await reader.ReadAsync())
        {
            return new Anime
            {
                AnimeID = reader.GetGuid("AnimeID"),
                Title = reader.GetString("Title"),
                OriginalTitle = await reader.IsDBNullAsync("OriginalTitle") ? null : reader.GetString("OriginalTitle"),
                Description = await reader.IsDBNullAsync("Description") ? null : reader.GetString("Description"),
                EpisodeCount = reader.GetInt32("EpisodeCount"),
                Duration = reader.GetDecimal("Duration"),
                ReleaseDate = reader.GetDateTime("ReleaseDate"),
                EndDate = await reader.IsDBNullAsync("EndDate") ? null : reader.GetDateTime("EndDate"),
                AverageRating = await reader.IsDBNullAsync("AverageRating") ? null : reader.GetDecimal("AverageRating"),
                IsCompleted = reader.GetBoolean("IsCompleted"),
                PosterURL = await reader.IsDBNullAsync("PosterURL") ? null : reader.GetString("PosterURL"),
                CreatedDate = reader.GetDateTime("CreatedDate")
            };
        }

        return null;
    }

    public async Task<bool> UpdateAnimeAsync(Anime anime)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = """

                                       UPDATE Anime 
                                       SET Title = @Title, OriginalTitle = @OriginalTitle, Description = @Description,
                                           EpisodeCount = @EpisodeCount, Duration = @Duration, AverageRating = @AverageRating,
                                           IsCompleted = @IsCompleted, PosterURL = @PosterURL
                                       WHERE AnimeID = @AnimeID
                           """;

        await using var command = new SqlCommand(sql, connection);
        
        command.Parameters.AddWithValue("@AnimeID", anime.AnimeID);
        command.Parameters.AddWithValue("@Title", anime.Title);
        command.Parameters.AddWithValue("@OriginalTitle", (object?)anime.OriginalTitle ?? DBNull.Value);
        command.Parameters.AddWithValue("@Description", (object?)anime.Description ?? DBNull.Value);
        command.Parameters.AddWithValue("@EpisodeCount", anime.EpisodeCount);
        command.Parameters.AddWithValue("@Duration", anime.Duration);
        command.Parameters.AddWithValue("@AverageRating", (object?)anime.AverageRating ?? DBNull.Value);
        command.Parameters.AddWithValue("@IsCompleted", anime.IsCompleted);
        command.Parameters.AddWithValue("@PosterURL", (object?)anime.PosterURL ?? DBNull.Value);

        var rowsAffected = await command.ExecuteNonQueryAsync();
        
        Console.WriteLine($"[ADO.NET] Updated anime: {anime.Title}");
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAnimeAsync(Guid id)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = "DELETE FROM Anime WHERE AnimeID = @AnimeID";
        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@AnimeID", id);

        var rowsAffected = await command.ExecuteNonQueryAsync();
        
        Console.WriteLine($"[ADO.NET] Deleted anime with ID: {id}");
        return rowsAffected > 0;
    }
}
