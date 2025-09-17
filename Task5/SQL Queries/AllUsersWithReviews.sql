SELECT
    u.Username,
    u.Email,
    u.RegistrationDate,
    r.Rating,
    r.ReviewText,
    r.CreatedDate AS ReviewDate,
    a.Title AS AnimeTitle
FROM Users u
         LEFT JOIN Reviews r ON u.UserID = r.UserID
         LEFT JOIN Anime a ON r.AnimeID = a.AnimeID
WHERE u.IsActive = 1
ORDER BY u.Username, r.CreatedDate DESC;