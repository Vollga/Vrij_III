using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFade : MonoBehaviour
{
    public Color colour;

    Image title;
    private void Start()
    {
        title = this.GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        title.material.SetColor("Color_8787107", colour);


    }
}
