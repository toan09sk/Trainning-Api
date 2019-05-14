use ChessResults
go

--select*from Player

exec GetAllTournament

--alter procedure InsertTournament
--@id int,
--@name nvarchar(200),
--@organizer nvarchar(200),
--@federation varchar(10),
--@director nvarchar(200),
--@chiefArbiter nvarchar(200),
--@location nvarchar(200),
--@ratingCalculation nvarchar(200),
--@startDate date,
--@endDate date,
--@rating int,
--@category int,
--@lastUpdate datetime,
--@isFinished bit,
--@numberOfRounds int
--as
--set nocount on
--insert into Tournament values(@id,@name,@organizer,@federation,@director,@chiefArbiter,@location,@ratingCalculation,
--@startDate,@endDate,@rating,@category,@lastUpdate,@isFinished,@numberOfRounds)
--select*from Tournament

--exec InsertTournament 25,'Name','Organizer','Federation','Director','ChiefArbiter','Location'
--						,'RatingCalculator','2019-04-09','2019-04-09'
--						,9999,9, '2019-04-08T20:05:00.000',0,99

--create procedure QueryTournamentById
--@id int
--as
--set nocount on
--select*from Tournament where Id=@id

--create procedure DeleteTournamentById
--@id int
--as
--set nocount on
--delete from Tournament where Id=@id

--alter procedure UpdateTournament
--@id int,
--@name nvarchar(200),
--@organizer nvarchar(200),
--@federation varchar(10),
--@director nvarchar(200),
--@chiefArbiter nvarchar(200),
--@location nvarchar(200),
--@ratingCalculation nvarchar(200),
--@startDate date,
--@endDate date,
--@rating int,
--@category int,
--@lastUpdate datetime,
--@isFinished bit,
--@numberOfRounds int
--as
--set nocount on
--update Tournament set
--Name=@name,
--Organizer=@organizer,
--Federation=@federation,
--Director=@director,
--ChiefArbiter=@chiefArbiter,
--Location=@location,
--RatingCalculation=@ratingCalculation,
--StartDate=@startDate,
--EndDate=@endDate,
--Rating=@rating,
--Category=@category,
--LastUpdated=@lastUpdate,
--IsFinished=@isFinished,
--NumberOfRounds=@numberOfRounds
--where Id=@id