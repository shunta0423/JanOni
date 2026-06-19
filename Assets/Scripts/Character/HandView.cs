using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]//éËîvópÉ{É^Éì
    private HandButton[] HandsButton = new HandButton[14];


    [SerializeField] private Image background;

    [SerializeField]
    private Color normalColor =
        new Color(0, 0, 0, 0.80f);

    [SerializeField]
    private Color tenpaiColor =
        new Color(1f, 1f, 0f, 0.80f);

    [SerializeField]
    private Color agariColor =
        new Color(1f, 0.84f, 0f, 0.80f);
    private Coroutine glowCoroutine;


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
    //public void UpdateView(Hand hand)
    //{
        //// å√Ç¢îvÇçÌèú
        //foreach (Transform child in transform)
        //{
        //    Destroy(child.gameObject);
        //}

        //hand.Sort();
        //int count = hand.Tiles.Count;

        //for (int i = 0; i < count; i++)
        //{
            //MahjongTile tile = Instantiate(tilePrefab, transform);

            //// éËîvÇÃéÌóﬁÇê›íË
            //tile.SetTile(hand.Tiles[i]);

            //// êÓå`ÇÃäpìx
            //float angle = (count == 1)
            //    ? 0f
            //    : Mathf.Lerp(-totalAngle / 2f, totalAngle / 2f, (float)i / (count - 1));

            //float arcLength = spacing * (i - (count - 1) / 2f);
            //float rad = arcLength / radius;

            //Vector3 pos = new Vector3(
            //    Mathf.Sin(rad) * radius,
            //    0f,
            //    Mathf.Cos(rad) * radius - radius
            //);

            //tile.transform.localPosition = pos;
            //tile.transform.localRotation = Quaternion.Euler(0f, rad * Mathf.Rad2Deg, 0f);

            
        //}
    //}


    public void UpdateHands(Player player)
    {
        for (int i = 0; i < HandsButton.Length; i++)
        {
            if (i < player.Hand.Tiles.Count)
            {
                HandsButton[i].gameObject.SetActive(true);
                HandsButton[i].Set(
                    player,
                    i,
                    player.Hand.Tiles[i]
                );
            }
            else
            {
                HandsButton[i].gameObject.SetActive(false);
            }
        }
    }


    public void SetState(HandState state)
    {
        if (glowCoroutine != null)
        {
            StopCoroutine(glowCoroutine);
            glowCoroutine = null;
        }

        switch (state)
        {
            case HandState.Normal:

                background.color = normalColor;
                break;

            case HandState.Tenpai:

                background.color = tenpaiColor;
                break;

            case HandState.Agari:

                glowCoroutine = StartCoroutine(AgariGlow());
                break;
        }
    }

    private IEnumerator AgariGlow()
    {
        while (true)
        {
            background.color = agariColor;

            yield return new WaitForSeconds(0.35f);

            Color c = agariColor;
            c.a = 0.2f;

            background.color = c;

            yield return new WaitForSeconds(0.35f);
        }
    }


}
