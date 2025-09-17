SELECT
    g.GenreName,
    COUNT(DISTINCT a.AnimeID) AS TotalAnime,
    AVG(a.AverageRating) AS AvgRating,
    MIN(a.ReleaseDate) AS EarliestRelease,
    MAX(a.ReleaseDate) AS LatestRelease,
    SUM(a.EpisodeCount) AS TotalEpisodes
FROM Genres g
         INNER JOIN AnimeGenres ag ON g.GenreID = ag.GenreID
         INNER JOIN Anime a ON ag.AnimeID = a.AnimeID
WHERE g.IsActive = 1
GROUP BY g.GenreName, g.GenreID
HAVING COUNT(DISTINCT a.AnimeID) >= 2
ORDER BY AvgRating DESC, TotalAnime DESC;