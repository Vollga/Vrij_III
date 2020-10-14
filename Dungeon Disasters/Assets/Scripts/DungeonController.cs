using System.Collections.Generic;
using System.Runtime.InteropServices;
//using System.Runtime.CompilerServices;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    #region Singleton
    public static DungeonController Instance;
    #endregion
    
    // Public variables
    [Header("Map Setup")]
    public DungeonDict roomSet;
    [Range(5, 30)]
    public int gridSize = 16;
    public int tileSize = 3;
    public int roomSize = 16;

    [Header("Tileset Setup")]
    public Tileset[] tileset;
    public int currentTileset;
    


    [Header("Runner Parameters")]
    [Range(1, 10)]
    public int runners = 3;
    [Range(5, 100)]
    public int maxDistance = 12;
    public bool runnersKnowDirection = true;

    // Dungeon Storage
    public RoomGrid[,] dungeon;
    List<GameObject> roomsList = new List<GameObject>();

    [HideInInspector]
    public Vector3 startPosition = Vector2.zero;


    void Awake()
    {
        Instance = this;
        this.GetComponent<TilePoolManager>().InitialGenerate(tileset[currentTileset]);
    }

    private void Start()
    {
        InitialiseDungeon();
    }


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

            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 30, 0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;

        }

    }

    void InitialiseDungeon()
    {
        int sizemultiplier = tileSize * roomSize;
        // Initialise dungeon layout
        dungeon = new RoomGrid[gridSize, gridSize];
        
        // Populate dungeon array
        for (int iZ = 0; iZ < dungeon.GetLength(1); iZ++)
        {
            for (int iX = 0; iX < dungeon.GetLength(0); iX++)
            {
                dungeon[iX, iZ] = new RoomGrid();
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
        RoomGridFunctions.AssignRoomTypes(dungeon, roomSet);

        // Place Placeholders

        roomsList = DungeonSpawner.DrawLayout(dungeon, startPosition*-1, sizemultiplier, this.transform, false, roomSet.ErrorRoom);

    }

}
