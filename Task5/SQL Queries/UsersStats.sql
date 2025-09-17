SELECT
    u.Username,
    u.Email,
    a.Title,
    a.AverageRating,
    wl.Status,
    wl.EpisodesWatched,
    wl.Score AS UserScore,
    wl.IsFavorite,
    STRING_AGG(g.GenreName, ', ') AS Genres
FROM Users u
         INNER JOIN WatchList wl ON u.UserID = wl.UserID
         INNER JOIN Anime a ON wl.AnimeID = a.AnimeID
         INNER JOIN AnimeGenres ag ON a.AnimeID = ag.AnimeID
         INNER JOIN Genres g ON ag.GenreID = g.GenreID
WHERE u.IsActive = 1 AND wl.Status IN ('Completed', 'Watching')
GROUP BY u.UserID, u.Username, u.Email, a.AnimeID, a.Title, a.AverageRating,
         wl.Status, wl.EpisodesWatched, wl.Score, wl.IsFavorite
ORDER BY u.Username, a.Title;
