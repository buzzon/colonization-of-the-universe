using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IBuilding
{
    public Resource[] RequiredResources { get; private set; }
    public Resource[] ProducedResources { get; private set; }

    public void Set()
    {
        RequiredResources = new Resource[]
        {
            new Resource(ResourceType.Energy, 2)
        };
        ProducedResources = new Resource[]
        {
            new Resource(ResourceType.Coal, 3)
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
