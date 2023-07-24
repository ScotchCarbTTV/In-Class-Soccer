using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    [SerializeField] Vector2 zLimit;
    [SerializeField] Vector2 xLimit;

    void Update()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {        
            newPos += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPos += -transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos += -transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos += transform.right * moveSpeed * Time.deltaTime;
        }

        
        if(newPos.z > zLimit.x)
        {
            newPos.z = transform.position.z;
        }
        if (newPos.z < zLimit.y)
        {
            newPos.z = transform.position.z;
        }
        if (newPos.x > xLimit.x)
        {
            newPos.x = transform.position.x;
        }
        if (newPos.x < xLimit.y)
        {
            newPos.x = transform.position.x;
        }

        transform.position = newPos;

    }

}
