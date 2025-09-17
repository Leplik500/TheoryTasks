UPDATE Users
SET LastLoginDate = GETDATE(),
    AvatarURL = 'https://example.com/avatars/new_avatar.jpg'
WHERE Username = 'AnimeOtaku2024';