namespace CQRS.Domain.Entities.Setup;

public class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public string CountryNameBN { get; set; }
    public string CountryShortCode { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }
}
