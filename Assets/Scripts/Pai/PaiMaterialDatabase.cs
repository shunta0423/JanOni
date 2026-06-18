using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PaiMaterialData
{
    public PaiType type;
    public Material material;
}
public class PaiMaterialDatabase : MonoBehaviour
{
    public List<PaiMaterialData> materials;
    private Dictionary<PaiType, Material> materialDictionary;

    private void Awake()
    {
        materialDictionary = new Dictionary<PaiType, Material>();

        foreach (var data in materials)
        {
            materialDictionary[data.type] = data.material;
        }
    }

    public Material GetMaterial(PaiType type)
    {
        return materialDictionary[type];
    }
}