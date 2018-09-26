INSERT INTO [Airport] ([Name],[Latitude],[Longitude])
     VALUES ('Paris', 12.44, 56.77),
           ('Minsk', 34.786, 12.6757),
		   ('Moscow', 22.545, 11.45667)

INSERT INTO [Aircraft] ([Name],[FuelConsumption],[TakeoffEffort])
     VALUES ('Boeing 737-200', 230, 98),
           ('Boeing 737-500', 198, 67)

INSERT INTO [dbo].[Flight] ([AircraftId],[DepartureAirportId],[DepartureDateTime],[DestinationAirportId],[DestinationDateTime])
     VALUES (1, 1, '25/09/2018 06:00', 2, '25/09/2018 15:00')

GO