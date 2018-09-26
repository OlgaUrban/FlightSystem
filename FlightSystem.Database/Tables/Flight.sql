CREATE TABLE [Flight](
	[ID] [int] IDENTITY(1,1) NOT NULL,
    [AircraftId] [int] NOT NULL,
    [DepartureAirportId] [int] NOT NULL,
	[DepartureDateTime] [datetime] NOT NULL,
	[DestinationAirportId] [int] NOT NULL,
	[DestinationDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
	CONSTRAINT [FK_Flight_AircraftId] FOREIGN KEY([AircraftId]) REFERENCES [Aircraft] ([Id]), 
    CONSTRAINT [FK_Flight_DepartureAirportId] FOREIGN KEY([DepartureAirportId]) REFERENCES [Airport] ([Id]),
	CONSTRAINT [FK_Flight_DestinationAirportId] FOREIGN KEY([DestinationAirportId]) REFERENCES [Airport] ([Id])) ON [PRIMARY]

