using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/Profile")]
public class BuildingProfile : ScriptableObject
{
    public GameObject Prefab;
    public Sprite Icon;
    public string Name;
    public Resource[] RequiredResources;
}