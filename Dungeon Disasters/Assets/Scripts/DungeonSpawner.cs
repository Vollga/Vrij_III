using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public static List<GameObject> DrawBasic(Room[,] dungeon, GameObject tilePrefab, Vector3 spawnOffset, int roomSize, Transform parentTransform, bool fillEmpty, GameObject emptyTile)
    {
        List<GameObject> roomsList = new List<GameObject>();
        GameObject emptySquares = new GameObject("Empty Rooms");

        roomsList.Add(emptySquares);

        if (fillEmpty == true)
        {
            roomsList.Add(Instantiate(emptySquares, parentTransform));
        }

        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                if (dungeon[iX, iZ].isEnabled == true)
                {
                    var newRoom = Instantiate(tilePrefab, new Vector3((iX - (dungeon.GetLength(0) / 2) + spawnOffset.x)*roomSize, 0, (iZ - (dungeon.GetLength(1) / 2) + spawnOffset.z)*roomSize), Quaternion.identity);
                    newRoom.transform.parent = parentTransform;
                    roomsList.Add(newRoom);
                } else if ( fillEmpty == true)
                {
                    var newRoom = Instantiate(emptyTile, new Vector3(iX - (dungeon.GetLength(0) / 2) + spawnOffset.x, 0, iZ - (dungeon.GetLength(1) / 2) + spawnOffset.z), Quaternion.identity);
                    newRoom.transform.parent = emptySquares.transform;
                    roomsList.Add(newRoom);
                }
            }
        }
        return roomsList;
    }

    public static List<GameObject> DrawLayout(Room[,] dungeon, Vector3 spawnOffset, Transform parentTransform, bool fillEmpty, GameObject emptyTile)
    {
        List<GameObject> roomsList = new List<GameObject>();
        GameObject emptySquares = new GameObject("Empty Rooms");

        roomsList.Add(emptySquares);

        if (fillEmpty == true)
        {
            roomsList.Add(Instantiate(emptySquares, parentTransform));
        }

        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                if (dungeon[iX, iZ].isEnabled == true)
                {
                    var newRoom = Instantiate(dungeon[iX, iZ].roomAsset ,new Vector3(iX - (dungeon.GetLength(0) / 2) + spawnOffset.x, 0, iZ - (dungeon.GetLength(1) / 2) + spawnOffset.z), Quaternion.identity);
                    newRoom.transform.parent = parentTransform;
                    roomsList.Add(newRoom);
                }
                else if (fillEmpty == true)
                {
                    var newRoom = Instantiate(emptyTile, new Vector3(iX - (dungeon.GetLength(0) / 2) + spawnOffset.x, 0, iZ - (dungeon.GetLength(1) / 2) + spawnOffset.z), Quaternion.identity);
                    newRoom.transform.parent = emptySquares.transform;
                    roomsList.Add(newRoom);
                }
            }
        }
        return roomsList;
    }

}
