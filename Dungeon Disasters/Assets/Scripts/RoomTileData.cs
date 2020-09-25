[System.Serializable]
public class RoomTileData
{
    [System.Serializable]
    public struct rowData
    {
        public TileData[] row;
    }

    public rowData[] rows = new rowData[16];
}

[System.Serializable]
public class TileData
{
    public TileID tileID;
    public TileRotation rotation;
}

[System.Serializable]
public enum TileID
{
    Void = 0,

    Floor = 1,

    Door = 2,

    Wall = 3,
    Wall_Corner_Inner = 4,
    Wall_Corner_Outer = 5,

    Pit_Bottom = 6,
    Pit_Wall = 7,
    Pit_Corner_Inner = 8,
    Pit_Corner_Outer = 9,

    Raised_Floor = 10,
    Raised_Wall = 11,
    Raised_Corner_Inner = 12,
    Raised_Corner_Outer = 13,
    Raised_Corner_Double = 14,
    Raised_Stairs = 15,

    Chest = 16,
    Switch = 17,
    Pillar = 18,
    Statue = 19,
    Clutter = 20,
    Portal = 21,
}

[System.Serializable]
public enum TileRotation
{
    r0 = 0,
    r90 = 90,
    r180 = 180,
    r270 = 270
}