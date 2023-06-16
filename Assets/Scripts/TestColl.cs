using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestColl : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
        }
    }
}