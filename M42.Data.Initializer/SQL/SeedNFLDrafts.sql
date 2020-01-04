

create table _ImportDraftPicks
(
	SeasonIdentifier varchar(max) ,
	Round int ,
	Pick int ,
	TeamIdentifier varchar(max) ,
	PersonIdentifier varchar(500) ,
	FirstName varchar(max) ,
	LastName varchar(max) ,
	Suffix varchar(max) ,
	PositionIdentifier varchar(max) ,
	CollegeIdentifier varchar(max)
)

declare @year int
declare @yearString varchar(4)
declare @seasonIdentifier varchar(max)
declare @fileName varchar(max)
declare @bulkInsertCommand varchar(max)

set @year = 1970

while @year < 2020 begin

	set @yearString = convert(varchar(4), @year)
	set @seasonIdentifier = 'NFL' + @yearString
	set @fileName = 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\NFL\Drafts\' + @yearString + ' Draft.csv'
	set @bulkInsertCommand = 'bulk insert dbo._ImportDraftPicks from ''' + @fileName + ''' with ( FIELDTERMINATOR = '','', ROWTERMINATOR = ''\n'' )'

	exec (@bulkInsertCommand)

	-- append year to people whose identifier already exists in People table
	--update _ImportDraftPicks
	--set PersonIdentifier = PersonIdentifier + '-' + @yearString
	--from _ImportDraftPicks dp
	--inner join dbo.People p on dp.PersonIdentifier = p.Identifier
	--left outer join sports.Hofers hofer on hofer.Id = p.Id
	--where dp.SeasonIdentifier = @seasonIdentifier and hofer.Id is null

	-- append pick number to the people whose identifier is duplicated within a draft year
	--update _ImportDraftPicks
	--set PersonIdentifier = PersonIdentifier + '-' + convert(varchar(4), Pick)
	--from _ImportDraftPicks dp
	--where dp.SeasonIdentifier = @seasonIdentifier
	--and PersonIdentifier in (
	--	select personidentifier
	--	from _ImportDraftPicks
	--	where dp.SeasonIdentifier = @seasonIdentifier
	--	group by personidentifier
	--	having count(*) > 1
	--)

	insert into dbo.Logs (Message)
	select 'Draft Pick already exists: ' + PersonIdentifier
	from _ImportDraftPicks dp
	where dp.SeasonIdentifier = @seasonIdentifier
	and PersonIdentifier in (select identifier from dbo.People) 

	insert into dbo.People ( Identifier, Firstname, Lastname )
	select PersonIdentifier ,
		dp.FirstName ,
		dp.LastName 
	from _ImportDraftPicks dp
	where dp.SeasonIdentifier = @seasonIdentifier
	and PersonIdentifier not in (select identifier from dbo.People)

	set @year = @year + 1
end


update _ImportDraftPicks set CollegeIdentifier = Replace(CollegeIdentifier, 'Universityof','')

update _ImportDraftPicks
set CollegeIdentifier = case CollegeIdentifier 
when 'ArizonaStateUniversity' then 'ArizonaState'
when 'BostonU.' then 'BostonUniversity'
when 'BrighamYoung' then 'BYU'
when 'BrighamYoungUniversity' then 'BYU'
when 'ClemsonUniversity' then 'Clemson'
when 'C.W.Post' then 'CWPost'
when 'DukeUniversity' then 'Duke'
when 'FloridaStateUniversity' then 'FloridaState'
when 'JacksonStateUniversity' then 'JacksonState'
when 'KansasStateUniversity' then 'KansasState'
when 'LouisianaûMonroe' then 'LouisianaMonroe'
when 'LouisianaState' then 'LSU'
when 'LouisianaStateUniversity' then 'LSU'
when 'MichiganStateUniversity' then 'MichiganState'
when 'NorthCarolinaState' then 'NCState'
when 'NorthCarolinaStateUniversity' then 'NCState'
when 'Pitt' then 'Pittsburgh'
when 'SouthernCalifornia' then 'USC'
else CollegeIdentifier
end

update _ImportDraftPicks 
set TeamIdentifier = case TeamIdentifier
	when 'Washington Redskins' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Redskins'
	when 'Dallas Cowboys' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Cowboys'
	when 'New York Giants' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Giants'
	when 'Philadelphia Eagles' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Eagles'
	when 'Green Bay Packers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Packers'
	when 'Minnesota Vikings' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Vikings'
	when 'Detroit Lions' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Lions'
	when 'Chicago Bears' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Bears'
	when 'Tampa Bay Buccaneers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Buccaneers'
	when 'Atlanta Falcons' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Falcons'
	when 'New Orleans Saints' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Saints'
	when 'Carolina Panthers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Panthers'
	when 'Arizona Cardinals' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Cardinals'
	when 'Phoenix Cardinals' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Cardinals'
	when 'St Louis Cardinals' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Cardinals'
	when 'Los Angeles Rams' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Rams'
	when 'St Louis Rams' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Rams'
	when 'Seattle Seahawks' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Seahawks'
	when 'San Francisco 49ers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-49ers'
	when 'Boston Patriots' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Patriots'
	when 'New England Patriots' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Patriots'
	when 'Miami Dolphins' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Dolphins'
	when 'New York Jets' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Jets'
	when 'Buffalo Bills' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Bills'
	when 'Pittsburgh Steelers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Steelers'
	when 'Cleveland Browns' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Browns'
	when 'Baltimore Ravens' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Ravens'
	when 'Cincinnati Bengals' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Bengals'
	when 'Houston Texans' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Texans'
	when 'Houston Oilers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Titans'
	when 'Tennessee Oilers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Titans'
	when 'Tennessee Titans' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Titans'
	when 'Baltimore Colts' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Colts'
	when 'Indianapolis Colts' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Colts'
	when 'Jacksonville Jaguars' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Jaguars'
	when 'Denver Broncos' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Broncos'
	when 'San Diego Chargers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Chargers'
	when 'Los Angeles Chargers' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Chargers'
	when 'Los Angeles Raiders' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Raiders'
	when 'Oakland Raiders' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Raiders'
	when 'Las Vegas Raiders' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Raiders'
	when 'Kansas City Chiefs' then Replace(SeasonIdentifier,'NFL','') + '-NFL-Chiefs'
	else '' end 
from _ImportDraftPicks

update _ImportDraftPicks 
set PositionIdentifier = case PositionIdentifier
	when 'Center' then 'C'
	when 'Cornerback' then 'CB'
	when 'DB' then 'CB'
	when 'Defensive Back' then 'DB'
	when 'Defensive End' then 'DE'
	when 'Defensive Tackle' then 'DT'
	when 'FB' then 'RB'
	when 'Free Safety' then 'S'
	when 'FS' then 'S'
	when 'Fullback' then 'RB'
	when 'Guard' then 'G'
	when 'ILB' then 'LB'
	when 'Inside linebacker' then 'LB'
	when 'Kicker' then 'K'
	when 'KR/WR' then 'WR'
	when 'Linebacker' then 'LB'
	when 'LS' then 'LB'
	when 'Middle Guard' then 'LB'
	when 'Middle Line Backer' then 'LB'
	when 'Middle Linebacker' then 'LB'
	when 'Nose tackle' then 'DT'
	when 'NT' then 'DT'
	when 'Offensive Guard' then 'G'
	when 'Offensive lineman' then 'G'
	when 'Offensive Tackle' then 'T'
	when 'OLB' then 'LB'
	when 'OT' then 'T'
	when 'Outside linebacker' then 'LB'
	when 'Place Kicker' then 'K'
	when 'Place Kicker/Punter' then 'K'
	when 'Punter' then 'P'
	when 'Punter/Kicker' then 'P'
	when 'Quarterback' then 'QB'
	when 'Quarterback/Punter' then 'QB'
	when 'Running Back' then 'RB'
	when 'Safety' then 'S'
	when 'SS' then 'S'
	when 'Strong Safety' then 'S'
	when 'Tackle' then 'T'
	when 'Tight End' then 'TE'
	when 'Tight End/Linebacker' then 'TE'
	when 'Tightend' then 'TE'
	when 'WB' then 'WR'
	when 'Wide Receiver' then 'WR'
	else PositionIdentifier
	end

update _ImportDraftPicks set PositionIdentifier = 'Football-' + PositionIdentifier

insert into Sports.Drafts ( Id )
select distinct s.Id
from dbo._ImportDraftPicks dp
inner join Sports.Seasons s on dp.SeasonIdentifier = s.Identifier

insert into Sports.Players ( Id, CollegeId )
select distinct p.Id ,
	c.Id
from dbo._ImportDraftPicks dp
inner join dbo.People p on dp.PersonIdentifier = p.Identifier
left outer join dbo.Organizations o on dp.CollegeIdentifier = o.Identifier
left outer join Education.Colleges c on c.Id = o.Id
where p.Id not in (select id from Sports.Players)

declare @nflId int
select @nflId = Id from dbo.Organizations where Identifier = 'NFL' 

insert into Sports.PlayerLeagues ( PlayerId, LeagueId, PositionId )
select p.Id, @nflId, pos.Id
from dbo._ImportDraftPicks dp
inner join dbo.People p on p.Identifier = dp.PersonIdentifier
left outer join Sports.Positions pos on pos.Identifier = dp.PositionIdentifier
left outer join Sports.PlayerLeagues pl on pl.PlayerID = p.Id and pl.LeagueId = @nflId
where pl.Id is null


insert into Sports.DraftPicks ( DraftId, PersonId, TeamId, Round, Pick, CollegeId , PositionId )
select d.Id, p.Id, t.Id, dp.Round, dp.Pick, c.Id, pos.Id
from dbo._ImportDraftPicks dp
inner join dbo.People p on p.Identifier = dp.PersonIdentifier
inner join Sports.Teams t on t.Identifier = dp.TeamIdentifier
inner join Sports.Seasons s on dp.SeasonIdentifier = s.Identifier
inner join Sports.Drafts d on d.Id = s.Id
left outer join Sports.Positions pos on pos.Identifier = dp.PositionIdentifier
left outer join dbo.Organizations o on dp.CollegeIdentifier = o.Identifier
left outer join Education.Colleges c on c.Id = o.Id

insert into Sports.TeamPeople ( TeamId, PersonId, TeamRoleId )
select t.Id, 
	dp.PersonId, 
	8 -- player
from Sports.DraftPicks dp
inner join Sports.Teams t on dp.TeamId = t.Id
left outer join Sports.TeamPeople tp on tp.TeamId = t.Id and tp.PersonId = dp.PersonId and tp.TeamRoleId = 8
where tp.Id is null

insert into Sports.TeamPlayerPositions ( TeamPersonId, PositionId )
select tp.Id ,
	dp.PositionId
from Sports.DraftPicks dp
inner join Sports.Teams t on dp.TeamId = t.Id
inner join Sports.TeamPeople tp on tp.TeamId = t.Id and tp.PersonId = dp.PersonId and tp.TeamRoleId = 8
where dp.PositionId is not null







