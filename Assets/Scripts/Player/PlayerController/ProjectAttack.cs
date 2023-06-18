using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectAttack : MonoBehaviour
{
    #region Datamembers

    #region Editor Settings

    public delegate void EnemyHit();
    public static event EnemyHit hitE;
    [SerializeField] private float speed;
    

    #endregion
    #region Private Fields

    private bool destoryed = false;

    #endregion

    #endregion


    #region Methods

    #region Unity Callbacks

    private void Start()
    {
        var rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = transform.forward * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (destoryed == false)
        {
            /*if (other.CompareTag("Enemy"))
            {
                hitE.Invoke();
            }*/
            Destroy(gameObject);
        }
    }

    #endregion

    #endregion
}
