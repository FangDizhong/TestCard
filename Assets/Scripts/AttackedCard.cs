using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 被攻击的卡牌
public class AttackedCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        /*攻击*/
        // 选择attacker卡牌(鼠标拖拽的卡牌)
        CardController attacker = eventData.pointerDrag.GetComponent<CardController>();
        // 选择defender卡牌(本身)
        CardController defender = GetComponent<CardController>();

        if (attacker == null || defender == null)
        {
           return; 
        }
        
        if (attacker.model.canAttack)
        {
            // attacker和defender打一架 (GameManager被public成instancele，所以这里可以引用)
            GameManager.instance.CardsBattle(attacker, defender);
        }
    }
}
