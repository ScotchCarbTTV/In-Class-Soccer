using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKick : MonoBehaviour
{
    [SerializeField] private float ballAccel = 5f;

    private Vector3 playerDir;
    private Vector3 kickDir;

    private Rigidbody rbody;

    private void Awake()
    {
        if(TryGetComponent<Rigidbody>(out rbody) == false)
        {
            Debug.Log("You need to add a rigidbody to this object!");
        }
    }
    private void Kick(Vector3 _kickDir)
    {
        rbody.AddForce(_kickDir * ballAccel);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<PlayerMove>(out PlayerMove playerMove))
        {
            Debug.Log("Ball kicked");

            Vector3 playerPos = new Vector3(collision.transform.position.x, transform.position.y - 0.25f,
                collision.transform.position.z);

            playerDir = playerPos - transform.position;
            playerDir = playerDir.normalized;

            kickDir = -playerDir;

            Kick(kickDir);
        }
    }
}
