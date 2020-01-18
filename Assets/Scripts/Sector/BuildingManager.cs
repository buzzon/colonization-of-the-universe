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

    public bool IsBuilt { get; set; }

    public void SetAsBuilt(BuildingProfile buildingProfile)
    {
        if (!IsBuilt)
        {
            GlobalData.CurrentSectorManager.AddBuilding(buildingProfile, gameObject);
            IsBuilt = true;
            IsWork = true;
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
