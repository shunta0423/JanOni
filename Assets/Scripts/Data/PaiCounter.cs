public static class PaiCounter
{
    public static int[] Count(Hand hand)
    {
        int[] counts = new int[34];

        foreach (PaiType pai in hand.Tiles)
        {
            counts[(int)pai]++;
        }

        return counts;
    }
}