using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Player.InventorySystem
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField] 
        private ItemStack _stack;

   
        [SerializeField] 
        private SpriteRenderer _spriteRenderer;

        private Collider _collider;
        public ItemStack Stack => _stack;

        //-----drop item------------
        [SerializeField] 
        private float _colliderEnableAfter = 10f;
        [SerializeField]
        private float _dropGravity = 2f;
        [SerializeField]
        private float _dropMinForce =3f;
        [SerializeField]
        private float _dropMaxForce =5f;
        [SerializeField]
        private float _dropForce = 5f;
        private float _dropItem;
        private Rigidbody _rb;
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rb = GetComponent<Rigidbody>();
            _collider.enabled = false;
        }

        private void Start()
        {
            SetupGameObject();
            StartCoroutine(EnableCollider(_colliderEnableAfter));
        }

        private void OnValidate()
        {
            SetupGameObject();
        }

        private void SetupGameObject()
        {
            if(_stack.Item == null) return;
            SetGameSprite();
            UpdateItemName();
            AdjustNumberOfItem();
        }

        private void SetGameSprite()
        {
            _spriteRenderer.sprite = _stack.Item.InGameSprite;
        }

        private void UpdateItemName()
        {
            var name = _stack.Item.Name;
            var number = _stack.IsStackable ? _stack.NumberOfItems.ToString() : "ns";
            gameObject.name = $"{name} ({number})";
        }

        private void AdjustNumberOfItem()
        {
            _stack.NumberOfItems = _stack.NumberOfItems;
        }

        public ItemStack Pick()
        {
            Destroy(gameObject);
            return _stack;
        }

        public void DropItem(float xDir)
        {
            _rb.useGravity = true;
            var dropForce = Random.Range(_dropMinForce, _dropMaxForce);
            _rb.velocity = new Vector3(Mathf.Sign(xDir) * dropForce, _dropForce);
            StartCoroutine(DisableGravity(_dropForce));
        }

        private IEnumerator DisableGravity(float velocity)
        {
            yield return new WaitUntil(() => _rb.velocity.y < -velocity);
            _rb.velocity = Vector3.zero;
            _rb.useGravity = false;
        }
        private IEnumerator EnableCollider(float afterTime)
        {
            yield return new WaitForSeconds(afterTime);
            _collider.enabled = true;
        }

        public void SetStack(ItemStack itemStack)
        {
            _stack = itemStack;
        }
    }
}

