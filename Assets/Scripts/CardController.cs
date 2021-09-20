using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view;// 接收关于看得到的(view)的操作
    public CardModel model;// 接收关于数据(model)的操作
    public CardMovement movement; //接收关于移动(movement)的操作

    private void Awake() 
    {
        view = GetComponent<CardView>(); //拿到挂载script的组件;
        movement = GetComponent<CardMovement>(); //拿到挂载script的组件;
    }

    //init的时候拿到卡牌号的对应数据model，传给view展示出来
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }

    public void Attack(CardController enemyCard)
    {
        model.Attack(enemyCard);
        SetCanAttack(false);
    }

    public void SetCanAttack(bool canAttack)
    {
        model.canAttack = canAttack;
        view.SetActiveSelectablePanel(canAttack);
    }

    public void CheckAlive()
    {
        if(model.isAlive)
        {
            view.Refresh(model);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
