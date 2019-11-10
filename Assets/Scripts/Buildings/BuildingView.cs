using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingView : MonoBehaviour
{
    public bool IsCollision { get; private set; }

    private bool isBuilt;
    public bool IsBuilt
    {
        get => isBuilt;
        set 
        {
            if (value)
                transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
            isBuilt = value;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!IsCollision && !IsBuilt)
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
