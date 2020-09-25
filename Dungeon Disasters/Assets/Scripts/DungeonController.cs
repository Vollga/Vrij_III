using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    // Public variables
    [Header("Map Setup")]
    public GameObject tile;
    public DungeonDict roomSet;
    [Range(5, 30)]
    public int gridSize = 16;
    public int tileSize = 3;
    public int roomSize = 16;
    public bool drawEmptyRooms = false;
    public bool drawBasic = false;
    public GameObject emptyTile;

    [Header("Runner Parameters")]
    [Range(1, 10)]
    public int runners;
    [Range(5, 100)]
    public int maxDistance;
    public bool runnersKnowDirection;

    // Dungeon Storage
    public Room[,] dungeon;
    List<GameObject> roomsList = new List<GameObject>();

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (GameObject room in roomsList)
            {
                Destroy(room);
            }
            roomsList.Clear();
            InitialiseDungeon();
            print("This dungeon has " + roomsList.Count + " rooms.");
        }
    }

    void InitialiseDungeon()
    {
        int sizemultiplier = tileSize * roomSize;
        // Initialise dungeon layout
        dungeon = new Room[gridSize, gridSize];
        
        // Populate dungeon array
        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                dungeon[iX, iZ] = new Room();
            }
        }

        // Start runnin' and populate array with basic dungeon
        if (runnersKnowDirection == true)    // runner knows it's previous direction
        {
            for (int i = 0; i < runners; i++)
            {
               dungeon = MapGenerate.RunnerNoBacktrack(dungeon, new Vector2(gridSize / 2, gridSize / 2), Random.Range(5, maxDistance + 1), MapGenerate.RandomDirVector());
            }
        }
        else
        {
            for (int i = 0; i < runners; i++) // runner doesnt know it's previous direction
            {
                dungeon = MapGenerate.RunnerBasic(dungeon, new Vector2(gridSize / 2, gridSize / 2), Random.Range(5, maxDistance + 1));
            }
        }

        // Add extra Rooms to array
        MapGenerate.PlaceStart(dungeon);
        MapGenerate.PlaceSpecial(dungeon);


        // Assign Room Assets
        RoomFunctions.AssignRoomTypes(dungeon, roomSet);

        // Place Placeholders
        if (!drawBasic)
        {
            roomsList = DungeonSpawner.DrawLayout(dungeon, this.transform.position, this.transform, drawEmptyRooms, emptyTile);
        }
        else
        {
            roomsList = DungeonSpawner.DrawBasic(dungeon, tile ,this.transform.position, sizemultiplier, this.transform, drawEmptyRooms, emptyTile);
        }
        
        //Generating Start Room
        //Instantiate(tile, new Vector3(gridsizeX / 2, 0, gridsizeZ / 2), Quaternion.identity);
    }
}
