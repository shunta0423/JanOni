using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class HandButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

    [SerializeField]
    private Image image;

    private Player player;
    private int index;

    private Vector3 originalPos;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = transform.localPosition;
    }
    public void Set(Player player, int index, PaiType pai)
    {
        this.player = player;
        this.index = index;
        image.sprite = PaiDatabase.Instance.GetSprite(pai);
    }
    public void OnClick()
    {
        if (player != null && player.isDrawing)
        {
            transform.localPosition = originalPos;
            player.RemoveHand(index);
            player.isDrawing = false;
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (player.isDrawing)
        {
            transform.localPosition += Vector3.up * 20f;    
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (player.isDrawing)
        {
            transform.localPosition = originalPos;
        }
    }
}
