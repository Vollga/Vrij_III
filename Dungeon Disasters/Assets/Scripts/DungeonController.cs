using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    // Public variables
    [Header("Map Setup")]
    public DungeonDict roomSet;
    public Tileset tileset;
    [Range(5, 30)]
    public int gridSize = 16;
    public int tileSize = 3;
    public int roomSize = 16;

    [Header("Runner Parameters")]
    [Range(1, 10)]
    public int runners = 3;
    [Range(5, 100)]
    public int maxDistance = 12;
    public bool runnersKnowDirection = true;

    // Dungeon Storage
    public RoomGrid[,] dungeon;
    List<GameObject> roomsList = new List<GameObject>();

    [Header("Pools")]
    public List<GameObject> pool_Void;
    public List<GameObject> pool_Floor;
    public List<GameObject> pool_Wall;
    public List<GameObject> pool_Wall_Corner_Inner;
    public List<GameObject> pool_Wall_Corner_Outer;
    public List<GameObject> pool_Door;
    public List<GameObject> pool_Pit_Bottom;
    public List<GameObject> pool_Pit_Wall;
    public List<GameObject> pool_Pit_Corner_Inner;
    public List<GameObject> pool_Pit_Corner_Outer;
    public List<GameObject> pool_Raised_Floor;
    public List<GameObject> pool_Raised_Wall;
    public List<GameObject> pool_Raised_Stairs;
    public List<GameObject> pool_Raised_Corner_Inner;
    public List<GameObject> pool_Raised_Corner_Outer;
    public List<GameObject> pool_Raised_Corner_Double;
    public List<GameObject> pool_Misc_Chest;
    public List<GameObject> pool_Misc_Switch;
    public List<GameObject> pool_Misc_Pillar;
    public List<GameObject> pool_Misc_Statue;
    public List<GameObject> pool_Misc_Clutter;
    public List<GameObject> pool_Misc_Portal;


    void Start()
    {
        TilePoolGenerate();
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

        roomsList = DungeonSpawner.DrawLayout(dungeon, this.transform.position, sizemultiplier, this.transform, false, null);

        
        //Generating Start Room
        //Instantiate(tile, new Vector3(gridsizeX / 2, 0, gridsizeZ / 2), Quaternion.identity);
    }

    void TilePoolGenerate()
    {
        // Voids
        for (int i = 0; i < 200; i++)
        {
            pool_Void.Add(Instantiate(tileset.GetVoid(), GameObject.Find("Voids").transform));
            pool_Void[i].SetActive(false);
        }
        // Floors
        for (int i = 0; i < 200; i++)
        {
            pool_Floor.Add(Instantiate(tileset.GetFloor(), GameObject.Find("Floors").transform));
            pool_Floor[i].SetActive(false);
        }

        // Doors
        for (int i = 0; i < 10; i++)
        {
            pool_Door.Add(Instantiate(tileset.GetDoor(), GameObject.Find("Walls").transform));
            pool_Door[i].SetActive(false);
        }
        // Walls
        for (int i = 0; i < 100; i++)
        {
            pool_Wall.Add(Instantiate(tileset.GetWallStraight(), GameObject.Find("Walls").transform));
            pool_Wall[i].SetActive(false);
        }
        // Walls Inner Corners
        for (int i = 0; i < 50; i++)
        {
            pool_Wall_Corner_Inner.Add(Instantiate(tileset.GetWallCornerInner(), GameObject.Find("Walls").transform));
            pool_Wall_Corner_Inner[i].SetActive(false);
        }
        // Walls Outer Corners
        for (int i = 0; i < 50; i++)
        {
            pool_Wall_Corner_Outer.Add(Instantiate(tileset.GetWallCornerOuter(), GameObject.Find("Walls").transform));
            pool_Wall_Corner_Outer[i].SetActive(false);
        }

        // Pit Bottoms
        for (int i = 0; i < 40; i++)
        {
            pool_Pit_Bottom.Add(Instantiate(tileset.GetPitBottom(), GameObject.Find("Pits").transform));
            pool_Pit_Bottom[i].SetActive(false);
        }
        // Pit Walls
        for (int i = 0; i < 40; i++)
        {
            pool_Pit_Wall.Add(Instantiate(tileset.GetPitWall(), GameObject.Find("Pits").transform));
            pool_Pit_Wall[i].SetActive(false);
        }
        // Pit Inner Corner
        for (int i = 0; i < 30; i++)
        {
            pool_Pit_Corner_Inner.Add(Instantiate(tileset.GetPitCornerInner(), GameObject.Find("Pits").transform));
            pool_Pit_Corner_Inner[i].SetActive(false);
        }
        // Pit Inner Corner
        for (int i = 0; i < 30; i++)
        {
            pool_Pit_Corner_Outer.Add(Instantiate(tileset.GetPitCornerOuter(), GameObject.Find("Pits").transform));
            pool_Pit_Corner_Outer[i].SetActive(false);
        }

        // Raised Floors
        for (int i = 0; i < 100; i++)
        {
            pool_Raised_Floor.Add(Instantiate(tileset.GetRaisedFloor(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Floor[i].SetActive(false);
        }
        // Raised Wall
        for (int i = 0; i < 30; i++)
        {
            pool_Raised_Wall.Add(Instantiate(tileset.GetRaisedWall(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Wall[i].SetActive(false);
        }
        // Raised Inner Corner
        for (int i = 0; i < 30; i++)
        {
            pool_Raised_Corner_Inner.Add(Instantiate(tileset.GetRaisedCornerInner(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Corner_Inner[i].SetActive(false);
        }
        // Raised Outer Corner
        for (int i = 0; i < 30; i++)
        {
            pool_Raised_Corner_Outer.Add(Instantiate(tileset.GetRaisedCornerOuter(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Corner_Outer[i].SetActive(false);
        }
        // Raised Double Corner
        for (int i = 0; i < 10; i++)
        {
            pool_Raised_Corner_Double.Add(Instantiate(tileset.GetRaisedCornerDouble(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Corner_Double[i].SetActive(false);
        }
        // Raised Stairs
        for (int i = 0; i < 10; i++)
        {
            pool_Raised_Stairs.Add(Instantiate(tileset.GetRaisedStairs(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Stairs[i].SetActive(false);
        }

        // Chest
        for (int i = 0; i < 5; i++)
        {
            pool_Misc_Chest.Add(Instantiate(tileset.GetChest(), GameObject.Find("Misc").transform));
            pool_Misc_Chest[i].SetActive(false);
        }
        // Switch
        for (int i = 0; i < 5; i++)
        {
            pool_Misc_Switch.Add(Instantiate(tileset.GetSwitch(), GameObject.Find("Misc").transform));
            pool_Misc_Switch[i].SetActive(false);
        }
        // Pillar
        for (int i = 0; i < 20; i++)
        {
            pool_Misc_Pillar.Add(Instantiate(tileset.GetPillar(), GameObject.Find("Misc").transform));
            pool_Misc_Pillar[i].SetActive(false);
        }
        // Statue
        for (int i = 0; i < 20; i++)
        {
            pool_Misc_Statue.Add(Instantiate(tileset.GetStatue(), GameObject.Find("Misc").transform));
            pool_Misc_Statue[i].SetActive(false);
        }
        // Clutter
        for (int i = 0; i < 20; i++)
        {
            pool_Misc_Clutter.Add(Instantiate(tileset.GetClutter(), GameObject.Find("Misc").transform));
            pool_Misc_Clutter[i].SetActive(false);
        }
        // Portal
        for (int i = 0; i < 30; i++)
        {
            pool_Misc_Portal.Add(Instantiate(tileset.GetPortal(), GameObject.Find("Misc").transform));
            pool_Misc_Portal[i].SetActive(false);
        }


    }
}
