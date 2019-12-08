using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    private Dictionary<string, Vector3> dir;
    private Vector3 offset;
    private List<GameObject> sectors;

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

        sectors = GetSectors();
    }

    private void Update()
    {
        float scale = -Input.GetAxis("Mouse ScrollWheel") * 8;
        float newHeight = transform.position.y + scale * 2;
        if (scale != 0 && 
            (newHeight >= 60 || scale > 0) &&
            (newHeight <= 120 || scale < 0))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x += scale;
            transform.rotation = Quaternion.Euler(rotation);
            transform.position += new Vector3(0, scale * 2, 0);
        }
        if (offset.magnitude > 0)
        {
            foreach (GameObject sector in sectors)
                sector.transform.position += offset.normalized * Time.deltaTime * 2;
        }
    }

    private List<GameObject> GetSectors()
    {
        List<GameObject> sectors = new List<GameObject>(transform.childCount);

        for (int i = 0; i < transform.childCount; i++) 
            sectors.Add(transform.GetChild(i).gameObject);

        return sectors;
    }

    public void Set()
    {

    }
}
