﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject TerrainOverWhichMove;
    private Dictionary<string, Vector3> dir;
    private Vector3 offset;
    private float height;

    public void PointerEnter(string direction) => offset += dir[direction];
    public void PointerExit(string direction) => offset -= dir[direction];

    private void Start()
    {
        dir = new Dictionary<string, Vector3>()
        {
            { "Up", new Vector3(0f, 0f, 1f) },
            { "Down", new Vector3(0f, 0f, -1f) },
            { "Right", new Vector3(1f, 0f, 0f) },
            { "Left", new Vector3(-1f, 0f, 0f) }
        };
        offset = new Vector3(0, 0, 0);
        height = GetHeight();
    }

    private void Update()
    {
        float scale = -Input.GetAxis("Mouse ScrollWheel") * 10;
        float newHeight = height + scale * 4;
        if (scale != 0 && 
            (newHeight >= 50 || scale > 0) &&
            (newHeight <= 210 || scale < 0))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x += scale;
            transform.rotation = Quaternion.Euler(rotation);
            transform.position += new Vector3(0, scale * 4, scale * Mathf.Sin(rotation.x * Mathf.PI / 180) * 1.2f);
            height = newHeight;
        }
        if (offset.magnitude > 0)
        {
            transform.position += offset.normalized * Time.deltaTime * height * 2;
            transform.position += new Vector3(0, height - GetHeight(), 0);
        }
    }

    private float GetHeight()
    {
        RaycastHit[] hits;
        Ray ray = new Ray(transform.position, Vector3.down);
        hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject == TerrainOverWhichMove)
                return transform.position.y - hit.point.y;
        }
        return 0f;
    }
}
