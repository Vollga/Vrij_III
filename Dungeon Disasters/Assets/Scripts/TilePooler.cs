using System.Collections.Generic;
using UnityEngine;

public class TilePooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public TileID ID;
        public int size;
    }
    
    public Dictionary<string, Queue<GameObject>> poolDict;

    public List<Pool> tilePools;


    // Start is called before the first frame update
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();
    }

    public void TilePoolGenerate(Tileset tileset)
    {
        foreach (Pool poolio in tilePools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolio.size; i++)
            {
                GameObject obj = Instantiate(tileset.GetTile(poolio.ID));
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDict.Add(nameof(poolio.ID), objectPool);
        }



        // Voids
        Queue<GameObject> pool = new Queue<GameObject>();
        for (int i = 0; i < 200; i++)
        {
            GameObject obj = Instantiate(tileset.GetVoid(), GameObject.Find("Voids").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Floors
        for (int i = 0; i < 200; i++)
        {
            GameObject obj = Instantiate(tileset.GetFloor(), GameObject.Find("Floors").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Floor", pool);
        pool.Clear();
        
        // Doors
        Queue<GameObject> pool_Door = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(tileset.GetDoor(), GameObject.Find("Walls").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Door", pool);
        pool.Clear();

        // Walls
        Queue<GameObject> pool_Walls = new Queue<GameObject>();
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(tileset.GetWallStraight(), GameObject.Find("Walls").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Wall", pool);
        pool.Clear();

        // Walls Inner Corner
        Queue<GameObject> pool_Wall_Corner_Inner = new Queue<GameObject>();
        for (int i = 0; i < 50; i++)
        {
            GameObject obj = Instantiate(tileset.GetWallCornerInner(), GameObject.Find("Walls").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Wall Inner Corner", pool);
        pool.Clear();

        // Walls Outer Corners
        Queue<GameObject> pool_Wall_Corner_Outer = new Queue<GameObject>();
        for (int i = 0; i < 50; i++)
        {
            GameObject obj = Instantiate(tileset.GetWallCornerOuter(), GameObject.Find("Walls").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Wall Outer Corner", pool);
        pool.Clear();

        // Pit Bottoms
        Queue<GameObject> pool_Pit_Bottom = new Queue<GameObject>();
        for (int i = 0; i < 40; i++)
        {
            GameObject obj = Instantiate(tileset.GetPitBottom(), GameObject.Find("Pits").transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        /*// Pit Walls
        Queue<GameObject> pool_Pit_Wall = new Queue<GameObject>();
        for (int i = 0; i < 40; i++)
        {
            pool_Pit_Wall.Add(Instantiate(tileset.GetPitWall(), GameObject.Find("Pits").transform));
            pool_Pit_Wall[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Pit Inner Corner
        Queue<GameObject> pool_Corner_Inner = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            pool_Pit_Corner_Inner.Add(Instantiate(tileset.GetPitCornerInner(), GameObject.Find("Pits").transform));
            pool_Pit_Corner_Inner[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Pit Outer Corner
        Queue<GameObject> pool_Corner_Outer = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            pool_Pit_Corner_Outer.Add(Instantiate(tileset.GetPitCornerOuter(), GameObject.Find("Pits").transform));
            pool_Pit_Corner_Outer[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Raised Floors
        Queue<GameObject> pool_Raised_Floor = new Queue<GameObject>();
        for (int i = 0; i < 100; i++)
        {
            pool_Raised_Floor.Add(Instantiate(tileset.GetRaisedFloor(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Floor[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Raised Wall
        Queue<GameObject> pool_Raised_Wall = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            pool_Raised_Wall.Add(Instantiate(tileset.GetRaisedWall(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Wall[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Raised Inner Corner
        Queue<GameObject> pool_Raised_Corner_Inner = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            pool_Raised_Corner_Inner.Add(Instantiate(tileset.GetRaisedCornerInner(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Corner_Inner[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Raised Outer Corner
        Queue<GameObject> pool_Raised_Corner_Outer = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            pool_Raised_Corner_Outer.Add(Instantiate(tileset.GetRaisedCornerOuter(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Corner_Outer[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Raised Double Corner
        Queue<GameObject> pool_Raised_Corner_Double = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            pool_Raised_Corner_Double.Add(Instantiate(tileset.GetRaisedCornerDouble(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Corner_Double[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Raised Stairs
        Queue<GameObject> pool_Raised_Stairs = new Queue<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            pool_Raised_Stairs.Add(Instantiate(tileset.GetRaisedStairs(), GameObject.Find("Raised Platforms").transform));
            pool_Raised_Stairs[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Chest
        Queue<GameObject> pool_Misc_Chest = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            pool_Misc_Chest.Add(Instantiate(tileset.GetChest(), GameObject.Find("Misc").transform));
            pool_Misc_Chest[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Switch
        Queue<GameObject> pool_Misc_Switch = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            pool_Misc_Switch.Add(Instantiate(tileset.GetSwitch(), GameObject.Find("Misc").transform));
            pool_Misc_Switch[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Pillar
        Queue<GameObject> pool_Misc_Pillar = new Queue<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            pool_Misc_Pillar.Add(Instantiate(tileset.GetPillar(), GameObject.Find("Misc").transform));
            pool_Misc_Pillar[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Statue
        Queue<GameObject> pool_Misc_Statue = new Queue<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            pool_Misc_Statue.Add(Instantiate(tileset.GetStatue(), GameObject.Find("Misc").transform));
            pool_Misc_Statue[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Clutter
        Queue<GameObject> pool_Misc_Clutter = new Queue<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            pool_Misc_Clutter.Add(Instantiate(tileset.GetClutter(), GameObject.Find("Misc").transform));
            pool_Misc_Clutter[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

        // Portal
        Queue<GameObject> pool_Misc_Portal = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            pool_Misc_Portal.Add(Instantiate(tileset.GetPortal(), GameObject.Find("Misc").transform));
            pool_Misc_Portal[i].SetActive(false);
        }
        poolDict.Add("Void", pool);
        pool.Clear();

    */
    }

}
