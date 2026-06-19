using System.Collections.Generic;
using UnityEngine;

public static class HandChecker
{

    private static readonly int[] KokushiPais =
    {
        (int)PaiType.Man1,
        (int)PaiType.Man9,

        (int)PaiType.Pin1,
        (int)PaiType.Pin9,

        (int)PaiType.Sou1,
        (int)PaiType.Sou9,

        (int)PaiType.East,
        (int)PaiType.South,
        (int)PaiType.West,
        (int)PaiType.North,

        (int)PaiType.Haku,
        (int)PaiType.Hatu,
        (int)PaiType.Tyun
    };


    private static bool IsAgari(int[] counts)
    {
        return IsNormalAgari(counts)
            || IsChiitoitsu(counts)
            || IsKokushi(counts);
    }

    public static bool IsAgari(Hand hand)
    {
        if (hand.Count != 14)
            return false;

        return IsAgari(PaiCounter.Count(hand));
    }

    public static bool IsTenpai(Hand hand)
    {
        

        return GetWaitingPais(hand).Count > 0;
    }

    private static bool IsNormalAgari(int[] counts)
    {
        for (int i = 0; i < 34; i++)
        {
            // “ªŒó•â
            if (counts[i] >= 2)
            {
                counts[i] -= 2;

                if (RemoveMeld(counts))
                {
                    counts[i] += 2;
                    return true;
                }

                // –ß‚·
                counts[i] += 2;
            }
        }

        return false;
    }


    private static bool RemoveMeld(int[] counts)
    {
        // ˆê”Ô¶‚Ì”v‚ğ’T‚·
        int first = -1;

        for (int i = 0; i < 34; i++)
        {
            if (counts[i] > 0)
            {
                first = i;
                break;
            }
        }

        // ‘S•”Á‚¦‚½
        if (first == -1)
            return true;

        // q
        if (counts[first] >= 3)
        {
            counts[first] -= 3;

            if (RemoveMeld(counts))
            {
                counts[first] += 3;
                return true;
            }

            counts[first] += 3;
        }

        // ‡q
        if (CanSequence(first, counts))
        {
            counts[first]--;
            counts[first + 1]--;
            counts[first + 2]--;

            if (RemoveMeld(counts))
            {
                counts[first]++;
                counts[first + 1]++;
                counts[first + 2]++;
                return true;
            }

            counts[first]++;
            counts[first + 1]++;
            counts[first + 2]++;
        }

        return false;
    }

    private static bool CanSequence(int index, int[] counts)
    {
        // š”v
        if (index >= 27)
            return false;

        // 8,9‚©‚ç‡q‚Íì‚ê‚È‚¢
        if (index % 9 >= 7)
            return false;

        return counts[index] > 0 &&
               counts[index + 1] > 0 &&
               counts[index + 2] > 0;
    }

    // ‘Ò‚¿”v‚ğæ“¾‚·‚é
    public static List<PaiType> GetWaitingPais(Hand hand)
    {
        List<PaiType> waitingPais = new();

        // 13–‡‚¶‚á‚È‚¯‚ê‚Î‘Ò‚¿‚Í‘¶İ‚µ‚È‚¢
        if (hand.Count != 13)
            return waitingPais;

        int[] counts = PaiCounter.Count(hand);

        for (int i = 0; i < 34; i++)
        {
            // 4–‡‚Á‚Ä‚¢‚é”v‚Í‚à‚¤ˆø‚¯‚È‚¢
            if (counts[i] >= 4)
                continue;

            counts[i]++;

            if (IsAgari(counts))
            {
                waitingPais.Add((PaiType)i);
            }

            counts[i]--;
        }

        return waitingPais;
    }

    // µ‘Îq‚©‚Ç‚¤‚©
    private static bool IsChiitoitsu(int[] counts)
    {
        int pairCount = 0;

        for (int i = 0; i < 34; i++)
        {
            if (counts[i] == 2)
                pairCount++;

            else if (counts[i] != 0)
                return false;
        }

        return pairCount == 7;
    }

    // ‘m–³‘o‚©‚Ç‚¤‚©
    private static bool IsKokushi(int[] counts)
    {
        bool hasPair = false;

        foreach (int i in KokushiPais)
        {
            if (counts[i] == 0)
                return false;

            if (counts[i] >= 2)
                hasPair = true;
        }

        return hasPair;
    }
}