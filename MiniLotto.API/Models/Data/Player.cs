namespace MiniLotto.API.Models.Data;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Numbers { get; set; } = [];
}