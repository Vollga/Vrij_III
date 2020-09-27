using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(RoomTileData))]
public class CustomRoomLayoutEditor : PropertyDrawer
{
    int fieldHeight = 20;
    int paddingY = 5;
    int fieldWidth = 50;
    int paddingX = 5;
       

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);

        Rect newPosition = position;
        newPosition.y += 18f;
        SerializedProperty rows = property.FindPropertyRelative("rows");

        for (int iY = 15; iY >= 0; iY--)
        {
            SerializedProperty row = rows.GetArrayElementAtIndex(iY).FindPropertyRelative("row");
            newPosition.height = fieldHeight;

            if (row.arraySize != 16)
                row.arraySize = 16;

            newPosition.width = fieldWidth;

            for (int iX = 0; iX < 16; iX++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(iX).FindPropertyRelative("tileID"), GUIContent.none);
                Rect t = newPosition;
                t.y += fieldHeight-3;
                EditorGUI.PropertyField(t, row.GetArrayElementAtIndex(iX).FindPropertyRelative("rotation"), GUIContent.none);
                newPosition.x += newPosition.width + paddingX;
            }

            newPosition.x = position.x;
            newPosition.y += fieldHeight*2 + paddingY;
        }
    }

    /*public GUIContent setColor(TileID ID)
    {
        GUIContent baguette = new GUIContent();
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
                return ;

            case TileID.Wall_Corner_Outer:
                return ;

            case TileID.Pit_Bottom:
                return ;

            case TileID.Pit_Wall:
                return ;

            case TileID.Pit_Corner_Inner:
                return ;

            case TileID.Pit_Corner_Outer:
                return ;

            case TileID.Raised_Floor:
                return ;

            case TileID.Raised_Wall:
                return ;

            case TileID.Raised_Corner_Inner:
                return ;

            case TileID.Raised_Corner_Outer:
                return ;

            case TileID.Raised_Corner_Double:
                return ;

            case TileID.Raised_Stairs:
                return ;

            case TileID.Chest:
                return ;

            case TileID.Switch:
                return ;

            case TileID.Pillar:
                return ;

            case TileID.Statue:
                return ;

            case TileID.Clutter:
                return C;

            case TileID.Portal:
                return ;

            default:
                return 
        }

    }*/

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return (fieldHeight*2+paddingY) * 18;
    }
}
