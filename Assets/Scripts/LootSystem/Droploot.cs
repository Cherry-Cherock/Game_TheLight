using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;

public class Droploot : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<ItemDefinition> lootList = new List<ItemDefinition>();

    ItemDefinition GetDroppedItem()
    {
        //1~100
        int randomNumber = Random.Range(1, 101);
        Debug.Log("随机数："+randomNumber);
        List<ItemDefinition> possibleItems = new List<ItemDefinition>();
        foreach (ItemDefinition item in lootList)
        {
            if (randomNumber <= item.DropChance)
            {
                possibleItems.Add(item);
            }
        }
        Debug.Log("数量大小："+possibleItems.Count);
        if (possibleItems.Count > 0)
        {
            ItemDefinition droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("没有掉落！");
        return null;
    }

    public void Instantiateloot(Vector3 spawnPosition)
    {
        ItemDefinition droppeedItem = GetDroppedItem();
        if (droppeedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<GameItem>().Stack.SetItem(droppeedItem);
            
            
        }
    }
 
}
