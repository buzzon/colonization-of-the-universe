using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    Resource[] RequiredResources { get; }
    Resource[] ProducedResources { get; }
    void Set();
}
