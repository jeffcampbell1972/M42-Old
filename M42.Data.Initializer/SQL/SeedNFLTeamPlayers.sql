create table _ImportPlayerTeams
(
	PlayerIdentifier varchar(max) ,
	FranchiseIdentifier varchar(max) ,
	LeagueIdentifier varchar(max) ,
	StartYear int ,
	EndYear int ,
	PositionIdentifier varchar(max)
)

bulk insert dbo._ImportPlayerTeams 
from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\PlayerTeams.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

update _ImportPlayerTeams set PositionIdentifier = 'Football-' + PositionIdentifier where LeagueIdentifier in ('NFL','NCAAF')
update _ImportPlayerTeams set PositionIdentifier = 'Baseball-' + PositionIdentifier where LeagueIdentifier in ('MLB')
update _ImportPlayerTeams set PositionIdentifier = 'Basketball-' + PositionIdentifier where LeagueIdentifier in ('NBA','NCAAB')

insert into Sports.Players ( Id )
select distinct p.Id 
from _ImportPlayerTeams pt
inner join dbo.People p on pt.PlayerIdentifier = p.Identifier
where p.Id not in (select Id from Sports.Players)

insert into Sports.PlayerLeagues ( PlayerId, LeagueId, PositionId )
select distinct
	p.Id ,
	l.Id ,
	pos.Id 
from _ImportPlayerTeams pt
inner join dbo.People p on pt.PlayerIdentifier = p.Identifier
inner join dbo.Organizations l on pt.LeagueIdentifier = l.Identifier
left outer join Sports.Positions pos on pt.PositionIdentifier = pos.Identifier
left outer join Sports.PlayerLeagues existing on existing.PlayerID = p.Id and existing.LeagueId = l.Id
where existing.Id is null


select distinct t.Id as TeamId ,
	p.Id as PersonId ,
	8 as TeamRoleId , -- player
	pos.Id as PositionId
into #teamPeople
from _ImportPlayerTeams pt
inner join dbo.People p on pt.PlayerIdentifier = p.Identifier
inner join dbo.Organizations l on pt.LeagueIdentifier = l.Identifier
inner join dbo.Organizations f on pt.FranchiseIdentifier = f.Identifier
inner join Sports.Teams t on t.FranchiseId = f.Id 
inner join Sports.Seasons s on t.SeasonId = s.Id
left outer join Sports.Positions pos on pt.PositionIdentifier = pos.Identifier
left outer join Sports.TeamPeople existing on existing.TeamId = t.Id and existing.PersonId = p.Id and existing.TeamRoleId = 8
where s.Year >= pt.StartYear
and s.Year <= pt.EndYear
and existing.Id is null

insert into Sports.TeamPeople (TeamId, PersonId, TeamRoleId)
select TeamId, PersonId, TeamRoleId
from #teamPeople

insert into Sports.TeamPlayerPositions (TeamPersonId, PositionId)
select tp.Id ,
	pos.Id
from #teamPeople tmp
inner join Sports.TeamPeople tp on tp.TeamId = tmp.TeamId and tp.PersonId = tmp.PersonId and tp.TeamRoleId = tmp.TeamRoleId
inner join Sports.Positions pos on pos.Id = tmp.PositionId