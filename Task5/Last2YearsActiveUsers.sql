SELECT
    UserID,
    Username,
    Email,
    RegistrationDate,
    DATEDIFF(DAY, LastLoginDate, GETDATE()) AS DaysSinceLastLogin
FROM Users
WHERE IsActive = 1
  AND RegistrationDate >= DATEADD(YEAR, -2, GETDATE())
  AND LastLoginDate IS NOT NULL
ORDER BY LastLoginDate DESC, Username;