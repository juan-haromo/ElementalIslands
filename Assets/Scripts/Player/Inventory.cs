using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<int, int> items;

    void Awake()
    {
        items = new Dictionary<int, int>();
    }

    public void AddResource(int resourceID, int amount)
    {
        if (!items.ContainsKey(resourceID))
        {
            items.Add(resourceID, amount);
        }
        else
        {
            items[resourceID] += amount;
        }
        Debug.Log(gameObject + " now owns " + items[resourceID] + " of  item id #" + resourceID);
    }
}