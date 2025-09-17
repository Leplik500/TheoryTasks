SELECT
    u.Username,
    COUNT(r.ReviewID) AS TotalReviews,
    AVG(r.Rating) AS AvgRating,
    MAX(r.CreatedDate) AS LastReviewDate,
    COUNT(CASE WHEN r.IsRecommended = 1 THEN 1 END) AS PositiveReviews
FROM Users u
         INNER JOIN Reviews r ON u.UserID = r.UserID
WHERE u.IsActive = 1
GROUP BY u.UserID, u.Username
HAVING COUNT(r.ReviewID) > 5
ORDER BY TotalReviews DESC, AvgRating DESC;
