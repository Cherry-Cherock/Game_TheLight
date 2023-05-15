using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectAttack : MonoBehaviour
{
    #region Datamembers

    #region Editor Settings

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

    private void OnCollisionEnter(Collision col)
    {
        if (destoryed == false)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #endregion
}
