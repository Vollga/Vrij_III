using System.Collections.Generic;
using UnityEngine;

public class TilePoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public TileID ID;
        public int size;
    }

    #region Singleton
    public static TilePoolManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    public Dictionary<string, Queue<GameObject>> poolDict = new Dictionary<string, Queue<GameObject>>();

    public bool _debugMode = false;
    public List<Pool> tilePools;

    int tileSize;

    // Start is called before the first frame update
    void Start()
    {
        tileSize = this.GetComponent<DungeonController>().tileSize;
        //poolDict = new Dictionary<string, Queue<GameObject>>();
    }

    public void InitialGenerate(Tileset tileset)
    {
        if (!_debugMode)
        {
            foreach (Pool currentPool in tilePools)
            {
                print("Generating Pool for Tile ID " + currentPool.ID.ToString());
                Queue<GameObject> poolQueue = new Queue<GameObject>();

                for (int i = 0; i < currentPool.size; i++)
                {
                    GameObject obj = Instantiate(tileset.GetTile(currentPool.ID),GameObject.Find(currentPool.ID.ToString()).transform);
                    obj.SetActive(false);
                    poolQueue.Enqueue(obj);
                    //print(currentPool.ID.ToString() + " tile instantiated");
                }
                poolDict.Add(currentPool.ID.ToString(), poolQueue);
                print(currentPool.ID.ToString() + " Queue added to Dictionary");
            }
        }
        
    }

    public GameObject GetTile(TileID ID, Transform parent)
    {
        if (!_debugMode)
        {
            GameObject objectToSpawn = poolDict[ID.ToString()].Dequeue();

            objectToSpawn.SetActive(true);
            //objectToSpawn.transform.parent = parent;
            objectToSpawn.transform.position = parent.position;
            objectToSpawn.transform.rotation = parent.rotation;

            poolDict[ID.ToString()].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
        return null;
    }


    public void SpawnTile ( TileData tile,Vector3 position, Transform parent)
    {
        if (!_debugMode)
        {
            //print("Retrieving from Pool ID" + tile.tileID.ToString());
            GameObject objectToSpawn = poolDict[tile.tileID.ToString()].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.parent = parent;
            objectToSpawn.transform.position = (position * tileSize) + parent.position;
            objectToSpawn.transform.eulerAngles = new Vector3(0, (int)tile.rotation, 0);

            poolDict[tile.tileID.ToString()].Enqueue(objectToSpawn);
        }
    }

    public void DisableTile()
    {

    }

}
