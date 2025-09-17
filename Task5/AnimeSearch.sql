SELECT
    Title,
    OriginalTitle,
    Description,
    AverageRating
FROM Anime
WHERE (Title LIKE '%Attack%' OR Title LIKE '%Hero%')
  AND AverageRating >= 8.0
ORDER BY
    CASE
        WHEN Title LIKE 'Attack%' THEN 1
        WHEN Title LIKE '%Hero%' THEN 2
        ELSE 3
        END,
    AverageRating DESC;