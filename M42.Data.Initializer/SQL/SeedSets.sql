create table _ImportReleaseSets
(
	SetIdentifier varchar(max) ,
	ReleaseIdentifier varchar(max) ,
	Name varchar(max) ,
	IsBase bit
)

bulk insert dbo._ImportReleaseSets 
from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\SportsCards\Sets.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

insert into SportsCards.Sets (ReleaseId, Name, IsBase, NumCards, Identifier) 
select r.Id ,
	rs.Name ,
	rs.IsBase ,
	case when rs.IsBase = 1 then r.BaseNumCards else 0 end ,
	rs.SetIdentifier
from _ImportReleaseSets rs
inner join SportsCards.Releases r on rs.ReleaseIdentifier = r.Identifier


