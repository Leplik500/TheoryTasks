SELECT DISTINCT
    a.Title,
    a.EpisodeCount,
    a.Duration,
    a.AverageRating
FROM Anime a
         INNER JOIN AnimeGenres ag ON a.AnimeID = ag.AnimeID
         INNER JOIN Genres g ON ag.GenreID = g.GenreID
WHERE a.EpisodeCount BETWEEN 12 AND 50
  AND g.GenreName IN ('Action', 'Adventure', 'Drama')
  AND a.AverageRating IS NOT NULL
ORDER BY a.AverageRating DESC, a.EpisodeCount;