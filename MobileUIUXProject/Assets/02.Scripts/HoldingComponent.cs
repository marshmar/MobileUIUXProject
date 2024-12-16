using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEditor.UI;
using DG.Tweening;

public class HoldingComponent : Button
{
    private PomodoroList pomodoroList;
    private RectTransform rectTransform;
    [SerializeField]
    private GameObject holdingImage;
    private float touchStartTime;
    [SerializeField]
    private float scale;
    [SerializeField]
    private float time;
    private bool isPressing;
    private bool createdImage;
    private WaitForSeconds watingTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        holdingImage.SetActive(false);
        createdImage = false;
        isPressing = false;
        rectTransform = GetComponent<RectTransform>();
        watingTime = new WaitForSeconds(time);
        pomodoroList = GetComponentInParent<PomodoroList>();
    }

    public  void Update()
    {
        if (isPressing && !createdImage)
        {
            float touchTime = Time.time;
            Debug.Log("ÅÍÄ¡ Áß");
            if(touchTime - touchStartTime >= 0.5f)
            {
                transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f, 1, 0);
                pomodoroList.EnableImages();
            }
        }
    }

    [CustomEditor(typeof(HoldingComponent))]
    public class HoldingButtonEditor : SelectableEditor
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

            defaultScaledProperty = serializedObject.FindProperty(nameof(sbn.scale));
            defaultTimeProperty = serializedObject.FindProperty(nameof(sbn.time));
            defaultImageProperty = serializedObject.FindProperty(nameof(sbn.holdingImage));
            sbn = target as HoldingComponent;
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

    public override void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public override void OnPointerDown(PointerEventData pointerEventData)
    {
        touchStartTime = Time.time;
        isPressing = true;
    }

    public override void OnPointerUp(PointerEventData pointerEventData)
    {
        isPressing = false;
        float touchEndTime, timeDiff;
        touchEndTime = Time.time;

        timeDiff = touchEndTime - touchStartTime;
        Debug.Log(timeDiff);

        if (timeDiff >= 1.0f)
        {
            
            holdingImage.SetActive(true);
            
        }
        else
        {
            if (!createdImage)
            {
                StartCoroutine(Scale(pointerEventData));
            }
                
        }
        
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

    public void EnableImage()
    {
        createdImage = true;
        holdingImage.SetActive(true);
    }

    public void DisableImage()
    {
        createdImage = false;
        holdingImage.SetActive(false);
    }

}
