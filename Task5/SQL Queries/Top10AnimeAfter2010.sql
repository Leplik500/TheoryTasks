SELECT TOP 10
    Title,
    AverageRating,
    ReleaseDate,
    EpisodeCount
FROM Anime
WHERE ReleaseDate > '2010-01-01'
  AND IsCompleted = 1
ORDER BY AverageRating DESC, ReleaseDate;
