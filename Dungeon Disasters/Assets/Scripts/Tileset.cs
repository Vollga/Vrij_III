using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Tileset",menuName = "ScriptableObjects/Tileset")]
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
    public GameObject[] Pit_Bottom;
    public GameObject[] Pit_Wall;
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
    public GameObject[] Statue;
    public GameObject[] Clutter;
    public GameObject[] Portal;

    [Header("Void")]
    public GameObject[] Void;

    //Get Tiles

    public GameObject GetTile(TileID ID)
    {
        switch (ID)
        {
            case TileID.Void:
                return Void[Random.Range(0, Void.Length)];

            case TileID.Floor:
                return Floor[Random.Range(0, Floor.Length)];

            case TileID.Door:
                return Door[Random.Range(0, Door.Length)];

            case TileID.Wall:
                return Wall_Straight[Random.Range(0, Wall_Straight.Length)];

            case TileID.Wall_Corner_Inner:
                return Wall_Corner_Inner[Random.Range(0, Wall_Corner_Inner.Length)];

            case TileID.Wall_Corner_Outer:
                return Wall_Corner_Outer[Random.Range(0, Wall_Corner_Outer.Length)];

            case TileID.Pit_Bottom:
                return Pit_Bottom[Random.Range(0, Pit_Bottom.Length)];

            case TileID.Pit_Wall:
                return Pit_Wall[Random.Range(0, Pit_Wall.Length)];

            case TileID.Pit_Corner_Inner:
                return Pit_Corner_Inner[Random.Range(0, Pit_Corner_Inner.Length)];

            case TileID.Pit_Corner_Outer:
                return Pit_Corner_Outer[Random.Range(0, Pit_Corner_Outer.Length)];

            case TileID.Raised_Floor:
                return Raised_Floor[Random.Range(0, Raised_Floor.Length)];

            case TileID.Raised_Wall:
                return Raised_Wall[Random.Range(0, Raised_Wall.Length)];

            case TileID.Raised_Corner_Inner:
                return Raised_Corner_Inner[Random.Range(0, Raised_Corner_Inner.Length)];

            case TileID.Raised_Corner_Outer:
                return Raised_Corner_Outer[Random.Range(0, Raised_Corner_Outer.Length)];

            case TileID.Raised_Corner_Double:
                return Raised_Corner_Double[Random.Range(0, Raised_Corner_Double.Length)];

            case TileID.Raised_Stairs:
                return Raised_Stairs[Random.Range(0, Raised_Stairs.Length)];

            case TileID.Chest:
                return Chest[Random.Range(0, Chest.Length)];

            case TileID.Switch:
                return Switch[Random.Range(0, Switch.Length)];

            case TileID.Pillar:
                return Pillar[Random.Range(0, Pillar.Length)];

            case TileID.Statue:
                return Statue[Random.Range(0, Statue.Length)];

            case TileID.Clutter:
                return Clutter[Random.Range(0, Clutter.Length)];

            case TileID.Portal:
                return Portal[Random.Range(0, Portal.Length)];

        }

        return null;
    }


        //Voids
    public GameObject GetVoid()
    {
        return Void[Random.Range(0, Void.Length)];
    }

        //Floors
    public GameObject GetFloor()
    {
        return Floor[Random.Range(0, Floor.Length)];
    }
        
        //Walls
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
    public GameObject GetPitBottom()
    {
        return Pit_Bottom[Random.Range(0, Pit_Bottom.Length)];
    }
    public GameObject GetPitWall()
    {
        return Pit_Wall[Random.Range(0, Pit_Wall.Length)];
    }
    public GameObject GetPitCornerInner()
    {
        return Pit_Corner_Inner[Random.Range(0, Pit_Corner_Inner.Length)];
    }
    public GameObject GetPitCornerOuter()
    {
        return Pit_Corner_Outer[Random.Range(0, Pit_Corner_Outer.Length)];
    }

    //Raised Platforms
    public GameObject GetRaisedFloor()
    {
        return Raised_Floor[Random.Range(0, Raised_Floor.Length)];
    }
    public GameObject GetRaisedWall()
    {
        return Raised_Wall[Random.Range(0, Raised_Wall.Length)];
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
    public GameObject GetStatue()
    {
        return Statue[Random.Range(0, Statue.Length)];
    }
    public GameObject GetClutter()
    {
        return Clutter[Random.Range(0, Clutter.Length)];
    }
    public GameObject GetPortal()
    {
        return Portal[Random.Range(0, Portal.Length)];
    }

}
