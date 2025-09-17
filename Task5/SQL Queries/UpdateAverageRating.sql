UPDATE Anime
SET AverageRating = (
    SELECT AVG(CAST(Rating AS DECIMAL(4,2)))
    FROM Reviews r
    WHERE r.AnimeID = Anime.AnimeID
)
WHERE AnimeID IN (
    SELECT DISTINCT AnimeID
    FROM Reviews
);