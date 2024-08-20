using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public Vector3 targetPosition;

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Run");
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Collided");
    //        collision.gameObject.transform.position = targetPosition;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Run");
        if (other.tag == "Player")
        {
            Debug.Log("Collided");
            other.transform.position = targetPosition;
        }
    }
}
