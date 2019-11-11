using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float MoveSpeed;
    private Dictionary<string, Vector3> dir;
    private Vector3 offset;

    public void PointerEnter(string direction) => offset += dir[direction];
    public void PointerExit(string direction) => offset -= dir[direction];

    public void Start()
    {
        dir = new Dictionary<string, Vector3>()
        {
            { "Up", new Vector3(0f, 0f, 1f) },
            { "Down", new Vector3(0f, 0f, -1f) },
            { "Right", new Vector3(1f, 0f, 0f) },
            { "Left", new Vector3(-1f, 0f, 0f) }
        };
        offset = new Vector3(0, 0, 0);
    }
    public void Update()
    {
        float scale = -Input.GetAxis("Mouse ScrollWheel") * 5;
        if ((transform.position.y >= 30 || scale > 0) &&
            (transform.position.y <= 90 || scale < 0))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x += scale;
            transform.rotation = Quaternion.Euler(rotation);
            transform.position += new Vector3(0, scale * 2, 0);
            MoveSpeed += scale;
        }
        transform.position += offset.normalized * Time.deltaTime * MoveSpeed;
    }
}
