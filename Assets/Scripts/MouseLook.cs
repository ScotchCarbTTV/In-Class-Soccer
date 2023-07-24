using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.5f;

    [SerializeField] private float drag = 1.5f;


    private Transform character;
    private Vector2 mouseDir;
    private Vector2 smoothing;
    private Vector2 result;

    private void Awake()
    {
        character = transform.parent;
    }

    void Update()
    {
        mouseDir = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity, Input.GetAxisRaw("Mouse Y") * sensitivity);

        smoothing = Vector2.Lerp(smoothing, mouseDir, 1 / drag);

        result += smoothing;
        result.y = Mathf.Clamp(result.y, -80, 80);

        transform.localRotation = Quaternion.AngleAxis(-result.y, Vector3.right);
        character.rotation = Quaternion.AngleAxis(result.x, character.transform.up);
    }
}
