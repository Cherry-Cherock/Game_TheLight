using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;

public class Droploot : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<ItemDefinition> lootList = new List<ItemDefinition>();

    List<ItemDefinition> GetDroppedItem()
    {
        //1~100
        int randomNumber = Random.Range(1, 101);
        Debug.Log("Random number："+randomNumber);
        List<ItemDefinition> possibleItems = new List<ItemDefinition>();
        foreach (ItemDefinition item in lootList)
        {
            if (randomNumber <= item.DropChance)
            {
                possibleItems.Add(item);
            }
        }
        Debug.Log("Possible list size："+possibleItems.Count);
        if (possibleItems.Count > 0)
        { 
            List<ItemDefinition> resultItems = new List<ItemDefinition>();
            if (possibleItems.Count <= 3) return possibleItems;
            {
                for (int i = 0; i < 3; i++)
                {
                    ItemDefinition droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
                    resultItems.Add(droppedItem);
                }
            }
            return resultItems;
        }
        Debug.Log("No loot dropped!");
        return null;
    }

    public void Instantiateloot(Vector3 spawnPosition)
    {
        List<ItemDefinition> droppeedItem = GetDroppedItem();
        if (droppeedItem != null)
        {
            for (int i = 0; i<droppeedItem.Count; i++)
            {
                GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
                lootGameObject.GetComponent<GameItem>().Stack.SetItem(droppeedItem[i]);
                //抛出抛物线
                lootGameObject.GetComponent<Rigidbody>().useGravity = true;
                var dropForce = Random.Range(3+i, 5+i);
                lootGameObject.GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sign(transform.localScale.x) * dropForce, 5+i);
                StartCoroutine(DisableGravity(lootGameObject.GetComponent<Rigidbody>(),7+i));
            }
        }
    }
    
    private IEnumerator DisableGravity(Rigidbody rb, float velocity)
    {
        yield return new WaitUntil(() => rb.velocity.y < -velocity);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
    }
 
}
