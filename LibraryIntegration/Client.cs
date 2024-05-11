public class Client
{
    private IGeoJSON target;

    public Client(IGeoJSON target)
    {
        this.target = target;
    }

    public void RenderData()
    {
        Console.WriteLine(target.DisplayGeoJSON());
    }
}