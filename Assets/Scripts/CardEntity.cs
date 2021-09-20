using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//在Unity界面生成[create CardEntity]的menu
[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

// 卡牌数据本身
public class CardEntity : ScriptableObject {
    public new string name;
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;


}
