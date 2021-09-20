using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 往手牌区生成卡牌

    [SerializeField] Transform playerHandTransform,
                                playerFieldTransform,
                                enemyHandTransform,
                                enemyFieldTransform;
    [SerializeField] CardController cardPrefab; //定义为CardController类型

    bool isPlayerTurn;

    List<int> playerDeck = new List<int>() {3,1,2,2,3};
    List<int> enemyDeck  = new List<int>() {2,1,3,1,3};

    // 变成Singleton (从哪都可以访问)
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        SettingInitHand();
        isPlayerTurn = true;
        TurnCalc();
    }

    void SettingInitHand()
    {
        // 给各自发3张卡牌
        for (int i=0; i<3; i++)
        {
            GiveCardToHand(playerDeck, playerHandTransform);
            GiveCardToHand(enemyDeck, enemyHandTransform);
        }
    }
    void GiveCardToHand(List<int> deck, Transform hand)
    {
        if(deck.Count == 0)
        {
            return;
        }
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard(cardID, hand);
    }

    // 创造手牌 (谁的手牌)
    void CreateCard(int cardID, Transform hand)
    {
                            // 实例化    卡牌       在手牌处
       CardController card = Instantiate(cardPrefab, hand, false);
       card.Init(cardID); // 获取CardID 1  的数据
    }

    void TurnCalc()
    {
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    // Public 之后就可以给UI获取了
    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            GiveCardToHand(playerDeck, playerHandTransform);            
        }
        else
        {
            GiveCardToHand(enemyDeck, enemyHandTransform);            
        }

        TurnCalc();
    }

    void PlayerTurn()
    {
        Debug.Log("Player turn");
        // Field Card变可攻击状态
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        foreach (CardController card in playerFieldCardList)
        {
            // 把卡牌变成可攻击
            card.SetCanAttack(true);
        }

    }

    void EnemyTurn()
    {
        Debug.Log("Enemy turn");
        // Field Card变可攻击状态


        /*出牌到区域*/
        // 取得手牌list
        CardController[] handCardList = enemyHandTransform.GetComponentsInChildren<CardController>();
        // 选择卡牌
        CardController enemyCard = handCardList[0];
        // 出牌
        enemyCard.movement.SetCardTransform(enemyFieldTransform);

        /*攻击*/
        // 获取战区卡牌list
        CardController[] enemyFieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        // 获取我区卡牌list
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        // 用Systems里的Array.FindAll()方法，取得能攻击的卡牌     在敌区             的卡牌     找到能攻击的所有卡牌     
        CardController[] enemyCanAttackCardList = Array.FindAll(enemyFieldCardList, card => card.model.canAttack);

        if (enemyCanAttackCardList.Length > 0 && playerFieldCardList.Length > 0)
        {
            // 选择attacker卡牌
            CardController attacker = enemyFieldCardList[0];
            // 选择defender卡牌
            CardController defender = playerFieldCardList[0];
            // attacker和defender打一架
            CardsBattle(attacker, defender);
        }
       

        ChangeTurn();
    }

    public void CardsBattle(CardController attacker, CardController defender)
    {
        Debug.Log("CardBattle");
        attacker.Attack(defender);
        defender.Attack(attacker);
        attacker.CheckAlive();
        defender.CheckAlive();
        
    }

}
