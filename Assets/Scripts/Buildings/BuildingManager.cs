using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public bool IsCollision { get; private set; }

    private bool isBuilt;
    public bool IsBuilt
    {
        get => isBuilt;
        set 
        {
            if (value)
            {
                transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
                IBuilding building = transform.GetComponent<IBuilding>();
                building.Set();
            }
            isBuilt = value;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!IsBuilt && !IsCollision)
        {
            transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.1f, 0, 0));
            IsCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!IsBuilt)
        {
            transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0.1f, 0));
            IsCollision = false;
        }
    }
}
