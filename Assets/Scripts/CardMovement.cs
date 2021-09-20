using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform defaultParent; //卡牌的父容器;

    public void OnBeginDrag(PointerEventData eventData)
    {    
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent,false); //先放到爷爷家那里，放的时候才可以放回原处
        //阻止鼠标pointerevent穿过Card prefab；
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {    
        transform.SetParent(defaultParent, false); //放回原处
        //允许鼠标pointerevent穿过Card prefab；为了判断鼠标位置到了哪个区域(transform)
        GetComponent<CanvasGroup>().blocksRaycasts = true; 
    }

    public void SetCardTransform(Transform parentTransform)
    {
        defaultParent = parentTransform;
        transform.SetParent(defaultParent);
    }
}
