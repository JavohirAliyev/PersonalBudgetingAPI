IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    CREATE TABLE Users (
        Id NVARCHAR(36) PRIMARY KEY, -- Guid as string
        FirstName NVARCHAR(100) NOT NULL,
        LastName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(255) NOT NULL,
        ProfilePictureUrl NVARCHAR(255),
        DateOfBirth DATE, -- Stored as DATE
        Currency NVARCHAR(10) NOT NULL DEFAULT 'USD',
        PreferredLanguage NVARCHAR(10) NOT NULL DEFAULT 'en',
        IsEmailConfirmed BIT NOT NULL DEFAULT 0,
        Role NVARCHAR(50) NOT NULL DEFAULT 'User',
        CreatedAt DATETIME2 NOT NULL,
        UpdatedAt DATETIME2 NOT NULL,
        IsActive BIT NOT NULL DEFAULT 1
    );
END
-- Add indexes for performance (optional)
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_users_email')
    CREATE INDEX idx_users_email ON Users (Email);
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_users_isactive')
    CREATE INDEX idx_users_isactive ON Users (IsActive);
