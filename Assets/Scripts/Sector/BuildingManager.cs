using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private bool isWork;
    public bool IsWork 
    {
        get => isWork;
        set
        {
            if (value)
                transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
            else
                transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2f, 0.2f, 0));
            isWork = value;
        }
    }
    public bool IsCollision { get; private set; }

    private bool isBuilt;
    public bool IsBuilt
    {
        get => isBuilt;
        set 
        {
            if (value)
            {
                Building building = transform.GetComponent<Building>();
                building.Set();
                IsWork = true;
            }
            isBuilt = value;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!IsBuilt && !IsCollision)
        {
            transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2f, 0, 0));
            IsCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!IsBuilt)
        {
            transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0.2f, 0));
            IsCollision = false;
        }
    }
}
