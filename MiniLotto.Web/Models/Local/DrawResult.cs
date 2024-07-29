namespace MiniLotto.Web.Models.Local;

public class DrawResult
{
    public List<int> WinningNumbers { get; set; } = [];
    public List<WinnerDetail>? Winners { get; set; } = [];
}