using System;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static SectorManager CurrentSectorManager;
    public static BuildingProfile[] BuildingProfiles;
    public static ResourceProfile[] ResourceProfiles;
    public static bool IsPlaceManagerActive;

    static GlobalData()
    {
        BuildingProfiles = Resources.LoadAll<BuildingProfile>("Buildings");
        Array.Sort(BuildingProfiles, new BuildingProfileComparer());
        ResourceProfiles = Resources.LoadAll<ResourceProfile>("Resources");
        IsPlaceManagerActive = false;
    }
}

public class BuildingProfileComparer : IComparer<BuildingProfile>
{
    public int Compare(BuildingProfile x, BuildingProfile y)
    {
        return x.Type.CompareTo(y.Type);
    }
}