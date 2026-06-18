using UnityEngine;

public class HandView : MonoBehaviour
{
    [SerializeField]
    private MahjongTile tilePrefab;

    [SerializeField]
    private float spacing = 0.25f;

    [SerializeField]
    private float radius = 2.0f;

    [SerializeField]
    private float totalAngle = 40f;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (cam == null)
            return;

        //transform.forward = cam.transform.forward;
    }
    public void UpdateView(Hand hand)
    {
        // å√Ç¢îvÇçÌèú
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        hand.Sort();
        int count = hand.Tiles.Count;

        for (int i = 0; i < count; i++)
        {
            MahjongTile tile = Instantiate(tilePrefab, transform);

            // éËîvÇÃéÌóﬁÇê›íË
            tile.SetTile(hand.Tiles[i]);

            // êÓå`ÇÃäpìx
            float angle = (count == 1)
                ? 0f
                : Mathf.Lerp(-totalAngle / 2f, totalAngle / 2f, (float)i / (count - 1));

            float arcLength = spacing * (i - (count - 1) / 2f);
            float rad = arcLength / radius;

            Vector3 pos = new Vector3(
                Mathf.Sin(rad) * radius,
                0f,
                Mathf.Cos(rad) * radius - radius
            );

            tile.transform.localPosition = pos;
            tile.transform.localRotation = Quaternion.Euler(0f, rad * Mathf.Rad2Deg, 0f);

            
        }
    }
}
