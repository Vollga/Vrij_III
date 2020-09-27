using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swaptest_Swapper : MonoBehaviour
{
    public GameObject[] theme;
    public GameObject tileToUpdate;

    public bool _updateTile;
    bool _hasbeenupdated = false;

    GameObject pooledTile;


    // Start is called before the first frame update
    void Start()
    {
        pooledTile = Instantiate(theme[0]);
        pooledTile.SetActive(false);
    }

    public void GetTile(Transform parent)
    {
        GameObject objectToSpawn = pooledTile;

        objectToSpawn.SetActive(true);
        //objectToSpawn.transform.parent = parent;
        objectToSpawn.transform.position = parent.position;
        objectToSpawn.transform.rotation = parent.rotation;

    }

    private void Update()
    {
        if (_updateTile == true && _hasbeenupdated == false)
        {
            UpdateTile();
            print("tile has been updated");
            _hasbeenupdated = true;
        }
    }

    public void UpdateTile()
    {
        pooledTile = Instantiate(theme[1]);
    }
}
