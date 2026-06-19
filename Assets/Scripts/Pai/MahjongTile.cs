using UnityEngine;

public class MahjongTile : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    public void SetTile(PaiType type)
    {
        meshRenderer.material =
            PaiMaterialDatabase.Instance.GetMaterial(type);
    }

    
}
