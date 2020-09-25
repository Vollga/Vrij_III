using UnityEngine;

[CreateAssetMenu(fileName = "New Room Layout", menuName = "ScriptableObjects/Room Layout")]

public class RoomObject : ScriptableObject
{
    public RoomTileData baseTiles;
    public RoomTileData miscTiles;
}
