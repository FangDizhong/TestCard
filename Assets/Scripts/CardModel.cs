using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 卡牌数据本身和处理
public class CardModel
{
    public string name;
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;
    public bool isAlive;
    public bool canAttack;

    public CardModel(int cardID)
    {
        // 把CardEntityList/Card1里的数值传进来
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);
        name = cardEntity.name;
        hp = cardEntity.hp;
        at = cardEntity.at;
        cost = cardEntity.cost;
        icon = cardEntity.icon;
        isAlive = true;
    }

    void Damage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            isAlive = false;
        }
    }
    public void Attack(CardController card)
    {
        card.model.Damage(at);
    }
}
