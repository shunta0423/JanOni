using System.Collections.Generic;

public class AgariResult
{
    public bool IsAgari;
    public bool IsTenpai;

    public int Han;
    public int Fu;

    public int Score;

    public List<Yaku> Yakus = new();
}