using UnityEngine;

public class PaiMaterialDatabase : MonoBehaviour
{
    public static PaiMaterialDatabase Instance { get; private set; }

    [SerializeField]
    private Material[] materials;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public Material GetMaterial(PaiType type)
    {
        return materials[(int)type];
    }
}