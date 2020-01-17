using System.Collections.Generic;

public static class GlobalData
{
    public static SectorManager CurrentSectorManager;
    public static BuildingProfile[] BuildingProfiles;
    public static bool IsPlaceManagerActive;
}

public class BuildingProfileComparer : IComparer<BuildingProfile>
{
    public int Compare(BuildingProfile x, BuildingProfile y)
    {
        return x.Type.CompareTo(y.Type);
    }
}