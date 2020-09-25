using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(RoomTileData))]
public class CustomRoomObjectData : PropertyDrawer
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

        for (int iY = 0; iY < 16; iY++)
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
                t.y += fieldHeight;
                EditorGUI.PropertyField(t, row.GetArrayElementAtIndex(iX).FindPropertyRelative("rotation"), GUIContent.none);
                newPosition.x += newPosition.width + paddingX;
            }

            newPosition.x = position.x;
            newPosition.y += fieldHeight*2 + paddingY;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return (fieldHeight*2+paddingY) * 18;
    }
}
