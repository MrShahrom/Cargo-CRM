namespace CargoCRM.DTOs.TrackCodeDTOs;

public record TrackCodeDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int Id_customer { get; init; }
}