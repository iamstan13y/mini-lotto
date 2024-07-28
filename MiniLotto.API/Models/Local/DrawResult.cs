namespace MiniLotto.API.Models.Local;

public class DrawResult
{
    public List<int> WinningNumbers { get; set; } = [];
    public List<string>? Winners { get; set; } = [];
}