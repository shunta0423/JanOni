using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Pai tile;
    [SerializeField] private PaiMaterialDatabase database;

    private float timer = 0f;
    private int index = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer = 0f;

            PaiType type = (PaiType)index;
            tile.SetSurface(type);

            index++;

            if (index >= System.Enum.GetValues(typeof(PaiType)).Length)
            {
                index = 0;
            }
        }
    }
}