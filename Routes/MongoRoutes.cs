using Microsoft.AspNetCore.Routing;
using MongoDB.Driver;

using _.Controllers;
namespace _.Routes;

public static class MongoRoutes
{
    public static void MapMongoRoutes(this IEndpointRouteBuilder app)
    {
        var mongoGroup = app.MapGroup("/api/mongodb");
        mongoGroup.MapGet("/test", MongoController.TestMongoConnection);

    }
}
