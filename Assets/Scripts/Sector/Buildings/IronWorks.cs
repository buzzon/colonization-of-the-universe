using System.Collections.Generic;
using UnityEngine;

public class IronWorks : Building
{
    public override void Set()
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
