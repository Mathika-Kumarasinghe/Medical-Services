
USE MedicalDevicePlatformDB;

INSERT INTO Notices
(DeviceName, Title, Description, NoticeType, PublishedDate)
VALUES
(
    'Patient Monitoring Device',
    'Device Overheating Safety Alert',
    'Users should monitor the device temperature during operation. Stop using the device if unusual overheating occurs and contact the manufacturer.',
    'Safety',
    GETDATE()
),
(
    'Infusion Pump Model X',
    'Infusion Pump Product Recall',
    'A product recall has been issued for selected units due to a potential medication delivery accuracy problem. Contact the manufacturer for further instructions.',
    'Recall',
    GETDATE()
),
(
    'Digital Blood Pressure Monitor',
    'Measurement Accuracy Notice',
    'Users should check the device calibration regularly to ensure accurate blood pressure measurements.',
    'Safety',
    GETDATE()
);

SELECT * FROM Notices;
