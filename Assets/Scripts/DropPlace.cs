using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
   public void OnDrop(PointerEventData eventData)
   {
    //    放置时，卡牌和区域(transform)重叠的时候，宣称自己是父容器
       CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
       if (card != null)
       {
           card.defaultParent = this.transform;
       }
   }
}
