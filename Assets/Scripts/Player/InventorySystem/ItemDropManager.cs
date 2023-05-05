using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEditor;
using UnityEngine;

namespace Player.InventorySystem
{
    public class ItemDropManager : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _itemBasePrefeb;
    
        public void SpawnItem(ItemStack itemStack)
        {
            if (_itemBasePrefeb == null) return;
            var item = PrefabUtility.InstantiatePrefab(_itemBasePrefeb) as GameObject;
            item.transform.position = transform.position;
            var gameItemScript = item.GetComponent<GameItem>();
            gameItemScript.SetStack(new ItemStack(itemStack.Item, itemStack.NumberOfItems));
            gameItemScript.DropItem(transform.localScale.x);
        }
    }
}

