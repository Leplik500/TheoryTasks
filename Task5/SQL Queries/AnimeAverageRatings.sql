SELECT
    a.Title,
    a.ReleaseDate,
    a.EpisodeCount,
    COUNT(r.ReviewID) AS ReviewCount,
    ROUND(AVG(CAST(r.Rating AS DECIMAL(4,2))), 2) AS AvgUserRating,
    a.AverageRating AS OfficialRating
FROM Anime a
         LEFT JOIN Reviews r ON a.AnimeID = r.AnimeID
GROUP BY a.AnimeID, a.Title, a.ReleaseDate, a.EpisodeCount, a.AverageRating
ORDER BY AvgUserRating DESC, ReviewCount DESC;