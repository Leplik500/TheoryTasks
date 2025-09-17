SELECT
    u.UserID,
    u.Username,
    u.Email,
    u.RegistrationDate,
    COUNT(r.ReviewID) AS ReviewCount,
    AVG(r.Rating) AS AverageRating,
    MAX(r.CreatedDate) AS LastReviewDate
FROM Reviews r
         RIGHT JOIN Users u ON r.UserID = u.UserID
WHERE u.IsActive = 1
GROUP BY u.UserID, u.Username, u.Email, u.RegistrationDate
ORDER BY ReviewCount DESC, u.Username;
