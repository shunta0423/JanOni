using System.Collections.Generic;
using UnityEngine;

public static class MahjongDebugger
{
    public static void PrintHand(Hand hand)
    {
        Debug.Log("========== è”v ==========");

        // è”v•\¦
        string handString = "";

        foreach (PaiType pai in hand.Tiles)
        {
            handString += pai + " ";
        }

        Debug.Log(handString);

        // ˜a—¹E’®”v
        Debug.Log($"˜a—¹ : {HandChecker.IsAgari(hand)}");
        Debug.Log($"’®”v : {HandChecker.IsTenpai(hand)}");

        // ‘Ò‚¿”v
        List<PaiType> waits = HandChecker.GetWaitingPais(hand);

        if (waits.Count == 0)
        {
            Debug.Log("‘Ò‚¿”v : ‚È‚µ");
        }
        else
        {
            string waitString = "";

            foreach (PaiType pai in waits)
            {
                waitString += pai + " ";
            }

            Debug.Log("‘Ò‚¿”v : " + waitString);
        }

        Debug.Log("==========================");
    }
}