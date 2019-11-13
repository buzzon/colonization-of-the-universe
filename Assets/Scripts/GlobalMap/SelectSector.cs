using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSector : MonoBehaviour
{
    private GameObject _selectedSector;
    public float ClickDelta = 0.35f;
    private float _clickTime;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag == "Sector")
            {
                if (IsDoubleClick(hit.transform.gameObject)) 
                    OpenSector(_selectedSector);
                else
                {
                    if (_selectedSector != null) ReleaseSector(_selectedSector);

                    _selectedSector = hit.transform.gameObject;
                    SetColor(_selectedSector, Color.red);
                }
            }
        }

        _clickTime = Time.time;
    }

    private bool IsDoubleClick(GameObject sector)
    {
        return Time.time <= _clickTime + ClickDelta && _selectedSector == sector;
    }

    private static void SetColor(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private static void ReleaseSector(GameObject sector)
    {
        sector.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    private static void OpenSector(GameObject sector)
    {
        SetColor(sector,Color.green);
    }
}
