using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public GameObject World;
    public GameObject SectorPrefab;
    public int SectorsInLine;
    public float SectorsGap;

    private Dictionary<string, Vector3> dir;
    private Vector3 offset;
    private Map map;

    public void PointerEnter(string direction) => offset += dir[direction];
    public void PointerExit(string direction) => offset -= dir[direction];

    private void Start()
    {
        map = new Map(World, SectorPrefab, SectorsInLine, SectorsGap);

        dir = new Dictionary<string, Vector3>()
        {
            { "Up", new Vector3(0f, 0f, 1f) },
            { "Down", new Vector3(0f, 0f, -1f) },
            { "Right", new Vector3(1f, 0f, 0f) },
            { "Left", new Vector3(-1f, 0f, 0f) }
        };
        offset = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        float scale = -Input.GetAxis("Mouse ScrollWheel") * 10;
        float newHeight = transform.position.y + scale * 2;
        if (scale != 0 && 
            (newHeight >= 60 || scale > 0) &&
            (newHeight <= 120 || scale < 0))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x += scale;
            transform.rotation = Quaternion.Euler(rotation);
            transform.position += new Vector3(0, scale * 2, scale * Mathf.Sin(rotation.x * Mathf.PI / 180) * 1.2f);
        }

        if (offset.magnitude > 0)
            map.Move(offset.normalized, Time.deltaTime, transform.position.y);
    }
}
