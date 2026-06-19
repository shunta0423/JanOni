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
            for (int i = 0; i < 13; i++)
            {
                int n = Random.Range(0, 37);
                player.PlusHand((PaiType)(n));
            }
            num++;
            player.RefreshHand();
        }

        
        
        
    }

    private void Update()
    {
        
    }
}