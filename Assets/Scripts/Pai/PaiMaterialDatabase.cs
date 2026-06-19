using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaiMaterialDatabase : MonoBehaviour
{
    public static PaiMaterialDatabase Instance { get; private set; }

    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private Sprite[] Imgs = new Sprite[37];

    [SerializeField]
    private Dictionary<PaiType, Sprite> PaiImgDictionary = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;


        foreach(PaiType type in System.Enum.GetValues(typeof(PaiType)))
        {
            PaiImgDictionary.Add(type, Imgs[(int)type]);
        }
    }

    public Material GetMaterial(PaiType type)
    {
        return materials[(int)type];
    }

    public Sprite GetSprite(PaiType type)
    {
        if (PaiImgDictionary.TryGetValue(type, out Sprite sprite))
        {
            return sprite;
        }
        else
        {
            Debug.LogWarning($"Sprite for PaiType {type} not found.");
            return null;
        }
    }
}