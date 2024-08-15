using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public Vector3 targetPosition;
    public Button moveButton;

    // Start is called before the first frame update
    void Start()
    {
        if(moveButton != null)
        {
            moveButton.onClick.AddListener(MoveToPosition);
        }
    }

    void MoveToPosition()
    {
        //Debug.Log("Clicked");
        transform.position = targetPosition;
        //Debug.Log(transform.position);
        //transform.position = new Vector3(-37.05f, 0.113f, -0.52f);
    } 
}
