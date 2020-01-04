
create table dbo._ImportInventory
(
	CardIdentifier varchar(max),
	InventoryStatus varchar(max),
	InventoryType varchar(max),
	ContainerIdentifier varchar(max),
	SerialNumber varchar(max),
	GradingService varchar(max),
	GradingServiceReferenceNo varchar(max)
)
--

bulk insert dbo._ImportInventory 
from 'C:\Users\jeffc\source\repos\M42\M42.Data.Initializer\InitFiles\SportsCards\Inventory.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

update dbo._ImportInventory set ContainerIdentifier = 'NFL Commons' where ContainerIdentifier = null or ContainerIdentifier = ''

insert into SportsCards.Inventories (CardId, SerialNumber, GradingService, GradingServiceReferenceNo, ContainerId, InStock)
select c.Id ,
	i.SerialNumber ,
	i.GradingService ,
	i.GradingServiceReferenceNo ,
	l.Id ,
	1
from SportsCards.Cards c
inner join _ImportInventory i on c.Identifier = i.CardIdentifier
inner join SportsCards.Containers l on i.ContainerIdentifier = l.Identifier
where i.InventoryType = 'Single'
and i.InventoryStatus = 'In Stock'

