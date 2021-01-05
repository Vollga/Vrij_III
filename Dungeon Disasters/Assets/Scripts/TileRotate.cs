using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.transform.rotation = Quaternion.Euler(0, Random.Range(0,4)*90, 0);
    }


}
