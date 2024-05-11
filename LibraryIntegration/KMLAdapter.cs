using System;

public class KMLAdapter : IGeoJSON
{
    private KMLService kmlService;
    private string coordinates;

    public KMLAdapter(KMLService kmlService, string coordinates)
    {
        this.kmlService = kmlService;
        this.coordinates = coordinates;
    }

    public string DisplayGeoJSON()
    {
        Console.WriteLine("Adapter: Convirtiendo datos GeoJSON a KML...");
 
        string kmlData = $"<Placemark><Point><coordinates>{coordinates}</coordinates></Point></Placemark>";
        kmlService.DisplayKML(kmlData);

        return "Adapter: Displaying GeoJSON data (adapted to KML).";
    }
}