using UnityEngine;

public class MahjongTest : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void Start()
    {
        Debug.Log("˜a—¹F" + HandChecker.IsAgari(player.Hand));
        Debug.Log("’®”vF" + HandChecker.IsTenpai(player.Hand));

        foreach (PaiType pai in HandChecker.GetWaitingPais(player.Hand))
        {
            Debug.Log("‘Ò‚¿F" + pai);
        }
    }
}