

select 
Convert(varchar(4), Year) + 
dbo.CleanName(b.BrandName) + 
l.Abbreviation + 
case 
	when SubsetName = 'Base Set' then 'Base' 
	when SubsetName = 'Base Set - Large' then 'Large'
	else dbo.CleanName(SubsetName) 
end + 
'-' + 
Convert(varchar(10), cc.CardNumber) as CardIdentifier , 
ist.Description as InventoryStatus ,
t.Description as InventoryType ,
loc.Name as Location ,
i.SerialNumber ,
g.Name as GradingService,
i.GradingServiceReferenceNo
from inventory i
inner join cards cc on i.Card_Id = cc.Card_Id
inner join sets s on cc.Set_Id = s.Set_Id
inner join Releases r on s.Release_Id = r.Release_Id
inner join Brands b on r.Brand_id = b.Brand_Id
inner join Leagues l on r.League_Id = l.League_Id
inner join Companys c on r.Company_Id = c.Company_Id
inner join InventoryStatuses ist on i.InventoryStatus_Id = ist.InventoryStatus_Id
inner join InventoryTypes t on i.InventoryType_Id = t.InventoryType_Id
left outer join Locations loc on i.Location_Id = loc.Location_Id
left outer join GradingServices g on i.GradingService_Id = g.GradingService_Id
order by CardIdentifier