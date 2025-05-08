namespace CargoCRM.Extensions;

public static class MinimalApisExtensions
{
    public static void MapAllMinimalApis(this WebApplication app)
    {
        app.MapServerAPIs();
    }
}