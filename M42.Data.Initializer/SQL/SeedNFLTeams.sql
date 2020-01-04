
 create table _ImportTeams
(
	FranchiseIdentifier varchar(max) ,
	Year int ,
	City varchar(max) null ,
	Name varchar(max) ,
	LeagueIdentifier varchar(max) ,
	ConferenceIdentifier varchar(max) null ,
	DivisionIdentifier varchar(max) null ,
	Wins int null,
	Losses int null,
	Ties int null ,
	CoachIdentifier varchar(max) null ,
	OwnerIdentifier varchar(max) null ,
	GMIdentifier varchar(max) null
)

declare @teamPathname varchar(max)
set @teamPathname = 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\'

bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\49ers.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Bears.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Bengals.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Bills.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Broncos.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Browns.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Buccaneers.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Cardinals.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Chargers.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Chiefs.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Colts.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Cowboys.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Dolphins.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Eagles.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Falcons.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Giants.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Jaguars.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Jets.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Lions.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Packers.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Panthers.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Patriots.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Raiders.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Rams.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Ravens.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Redskins.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Saints.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Seahawks.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Steelers.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Texans.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Titans.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )
bulk insert dbo._ImportTeams from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Teams\Vikings.csv' with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

-- create the Teams 

insert into Sports.Teams (FranchiseId , SeasonId, ConferenceId, DivisionId, StadiumId, Identifier, City, Name, Wins, Losses, Ties)
select f.Id as FranchiseId ,
	s.Id as SeasonId ,
	c.Id as ConferenceId ,
	d.Id as DivisionId ,
	null as StadiumId ,
	Convert(varchar(4), t.year) + '-' + f.Identifier as TeamIdentifier ,
	t.City ,
	t.Name ,
	t.Wins ,
	t.Losses ,
	t.Ties
from _ImportTeams t
inner join Organizations f on t.FranchiseIdentifier = f.Identifier
inner join Organizations l on t.LeagueIdentifier = l.Identifier
inner join Sports.Seasons s on s.Year = t.Year and s.LeagueID = l.Id
left outer join Sports.Conferences c on c.Identifier = t.ConferenceIdentifier
left outer join Sports.Divisions d on d.Identifier = t.DivisionIdentifier



-- add owners to teams

insert into Sports.TeamPeople ( TeamId, PersonId, TeamRoleId ) 
select tt.Id ,
	owner.Id ,
	1 -- owner
from _ImportTeams t
inner join Sports.Teams tt on tt.Identifier = Convert(varchar(4), t.year) + '-'+ FranchiseIdentifier 
join dbo.People owner on t.OwnerIdentifier = owner.Identifier

-- add GMs to teams

insert into Sports.TeamPeople ( TeamId, PersonId, TeamRoleId ) 
select tt.Id ,
	gm.Id ,
	4 -- GM
from _ImportTeams t
inner join Sports.Teams tt on tt.Identifier = Convert(varchar(4), t.year) + '-'+ FranchiseIdentifier 
inner join dbo.People gm on t.GMIdentifier = gm.Identifier

-- add Head Coaches to teams

insert into Sports.TeamPeople ( TeamId, PersonId, TeamRoleId ) 
select tt.Id ,
	coach.Id ,
	5 -- Head Coach
from _ImportTeams t
inner join Sports.Teams tt on tt.Identifier = Convert(varchar(4), t.year) + '-'+ FranchiseIdentifier 
inner join dbo.People coach on t.CoachIdentifier = coach.Identifier


