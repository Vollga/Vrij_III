using UnityEngine;

[CreateAssetMenu(fileName ="New Tileset",menuName ="Tileset")]
public class Tileset : ScriptableObject
{
    [Header("Floors")]
    public GameObject[] Floor;

    [Header("Walls")]
    public GameObject[] Wall_Straight;
    public GameObject[] Wall_Corner_Inner;
    public GameObject[] Wall_Corner_Outer;

    [Header("Doors")]
    public GameObject[] Door;

    [Header("Pits")]
    public GameObject[] Pit_Empty;
    public GameObject[] Pit_Straight;
    public GameObject[] Pit_Corner_Inner;
    public GameObject[] Pit_Corner_Outer;

    [Header("Raised Platforms")]
    public GameObject[] Raised_Floor;
    public GameObject[] Raised_Stairs;
    public GameObject[] Raised_Wall;
    public GameObject[] Raised_Corner_Inner;
    public GameObject[] Raised_Corner_Outer;
    public GameObject[] Raised_Corner_Double;

    [Header("Objects")]
    public GameObject[] Chest;
    public GameObject[] Switch;
    public GameObject[] Pillar;
    public GameObject[] Clutter;
    public GameObject[] Portal;

    //Get Tiles


    //Floors
    public GameObject GetFloor()
    {
        return Floor[Random.Range(0, Floor.Length)];
    }
        
        //Boss Walls
    public GameObject GetWallStraight()
    {
        return Wall_Straight[Random.Range(0, Wall_Straight.Length)];
    }
    public GameObject GetWallCornerInner()
    {
        return Wall_Corner_Inner[Random.Range(0, Wall_Corner_Inner.Length)];
    }
    public GameObject GetWallCornerOuter()
    {
        return Wall_Corner_Outer[Random.Range(0, Wall_Corner_Outer.Length)];
    }

        //Doors
    public GameObject GetDoor()
    {
        
        return Door[Random.Range(0, Door.Length)];
    }

        //Pits
    public GameObject GetPitEmpty()
    {
        return Pit_Empty[Random.Range(0, Pit_Empty.Length)];
    }
    public GameObject GetPitStraight()
    {
        return Pit_Straight[Random.Range(0, Pit_Straight.Length)];
    }
    public GameObject GetPitCornerInner()
    {
        return Pit_Corner_Inner[Random.Range(0, Pit_Corner_Outer.Length)];
    }

        //Raised Platforms
    public GameObject GetRaisedFloor()
    {
        return Raised_Floor[Random.Range(0, Raised_Floor.Length)];
    }
    public GameObject GetRaisedStairs()
    {
        return Raised_Stairs[Random.Range(0, Raised_Stairs.Length)];
    }
    public GameObject GetRaisedCornerInner()
    {
        return Raised_Corner_Inner[Random.Range(0, Raised_Corner_Inner.Length)];
    }
    public GameObject GetRaisedCornerOuter()
    {
        return Raised_Corner_Outer[Random.Range(0, Raised_Corner_Outer.Length)];
    }
    public GameObject GetRaisedCornerDouble()
    {
        return Raised_Corner_Double[Random.Range(0, Raised_Corner_Double.Length)];
    }

        //Misc Objects
    public GameObject GetChest()
    {
        return Chest[Random.Range(0, Chest.Length)];
    }
    public GameObject GetSwitch()
    {
        return Switch[Random.Range(0, Switch.Length)];
    }
    public GameObject GetPillar()
    {
        return Pillar[Random.Range(0, Pillar.Length)];
    }
    public GameObject GetClutter()
    {
        return Clutter[Random.Range(0, Clutter.Length)];
    }

}
