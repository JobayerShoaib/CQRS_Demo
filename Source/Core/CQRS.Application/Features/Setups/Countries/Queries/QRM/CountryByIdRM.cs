namespace CQRS.Application.Features.Setups.Countries.Queries.QRM;

public sealed class CountryByIdRM
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public string CountryNameBN { get; set; }
    public string CountryShortCode { get; set; }
}
