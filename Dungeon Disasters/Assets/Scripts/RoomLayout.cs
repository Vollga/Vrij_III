using UnityEngine;

[CreateAssetMenu(fileName = "New Room Layout", menuName = "ScriptableObjects/Room Layout")]

public class RoomLayout : ScriptableObject
{
    public RoomTileData baseTiles;
    public RoomTileData miscTiles;
}
