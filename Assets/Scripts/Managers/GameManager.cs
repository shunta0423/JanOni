using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    public  Player[] players;

    private void Start()
    {
        int num = 0;
        foreach (Player player in players)
        {
            //for (int i = 0; i < 13; i++)
            //{
            //    int n = Random.Range(0, 34);
            //    player.PlusHand((PaiType)(n));
            //}
            //num++;

            player.PlusHand(PaiType.Man1);
            player.PlusHand(PaiType.Man9);
            player.PlusHand(PaiType.Pin1);
            player.PlusHand(PaiType.Pin9);
            player.PlusHand(PaiType.Sou1);
            player.PlusHand(PaiType.Sou9);
            player.PlusHand(PaiType.East);
            player.PlusHand(PaiType.South);
            player.PlusHand(PaiType.West);
            player.PlusHand(PaiType.North);
            player.PlusHand(PaiType.Haku);
            player.PlusHand(PaiType.Hatu);
            player.PlusHand(PaiType.Tyun);


            player.RefreshHand();
            MahjongDebugger.PrintHand(player.Hand);
        }

        
        
        
    }

    private void Update()
    {
        
    }
}