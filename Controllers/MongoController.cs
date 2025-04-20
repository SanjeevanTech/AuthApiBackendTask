using MongoDB.Driver;

namespace _.Controllers;

public static class MongoController
{
    public static async Task<IResult> TestMongoConnection(IMongoDatabase db)
    {
        var collections = await db.ListCollectionNamesAsync();
        var collectionNames = await collections.ToListAsync();
        return Results.Ok(new { Status = "Connected", Collections = collectionNames });
    }
}
