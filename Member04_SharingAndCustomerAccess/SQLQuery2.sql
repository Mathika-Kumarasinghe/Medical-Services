
USE MedicalDevicePlatformDB;

-- Add a test employee if one does not exist
IF NOT EXISTS (
    SELECT 1 FROM Users WHERE Email = 'employee@test.com'
)
BEGIN
    INSERT INTO Users (FullName, Email, Role)
    VALUES ('Test Employee', 'employee@test.com', 'Employee');
END;

-- Add a test customer if one does not exist
IF NOT EXISTS (
    SELECT 1 FROM Users WHERE Email = 'customer@test.com'
)
BEGIN
    INSERT INTO Users (FullName, Email, Role)
    VALUES ('Test Customer', 'customer@test.com', 'Customer');
END;

-- Add a test finding if one does not exist
IF NOT EXISTS (
    SELECT 1 FROM Findings WHERE Title = 'Device Safety Risk'
)
BEGIN
    INSERT INTO Findings (Title, Description)
    VALUES (
        'Device Safety Risk',
        'Potential overheating issue during device operation.'
    );
END;

SELECT * FROM Users;
SELECT * FROM Findings;
