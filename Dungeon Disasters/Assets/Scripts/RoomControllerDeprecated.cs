using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControllerDeprecated : MonoBehaviour
{
    public RoomLayout roomData;

    TilePoolManager poolManager;

    // Start is called before the first frame update
    void Start()
    {
        poolManager = TilePoolManager.Instance;

        for (int iY = 0; iY < roomData.baseTiles.rows.Length; iY++)
        {
            for (int iX = 0; iX < roomData.baseTiles.rows[iY].row.Length; iX++)
            {
                //Get appropriate tile from Pool
                poolManager.SpawnTile(roomData.baseTiles.rows[iY].row[iX], new Vector3(iX, 0,iY), this.transform);

            }
        }
    }
}
