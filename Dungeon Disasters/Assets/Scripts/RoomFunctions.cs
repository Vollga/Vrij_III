using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFunctions : MonoBehaviour
{
    public static Room[,] AssignRoomTypes(Room[,] dungeon, DungeonDict roomSet)
    {
        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                // Check for Neighbors
                if (iZ + 1 < dungeon.GetLength(1))          //Check if space above
                {
                    if (dungeon[iX, iZ + 1].isEnabled)       //Check if has room Above
                    {
                        dungeon[iX, iZ].hasRoomUp = true;
                        print("Room " + iX + "," + iZ + " has a neighbor above");
                    }
                }

                if (iZ - 1 >= 0)                              //Check if space below
                {
                    if (dungeon[iX, iZ - 1].isEnabled)      //Check if has room Below
                    {
                        dungeon[iX, iZ].hasRoomDown = true;
                        print("Room " + iX + "," + iZ + " has a neighbor below");
                    }
                }

                if (iX + 1 < dungeon.GetLength(0))          //Check if space right
                {
                    if (dungeon[iX + 1, iZ].isEnabled)      //Check if has room Right
                    {
                        dungeon[iX, iZ].hasRoomRight = true;
                        print("Room " + iX + "," + iZ + " has a neighbor to the right");
                    }
                }

                if (iX - 1 >= 0)                              //Check if space left
                {
                    if (dungeon[iX - 1, iZ].isEnabled)      //Check if has room Left
                    {
                        dungeon[iX, iZ].hasRoomLeft = true;
                        print("Room " + iX + "," + iZ + " has a neighbor to the left");
                    }
                }

                // Assign matching prefab from set
                dungeon[iX, iZ] = SetAsset(dungeon[iX, iZ], roomSet);
            }
        }
        return dungeon;
    }

    public static Room[,] SetSpecialRoomLeft(Room[,] dungeon, int ID)
    {
        bool roomIsPlaced = false;
        for (int iX = 0; iX < dungeon.GetLength(0); iX++)
        {
            for (int iZ = dungeon.GetLength(1) - 1; iZ >= 0; iZ--)
            {
                if (dungeon[iX + 1, iZ].isEnabled && (dungeon[iX + 1, iZ].ID == 0))
                {
                    dungeon[iX, iZ].Enable();
                    dungeon[iX, iZ].ID = ID;     // Set ID to "Boss"
                    roomIsPlaced = true;
                    break;
                }

            }
            if (roomIsPlaced)
            {
                break;
            }
        }
        return dungeon;
    }

    public static Room[,] SetSpecialRoomTop(Room[,] dungeon, int ID)
    {
        bool roomIsPlaced = false;
        for (int iZ = dungeon.GetLength(1) - 1; iZ >= 0; iZ--)
        {
            for (int iX = dungeon.GetLength(0) - 1; iX >= 0; iX--)
            {
                if (dungeon[iX, iZ - 1].isEnabled && (dungeon[iX, iZ - 1].ID == 0))
                {
                    dungeon[iX, iZ].Enable();
                    dungeon[iX, iZ].ID = ID;     // Set ID to "Boss"
                    roomIsPlaced = true;
                    break;
                }

            }
            if (roomIsPlaced)
            {
                break;
            }
        }
        return dungeon;
    }

    public static Room[,] SetSpecialRoomRight(Room[,] dungeon, int ID)
    {
        bool roomIsPlaced = false;
        for (int iX = dungeon.GetLength(0) - 1; iX >= 0; iX--)
        {
            for (int iZ = dungeon.GetLength(1) - 1; iZ >= 0; iZ--)
            {
                if (dungeon[iX - 1, iZ].isEnabled && (dungeon[iX - 1, iZ].ID == 0))
                {
                    dungeon[iX, iZ].Enable();
                    dungeon[iX, iZ].ID = ID;     // Set ID to "Boss"
                    roomIsPlaced = true;
                    break;
                }

            }
            if (roomIsPlaced)
            {
                break;
            }
        }
        return dungeon;
    }

    public static Room SetAsset(Room room, DungeonDict roomSet)
    {
        switch (room.ID)
        {
            case 0:     // Room is Normal

                // Room has 4 Doors
                if (room.hasRoomUp && room.hasRoomRight && room.hasRoomDown && room.hasRoomLeft)
                {
                    room.roomAsset = roomSet.GetCenter();
                }

                // Room has 3 Doors
                else if (room.hasRoomUp && room.hasRoomRight && !room.hasRoomDown && room.hasRoomLeft)  //No door Down
                {
                    room.roomAsset = roomSet.GetTUp();
                }
                else if (room.hasRoomUp && room.hasRoomRight && room.hasRoomDown && !room.hasRoomLeft)  //No door Left
                {
                    room.roomAsset = roomSet.GetTRight();
                }
                else if (!room.hasRoomUp && room.hasRoomRight && room.hasRoomDown && room.hasRoomLeft)  //No Door Up
                {
                    room.roomAsset = roomSet.GetTDown();
                }
                else if (room.hasRoomUp && !room.hasRoomRight && room.hasRoomDown && room.hasRoomLeft)  //No Door Right
                {
                    room.roomAsset = roomSet.GetTLeft();
                }

                // Room is Corner
                else if (room.hasRoomUp && room.hasRoomRight && !room.hasRoomDown && !room.hasRoomLeft)   //Up and Right
                {
                    room.roomAsset = roomSet.GetCornerUpRight();
                }
                else if (room.hasRoomUp && !room.hasRoomRight && !room.hasRoomDown && room.hasRoomLeft)   //Up and Left
                {
                    room.roomAsset = roomSet.GetCornerUpLeft();
                }
                else if (!room.hasRoomUp && room.hasRoomRight && room.hasRoomDown && !room.hasRoomLeft)   //Down and Right
                {
                    room.roomAsset = roomSet.GetCornerDownRight();
                }
                else if (!room.hasRoomUp && !room.hasRoomRight && room.hasRoomDown && room.hasRoomLeft)   //Down and Left
                {
                    room.roomAsset = roomSet.GetCornerDownLeft();
                }

                // Room is Corrior
                else if (!room.hasRoomUp && room.hasRoomRight && !room.hasRoomDown && room.hasRoomLeft)   //Horizontal
                {
                    room.roomAsset = roomSet.GetCorridorHorizontal();
                }
                else if (room.hasRoomUp && !room.hasRoomRight && room.hasRoomDown && !room.hasRoomLeft)   //Vertical
                {
                    room.roomAsset = roomSet.GetCorridorVertical();
                }

                // Room is Sackgasse
                else if (room.hasRoomUp && !room.hasRoomRight && !room.hasRoomDown && !room.hasRoomLeft)   //Up
                {
                    room.roomAsset = roomSet.GetEndUp();
                }
                else if (!room.hasRoomUp && room.hasRoomRight && !room.hasRoomDown && !room.hasRoomLeft)   //Right
                {
                    room.roomAsset = roomSet.GetEndRight();
                }
                else if (!room.hasRoomUp && !room.hasRoomRight && room.hasRoomDown && !room.hasRoomLeft)   //Down
                {
                    room.roomAsset = roomSet.GetEndDown();
                }
                else if (!room.hasRoomUp && !room.hasRoomRight && !room.hasRoomDown && room.hasRoomLeft)   //Left
                {
                    room.roomAsset = roomSet.GetEndLeft();
                }

                // Fallback
                else
                {
                    room.roomAsset = roomSet.ErrorRoom;
                }

                break;

            case 1:     // Room is Entrance
                room.roomAsset = roomSet.GetEntrance();
                break;

            case 2:     // Room is Boss room
                if (room.hasRoomUp)     //Up
                {
                    room.roomAsset = roomSet.GetBossUp();
                }
                if (room.hasRoomRight)  //Right
                {
                    room.roomAsset = roomSet.GetBossRight();
                }
                if (room.hasRoomDown)   //Down
                {
                    room.roomAsset = roomSet.GetBossDown();
                }
                if (room.hasRoomLeft)   //Left
                {
                    room.roomAsset = roomSet.GetBossLeft();
                }
                break;

            default:
                Debug.LogWarning("Bruh");
                break;
           
        }

        return room;

    }
}
