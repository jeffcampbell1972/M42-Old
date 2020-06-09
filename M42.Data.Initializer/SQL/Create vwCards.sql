

alter FUNCTION [dbo].[fnBuildCardAttributes]
(
	@isRookieCard bit,
	@isSinglePrint bit,
	@IsVariation bit,
	@hasAutograph bit,
	@hasRelic bit ,
	@numInstances bit 
)
RETURNS varchar(max)
AS
BEGIN

	declare @rtn varchar(max)

	set @rtn = ''

	if (@isRookieCard > 0) begin
		set @rtn = @rtn + 'RC'
	end
	if (@isSinglePrint > 0) begin
		if @rtn != '' set @rtn = @rtn + ' / '
		set @rtn = @rtn + 'SP'
	end
	if (@hasAutograph > 0) begin
		if @rtn != '' set @rtn = @rtn + ' / '
		set @rtn = @rtn + 'AU'
	end
	if (@hasRelic > 0) begin
		if @rtn != '' set @rtn = @rtn + ' / '
		set @rtn = @rtn + 'Relic'
	end
	if (@IsVariation > 0) begin
		if @rtn != '' set @rtn = @rtn + ' '
		set @rtn = @rtn + '(Variation)'
	end

	RETURN @rtn
END

go

alter view vwCards as 

select r.Year ,
	o.Name as Manufacturer ,
	b.Name as Brand ,
	l.Abbreviation as League ,
	s.Name ,
	p.FirstName + ' ' + p.LastName as Player ,
	t.City  + ' ' + t.Name as Team ,
	c.CardNumber ,
	dbo.fnBuildCardAttributes(c.IsRookieCard, c.IsSinglePrint, c.IsVariation, c.HasAutograph, c.HasRelic, c.NumInstances) as Attributes ,
	f.Id as FranchiseId
from SportsCards.Cards c
inner join Sports.Teams t on c.TeamId = t.Id
inner join Sports.Franchises f on t.FranchiseId = f.Id
inner join SportsCards.Sets s on c.SetId = s.Id
inner join SportsCards.Releases r on s.ReleaseId = r.Id
inner join Sports.Leagues l on r.LeagueId = l.Id
inner join SportsCards.Brands b on r.BrandId = b.Id
inner join SportsCards.Manufacturers m on r.ManufacturerId = m.Id
inner join dbo.Organizations o on m.Id = o.Id
left outer join SportsCards.CardPeople cp on cp.CardId = c.Id
left outer join dbo.People p on cp.PersonId = p.Id
go

alter view vwInventories as 

select r.Year ,
	o.Name as Manufacturer ,
	b.Name as Brand ,
	l.Abbreviation as League ,
	s.Name ,
	p.FirstName + ' ' + p.LastName as Player ,
	t.City  + ' ' + t.Name as Team ,
	c.CardNumber ,
	dbo.fnBuildCardAttributes(c.IsRookieCard, c.IsSinglePrint, c.IsVariation, c.HasAutograph, c.HasRelic, c.NumInstances) as Attributes ,
	f.Id as FranchiseId
from SportsCards.Inventories i
inner join SportsCards.Cards c on i.CardId = c.Id
inner join Sports.Teams t on c.TeamId = t.Id
inner join Sports.Franchises f on t.FranchiseId = f.Id
inner join SportsCards.Sets s on c.SetId = s.Id
inner join SportsCards.Releases r on s.ReleaseId = r.Id
inner join Sports.Leagues l on r.LeagueId = l.Id
inner join SportsCards.Brands b on r.BrandId = b.Id
inner join SportsCards.Manufacturers m on r.ManufacturerId = m.Id
inner join dbo.Organizations o on m.Id = o.Id
left outer join SportsCards.CardPeople cp on cp.CardId = c.Id
left outer join dbo.People p on cp.PersonId = p.Id
go


select *
from vwInventories
where FranchiseId = 201

