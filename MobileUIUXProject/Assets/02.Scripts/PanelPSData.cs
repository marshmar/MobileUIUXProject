using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelPSData : MonoBehaviour
{
    public PomodoroData pomodoroData;
    public RectTransform panelPsView;
    [SerializeField]
    private GameObject pomodoroSequenceObject;
    public GameObject iconPrefab;
    [SerializeField]
    private TMP_InputField nameInput;

    public void SavePomodoroData()
    {
        int index = pomodoroSequenceObject.transform.childCount;
        for(int i = 0; i < index; i++)
        { 
            pomodoroData.SavePomodoroData(pomodoroSequenceObject.transform.GetChild(i).gameObject,
                pomodoroSequenceObject.transform.GetChild(i).GetComponent<Data>());
        }
        pomodoroData.Text.text = nameInput.text;
    }

    public void LoadPomodoroData()
    {
        for(int i = 0; i < pomodoroData.PomodoroSequence.Count; i++)
        {
            GameObject tempObj = Instantiate(iconPrefab, pomodoroSequenceObject.transform);
            if(tempObj.TryGetComponent<Data>(out Data data))
            {
                tempObj.GetComponent<Image>().sprite = pomodoroData.PomodoroSequenceDatas[i].Sprite;
            }
        }
    }

    public void ClearData()
    {
        pomodoroData.ClearPomodoroData();
    }

    public void SetTitleText()
    {
        nameInput.text = pomodoroData.Text.text;
    }
    
    public void DeleteChildren()
    {
        for(int i = pomodoroSequenceObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(pomodoroSequenceObject.transform.GetChild(i).gameObject);
        }
    }
}
