
select 
Convert(varchar(4), Year) + dbo.CleanName(b.BrandName) + l.Abbreviation + 
case 
	when SubsetName = 'Base Set' then 'Base' 
	when SubsetName = 'Base Set - Large' then 'Large'
	else dbo.CleanName(SubsetName) 
end as SetIdentifier ,
cc.CardNumber ,
IsNull(NumInstances, 0) as NumInstances ,
IsNull(AutoFlag, 0) as AutoFlag ,
IsNull(RelicFlag, 0) as RelicFlag ,
IsNull(RCFlag, 0) as RCFlag ,
case when lastname = 'Checklist' then 1 else 0 end as IsChecklist ,
case when lastname = 'Checklist' then null else dbo.CleanName(p.FirstName) + dbo.CleanName(p.LastName) end as PlayerIdentifier ,
convert(varchar(4),year) + l.Abbreviation + '-' + dbo.CleanName(t.TeamName) as TeamIdentifier
from cards cc
inner join sets s on cc.Set_Id = s.Set_Id
inner join Releases r on s.Release_Id = r.Release_Id
inner join Brands b on r.Brand_id = b.Brand_Id
inner join Leagues l on r.League_Id = l.League_Id
inner join Companys c on r.Company_Id = c.Company_Id
left outer join CardPlayers cp on cc.Card_Id = cp.Card_Id
left outer join Players p on cp.Player_Id = p.Player_Id
left outer join Teams t on cc.Team_Id = t.Team_Id
order by year, Abbreviation, c.CompanyName, BrandName, SubsetName, cc.CardNumber


select Convert(varchar(4), Year) as Year,
dbo.CleanName(c.CompanyName) as CompanyName,
dbo.CleanName(b.brandName) as BrandName ,
dbo.CleanName(SubsetName) as SetName ,
l.Abbreviation as League ,
case when p.Player_Id is not null then FirstName + ' ' + LastName else '' end as Player ,
case when cc.Team_Id is not null then t.TeamCity + ' ' + t.TeamName else '' end as Team ,
CardNumber
from cards cc
inner join sets s on cc.Set_Id = s.Set_Id
inner join Releases r on s.Release_Id = r.Release_Id
inner join Brands b on r.Brand_id = b.Brand_Id
inner join Leagues l on r.League_Id = l.League_Id
inner join Companys c on r.Company_Id = c.Company_Id
left outer join CardPlayers cp on cc.Card_Id = cp.Card_Id
left outer join Players p on cp.Player_Id = p.Player_Id
left outer join Teams t on cc.Team_Id = t.Team_Id
order by year, Abbreviation, c.CompanyName, BrandName, SetName, CardNumber



select * from players where lastname = 'checklist'

select * from cards
