using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public RoomObject roomData;


    // Start is called before the first frame update
    void Start()
    {
        for (int iY = 0; iY < roomData.baseTiles.rows.Length; iY++)
        {
            for (int iX = 0; iX < roomData.baseTiles.rows[iY].row.Length; iX++)
            {
                int ID = (int)roomData.baseTiles.rows[iY].row[iX].tileID;
                
                switch (ID)
                {
                    case 0:

                        break;






                }

                //Instantiate(roomData.baseTiles.rows[iY].row[iX], this.transform);
            }
        }
    }
}
