using UnityEngine;

public class Pai : MonoBehaviour
{
    [SerializeField] MeshRenderer faceRenderer;
    [SerializeField] PaiMaterialDatabase database;

    public PaiType paiType;
    public void SetSurface(PaiType type)
    {
        paiType = type;
        faceRenderer.material = database.GetMaterial(type);
    }
}
