using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrainTicketsWebApp.Database.Collections;
public class TripOccupation
{
    [BsonId, BsonElement("tripId")]
    public string TripId { get; set; }

    [BsonElement("matrix")]
    public bool[,] OccupationMatrix { get; set; }
    public TripOccupation(string tripId, int segmentsQty, int placesAvailable)
    {
        OccupationMatrix = new bool[segmentsQty, placesAvailable];
        TripId = tripId;
    }
}
