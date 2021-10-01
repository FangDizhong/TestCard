using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;

    public Item(Item d)
    {
        name = d.name;
        hp = d.hp;
        at = d.at;
        cost = d.cost;
        icon = d.icon;
    }
}
