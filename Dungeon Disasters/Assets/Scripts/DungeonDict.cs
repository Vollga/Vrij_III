using UnityEngine;

[CreateAssetMenu(fileName ="New Room Set",menuName ="Room Set")]
public class DungeonDict : ScriptableObject
{
    [Header("Entrances")]
    public GameObject[] Entrance;
    [Header("Boss Rooms")]
    public GameObject[] BossUp;
    public GameObject[] BossRight;
    public GameObject[] BossDown;
    public GameObject[] BossLeft;
    [Header("End Rooms")]
    public GameObject[] EndUp;
    public GameObject[] EndRight;
    public GameObject[] EndDown;
    public GameObject[] EndLeft;
    [Header("Corridors")]
    public GameObject[] CorridorHorizontal;
    public GameObject[] CorridorVertical;
    [Header("Corners")]
    public GameObject[] CornerUpRight;
    public GameObject[] CornerUpLeft;
    public GameObject[] CornerDownRight;
    public GameObject[] CornerDownLeft;
    [Header("T Sections")]
    public GameObject[] TUp;
    public GameObject[] TRight;
    public GameObject[] TDown;
    public GameObject[] TLeft;
    [Header("Center Rooms")]
    public GameObject[] Center;
    [Header("Error")]
    public GameObject ErrorRoom;


    //Get Rooms


        //Entrances
    public GameObject GetEntrance()
    {
        return Entrance[Random.Range(0, Entrance.Length)];
    }
        
        //Boss Rooms
    public GameObject GetBossUp()
    {
        return BossUp[Random.Range(0, BossUp.Length)];
    }
    public GameObject GetBossRight()
    {
        return BossRight[Random.Range(0, BossRight.Length)];
    }
    public GameObject GetBossDown()
    {
        return BossDown[Random.Range(0, BossDown.Length)];
    }
    public GameObject GetBossLeft()
    {
        return BossLeft[Random.Range(0, BossLeft.Length)];
    }


        //End Rooms
    public GameObject GetEndUp()
    {
        
        return EndUp[Random.Range(0, EndUp.Length)];
    }
    public GameObject GetEndRight()
    {
        return EndRight[Random.Range(0, EndRight.Length)];
    }
    public GameObject GetEndDown()
    {
       return EndDown[Random.Range(0, EndDown.Length)];
    }
    public GameObject GetEndLeft()
    {
        return EndLeft[Random.Range(0, EndLeft.Length)];
    }

        //Corridors
    public GameObject GetCorridorHorizontal()
    {
        return CorridorHorizontal[Random.Range(0, CorridorHorizontal.Length)];
    }
    public GameObject GetCorridorVertical()
    {
        return CorridorVertical[Random.Range(0, CorridorVertical.Length)];
    }

        //Corners
    public GameObject GetCornerUpRight()
    {
        return CornerUpRight[Random.Range(0, CornerUpRight.Length)];
    }
    public GameObject GetCornerUpLeft()
    {
        return CornerUpLeft[Random.Range(0, CornerUpLeft.Length)];
    }
    public GameObject GetCornerDownRight()
    {
        return CornerDownRight[Random.Range(0, CornerDownRight.Length)];
    }
    public GameObject GetCornerDownLeft()
    {
        return CornerDownLeft[Random.Range(0, CornerDownLeft.Length)];
    }

        //T Pieces
    public GameObject GetTUp()
    {
        return TUp[Random.Range(0, TUp.Length)];
    }
    public GameObject GetTRight()
    {
        return TRight[Random.Range(0, TRight.Length)];
    }
    public GameObject GetTDown()
    {
        return TDown[Random.Range(0, TDown.Length)];
    }
    public GameObject GetTLeft()
    {
        return TLeft[Random.Range(0, TLeft.Length)];
    }
        
        //Center Rooms
    public GameObject GetCenter()
    {
        return Center[Random.Range(0, Center.Length)];
    }

}
