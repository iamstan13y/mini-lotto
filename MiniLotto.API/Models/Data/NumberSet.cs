namespace MiniLotto.API.Models.Data;

public class NumberSet
{
    public int Id { get; set; }
    public List<int> Numbers { get; set; } = [];
    public int PlayerId { get; set; }
    public Player Player { get; set; }
}