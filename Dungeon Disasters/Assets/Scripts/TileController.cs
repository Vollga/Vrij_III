using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileID ID;
    TilePoolManager poolManager;
    GameObject TileA;
    GameObject TileB;

    /*private void Awake()
    {
        poolManager = TilePoolManager.Instance;
        if (!poolManager._debugMode)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnEnable()
    {
        activeTile = poolManager.GetTile(ID, this.transform);
        activeTile.SetActive(true);
    }
    private void OnDisable()
    {
        activeTile.SetActive(false);
    }*/

    private void Awake()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        TileA = Instantiate(DungeonController.Instance.tileset[DungeonController.Instance.tilesetToUse].GetTile(ID),transform.position,transform.rotation,transform);
        TileB = Instantiate(DungeonController.Instance.tileset[0].GetTile(ID),transform.position,transform.rotation,transform);
        TileB.SetActive(false);
    }

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown("b"))
        {
            TileA.SetActive(!TileA.activeSelf);
            TileB.SetActive(!TileB.activeSelf);
        }*/
        if(TileB.activeSelf != DungeonController.Instance._blockoutMode)
        {
            TileA.SetActive(!DungeonController.Instance._blockoutMode);
            TileB.SetActive(DungeonController.Instance._blockoutMode);
            //print("tileset switch");
        }
    }

    private void OnEnable()
    {
        TileA.SetActive(!DungeonController.Instance._blockoutMode);
        TileB.SetActive(DungeonController.Instance._blockoutMode);
    }

}
