WITH GenrePopularity AS (
    SELECT
        g.GenreName,
        COUNT(DISTINCT wl.UserID) AS UniqueUsers,
        COUNT(wl.WatchListID) AS TotalEntries,
        AVG(wl.Score) AS AvgUserScore
    FROM Genres g
             INNER JOIN AnimeGenres ag ON g.GenreID = ag.GenreID
             INNER JOIN WatchList wl ON ag.AnimeID = wl.AnimeID
    GROUP BY g.GenreID, g.GenreName
)
SELECT
    GenreName,
    UniqueUsers,
    TotalEntries,
    ROUND(AvgUserScore, 2) AS AvgUserScore,
    RANK() OVER (ORDER BY UniqueUsers DESC) AS PopularityRank
FROM GenrePopularity
WHERE UniqueUsers >= 3
ORDER BY UniqueUsers DESC, AvgUserScore DESC;
