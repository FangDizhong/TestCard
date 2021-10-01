using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadExcel : MonoBehaviour
{
    public Item blankItem;
    public List<Item> itemDatabase = new List<Item>();

    public void LoadItemData()
    {
        // Clear database
        itemDatabase.Clear();

        // READ CSV files
        List<Dictionary<string, object>> data = CSVReader.Read("ItemDatabase");
        for (var i = 0; i < data.Count; i++)
        {
            string name = data[i]["name"].ToString();
            int hp = int.Parse(data[i]["hp"].ToString(), System.Globalization.NumberStyles.Integer);
            int at = int.Parse(data[i]["at"].ToString(), System.Globalization.NumberStyles.Integer);
            int cost = int.Parse(data[i]["cost"].ToString(), System.Globalization.NumberStyles.Integer);
            Sprite icon = Resources.Load<Sprite>(data[i]["icon"].ToString());

            AddItem(name, hp, at, cost, icon);
        } 
    }

    void AddItem(string name, int hp, int at, int cost, Sprite icon)
    {
        Item tempItem = new Item(blankItem);

        tempItem.name = name;
        tempItem.hp = hp;
        tempItem.at = at;
        tempItem.cost = cost;
        tempItem.icon = icon;

        itemDatabase.Add(tempItem);
    }
}
