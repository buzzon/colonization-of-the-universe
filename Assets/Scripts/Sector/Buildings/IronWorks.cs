using System.Collections.Generic;
using UnityEngine;

public class IronWorks : MonoBehaviour, IBuilding
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
            new Resource(ResourceType.Iron, 2)
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
