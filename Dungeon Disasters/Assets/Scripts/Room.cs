using UnityEngine;

public class Room
{
    public bool isEnabled = false;      //Is there a room in this spot?

    public int ID = 0;                  //Room Type ID (Normal, Start, Boss)

    public GameObject roomAsset = null; //Assigned Room Prefab

    public bool hasRoomUp = false;      //Neighboring Rooms
    public bool hasRoomRight = false;
    public bool hasRoomDown = false;
    public bool hasRoomLeft = false;

    public void Enable()
    {
        isEnabled = true;
    }
}
