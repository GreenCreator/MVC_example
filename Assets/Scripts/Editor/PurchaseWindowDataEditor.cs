using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PurchaseWindowData))]
public class PurchaseWindowDataEditor : Editor
{
    private SerializedProperty titleProperty;
    private SerializedProperty descriptionProperty;
    private SerializedProperty itemsProperty;
    private SerializedProperty priceProperty;
    private SerializedProperty discountProperty;
    private SerializedProperty nameMainIconProperty;
    private IconMapping iconMapping;

    private void OnEnable()
    {
        titleProperty = serializedObject.FindProperty("Title");
        descriptionProperty = serializedObject.FindProperty("Description");
        itemsProperty = serializedObject.FindProperty("Items");
        priceProperty = serializedObject.FindProperty("Price");
        discountProperty = serializedObject.FindProperty("Discount");
        nameMainIconProperty = serializedObject.FindProperty("NameMainIcon");

        iconMapping = Resources.Load<IconMapping>("IconMapping");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(titleProperty);
        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.PropertyField(priceProperty);
        EditorGUILayout.PropertyField(discountProperty);
        EditorGUILayout.PropertyField(nameMainIconProperty);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Items", EditorStyles.boldLabel);

        if (iconMapping != null && iconMapping.Icons != null)
        {
            for (int i = 0; i < itemsProperty.arraySize; i++)
            {
                SerializedProperty itemProperty = itemsProperty.GetArrayElementAtIndex(i);
                SerializedProperty selectedIconProperty = itemProperty.FindPropertyRelative("selectedIcon");
                SerializedProperty itemCountProperty = itemProperty.FindPropertyRelative("itemCount");

                EditorGUILayout.BeginHorizontal();

                GUILayout.Label("Item Count", GUILayout.Width(70));
                itemCountProperty.intValue = EditorGUILayout.IntField(itemCountProperty.intValue, GUILayout.Width(50));

                var iconNames = new string[iconMapping.Icons.Count];
                for (int j = 0; j < iconNames.Length; j++)
                {
                    iconNames[j] = iconMapping.Icons[j].IconName;
                }

                var selectedIconIndex = Mathf.Max(0,
                    Array.IndexOf(iconNames, (selectedIconProperty.objectReferenceValue as IconData)?.IconName));

                GUILayout.Label("Icon", GUILayout.Width(40));
                selectedIconIndex = EditorGUILayout.Popup(selectedIconIndex, iconNames, GUILayout.Width(100));
                selectedIconProperty.objectReferenceValue = iconMapping.Icons[selectedIconIndex];

                if (GUILayout.Button("Remove", GUILayout.Width(70)))
                {
                    itemsProperty.DeleteArrayElementAtIndex(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();

                GUILayout.Space(5);
            }

            EditorGUILayout.Space();

            if (GUILayout.Button("Add Item", GUILayout.Width(200)))
            {
                itemsProperty.InsertArrayElementAtIndex(itemsProperty.arraySize);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("IconMapping не назначен или не содержит иконок.", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }
}