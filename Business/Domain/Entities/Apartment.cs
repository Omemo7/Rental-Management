
namespace RentalManagement.Business.Domain.Entities;

public sealed class Apartment
{
    public Guid Id { get; private set; }
    public Guid BuildingId { get; private set; }   // the building it belongs to
    public Guid LandlordId { get; private set; }   // owner of this unit
    public string UnitNumber { get; private set; } // e.g. "3B"
    public int Bedrooms { get; private set; }
    public int Bathrooms { get; private set; }
    public decimal AreaSqm { get; private set; }

    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Apartment() { } // EF

    public Apartment(Guid id, Guid buildingId, Guid landlordId, string unitNumber, int bedrooms, int bathrooms, decimal areaSqm)
    {
        if (id == Guid.Empty || buildingId == Guid.Empty || landlordId == Guid.Empty)
            throw new ArgumentException("Ids required.");
        if (string.IsNullOrWhiteSpace(unitNumber)) throw new ArgumentException("Unit number required.", nameof(unitNumber));
        if (bedrooms < 0 || bathrooms < 0) throw new ArgumentOutOfRangeException("Negative rooms not allowed.");
        if (areaSqm <= 0) throw new ArgumentOutOfRangeException(nameof(areaSqm), "Area must be positive.");

        Id = id;
        BuildingId = buildingId;
        LandlordId = landlordId;
        UnitNumber = unitNumber.Trim().ToUpperInvariant();
        Bedrooms = bedrooms;
        Bathrooms = bathrooms;
        AreaSqm = areaSqm;
    }

    public void ChangeBuilding(Guid newBuildingId)
    {
        if (newBuildingId == Guid.Empty) throw new ArgumentException("Building ID required.", nameof(newBuildingId));
        BuildingId = newBuildingId;
    }

    public void ChangeSpecs(int bedrooms, int bathrooms, decimal areaSqm)
    {
        if (bedrooms < 0 || bathrooms < 0) throw new ArgumentOutOfRangeException();
        if (areaSqm <= 0) throw new ArgumentOutOfRangeException(nameof(areaSqm));
        Bedrooms = bedrooms;
        Bathrooms = bathrooms;
        AreaSqm = areaSqm;
    }

    public void RenameUnit(string newUnitNumber)
    {
        if (string.IsNullOrWhiteSpace(newUnitNumber)) throw new ArgumentException("Unit number required.", nameof(newUnitNumber));
        UnitNumber = newUnitNumber.Trim().ToUpperInvariant();
    }

 
}
