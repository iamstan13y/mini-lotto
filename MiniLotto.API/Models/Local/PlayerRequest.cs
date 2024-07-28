namespace MiniLotto.API.Models.Local;

public class PlayerRequest
{
    public string Name { get; set; }
    public List<int> Numbers { get; set; }
}