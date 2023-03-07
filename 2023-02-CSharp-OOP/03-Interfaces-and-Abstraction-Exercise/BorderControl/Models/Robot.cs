namespace BorderControl.Models;

public class Robot : IIdentification
{
    private string id;
    private string model;

    public Robot(string id, string model)
    {
        Id = id;
        Model = model;
    }

    public string Id
    {
        get => id;
        set => id = value;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }
}