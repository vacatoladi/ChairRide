using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerScripts player; // referência ao script do player

    public void OnPointerDown(PointerEventData eventData)
    {
        player.isTouching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.isTouching = false;
    }

    public void FindPlayer()
    {
        GameObject pl = GameObject.Find("Player");
        if(pl != null)
        {
            player = pl.GetComponent<PlayerScripts>();
        }
    }
}
