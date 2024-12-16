#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(HoldingComponent))]
public class HoldingComponentEditor : SelectableEditor
{
    private HoldingComponent sbn;
    SerializedProperty defaultScaledProperty;
    SerializedProperty defaultTimeProperty;
    SerializedProperty m_OnClickProperty;
    SerializedProperty defaultImageProperty;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_OnClickProperty = serializedObject.FindProperty("m_OnClick");

        sbn = target as HoldingComponent;
        defaultScaledProperty = serializedObject.FindProperty(nameof(sbn.scale));
        defaultTimeProperty = serializedObject.FindProperty(nameof(sbn.time));
        defaultImageProperty = serializedObject.FindProperty(nameof(sbn.holdingImage));
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_OnClickProperty);
        EditorGUILayout.PropertyField(defaultScaledProperty);
        EditorGUILayout.PropertyField(defaultTimeProperty);
        EditorGUILayout.PropertyField(defaultImageProperty);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
