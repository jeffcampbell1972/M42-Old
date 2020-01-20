
create table _ImportCards
(
	SetIdentifier varchar(max) ,
	CardNumber int ,
	NumInstances int ,
	AutoFlag  int ,
	RelicFlag int ,
	RCFlag int ,
	IsChecklist int ,
	PlayerIdentifier varchar(max) ,
	TeamIdentifier varchar(max) ,
	CardType varchar(max)
)

bulk insert dbo._ImportCards 
from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\SportsCards\Cards.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

update _ImportCards
set CardType = 'Regular'
where CardType is null or CardType = ''

insert into SportsCards.Cards (SetId, Identifier, CardNumber, IsRookieCard,HasAutograph, HasRelic, NumInstances, CardTypeId, TeamId)
select s.Id as Set_Id ,
	s.Identifier + '-' + convert(varchar(5),CardNumber) ,
	c.CardNumber ,
	c.RCFlag as IsRookieCard ,
	c.AutoFlag as HasAutograph ,
	c.RelicFlag as HasRelic ,
	c.NumInstances as NumInstances ,
	t.Id as CardTypeId  ,
	team.Id as TeamId
from _ImportCards c
inner join SportsCards.Sets s on c.SetIdentifier = s.Identifier
inner join SportsCards.CardTypes t on c.CardType = t.Identifier
left outer join Sports.Teams team on c.TeamIdentifier = team.Identifier


insert into SportsCards.CardPeople (CardId, PersonId, TeamId)
select cc.Id as CardId ,
	p.Id as PersonId ,
	cc.TeamId
from _ImportCards c
inner join People p on p.Identifier = c.PlayerIdentifier
inner join SportsCards.Sets s on c.SetIdentifier = s.Identifier
inner join SportsCards.Cards cc on cc.SetId = s.Id and cc.CardNumber = c.CardNumber


