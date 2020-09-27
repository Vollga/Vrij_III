using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swaptest_Tile : MonoBehaviour
{
    swaptest_Swapper swapper;

    private void Awake()
    {
        swapper = GameObject.Find("swaptest_swapper").GetComponent<swaptest_Swapper>();
    }

    private void OnEnable()
    {
        swapper.GetTile(this.transform);
    }
}
