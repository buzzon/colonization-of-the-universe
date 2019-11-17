using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IBuilding
{
    public void Set()
    {
        CurrentSector.Manager.AddResourceFactor(ResourceType.Energy, -2);
        CurrentSector.Manager.AddResourceFactor(ResourceType.Coal, 2);
    }
}
