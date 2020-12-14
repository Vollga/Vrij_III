using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileID ID;
    TilePoolManager poolManager;


    private void Awake()
    {
        poolManager = TilePoolManager.Instance;
        if (!poolManager._debugMode)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnEnable()
    {
        poolManager.GetTile(ID, this.transform);
    }
    private void OnDisable()
    {
        
    }
}
