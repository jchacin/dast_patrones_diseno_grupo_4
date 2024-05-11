using System;

class Program
{
    static void Main(string[] args)
    {
        var geoJSONTarget = new GeoJSONTarget();
        var clientCompatible = new Client(geoJSONTarget);
        clientCompatible.RenderData();
        Console.WriteLine();

        var kmlLibrary = new KMLService();
        var adapter = new KMLAdapter(kmlLibrary, "100.0, 0.0");

        var clientAdapter = new Client(adapter);
        clientAdapter.RenderData();
    }
}