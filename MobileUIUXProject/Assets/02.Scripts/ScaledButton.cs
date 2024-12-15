using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;
using UnityEditor.UI;

public class ScaledButton : Button
{
    private RectTransform rectTransform;
    [SerializeField]
    private float scale;
    [SerializeField]
    private float time;

    private WaitForSeconds watingTime;

    [CustomEditor(typeof(ScaledButton))]
    public class ScaledButtonEditor : SelectableEditor
    {
        private ScaledButton sbn;
        SerializedProperty defaultScaledProperty;
        SerializedProperty defaultTimeProperty;
        SerializedProperty m_OnClickProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_OnClickProperty = serializedObject.FindProperty("m_OnClick");

            defaultScaledProperty = serializedObject.FindProperty(nameof(sbn.scale));
            defaultTimeProperty = serializedObject.FindProperty(nameof(sbn.time));
            sbn = target as ScaledButton;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            serializedObject.Update();
            EditorGUILayout.PropertyField(m_OnClickProperty);
            EditorGUILayout.PropertyField(defaultScaledProperty);
            EditorGUILayout.PropertyField(defaultTimeProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }

    protected override void Start()
    {
        base.Start();
        rectTransform = GetComponent<RectTransform>();
        watingTime = new WaitForSeconds(time);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Scale(eventData));
    }
    public IEnumerator Scale(PointerEventData eventData)
    {
        Vector3 currScale = new Vector3(rectTransform.localScale.x, rectTransform.localScale.y, rectTransform.localScale.z);
        transform.DOScale(currScale * scale, 0.05f);

        yield return watingTime;

        transform.DOScale(currScale, 0.05f);

        yield return watingTime;

        base.OnPointerClick(eventData);
    }
}
