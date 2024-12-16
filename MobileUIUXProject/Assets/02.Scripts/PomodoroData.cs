using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PomodoroData : MonoBehaviour
{
    // �Ǹ𵵷� �̸�
    private string pomodoroName;
    // �Ǹ𵵷� �ݺ�Ƚ��
    private int pomodoroCount;
    // �Ǹ𵵷� �ð�
    private float pomodoroTime;
    // ª�� �޽� �ð�
    private float restTime;
    // �� �޽� �ð�
    private float longRestTime;

    private Panel_Main panel_Main_Scr;
    private PanelPSData panelPSDataScr;
    private PomodoroList pomodoroListScr;
    private NavigationView navigationViewScr;
    [SerializeField]
    private RectTransform nextViewRect;

    private List<GameObject> pomodoroSequence;
    private List<Data> pomodoroSequenceDatas;
    private TMP_Text text;

    public List<GameObject> PomodoroSequence { get => pomodoroSequence; set => pomodoroSequence = value; }
    public List<Data> PomodoroSequenceDatas { get => pomodoroSequenceDatas; set => pomodoroSequenceDatas = value; }
    public TMP_Text Text { get => text; set => text = value; }

    private void Awake()
    {
        pomodoroName = "��մ� ����";
        pomodoroCount = 4;
        pomodoroTime = 1500.0f;
        restTime = 300.0f;
        longRestTime = 900.0f;

        pomodoroSequence = new List<GameObject>();
        pomodoroSequenceDatas = new List<Data>();

        panel_Main_Scr = GetComponentInParent<Panel_Main>();
        pomodoroListScr = GetComponentInParent<PomodoroList>();
        navigationViewScr = GetComponentInParent<NavigationView>();

        panelPSDataScr = GetComponentInParent<PanelPSData>();
        nextViewRect = panelPSDataScr.panelPsView.GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();
    }


    public void GoToDataSetting()
    {
        navigationViewScr.Push(nextViewRect);
        Debug.Log(panel_Main_Scr == null);
        panel_Main_Scr.SetPomodoroDataSetting(this);
        panelPSDataScr.DeleteChildren();
        panelPSDataScr.SetTitleText();
        panelPSDataScr.LoadPomodoroData();
    }

    public void RemovePomodoroData()
    {
        pomodoroListScr.RemoveData(this.gameObject, this);
        Destroy(this.gameObject);
    }

    public void AddPomodoroTime(Data data)
    {
        pomodoroTime += data.time;
    }

    public void AddRestTime(Data data)
    {
        restTime += data.time;
    }

    public void DecreasePomodoroTime(Data data)
    {
        pomodoroTime -= data.time;
    }

    public void DecreaseRestTime(Data data)
    {
        restTime -= data.time;
    }
    
    public void SavePomodoroData(GameObject gameObject, Data data)
    {
        pomodoroSequence.Add(gameObject);
        pomodoroSequenceDatas.Add(data);
    }

    public void ClearPomodoroData()
    {
        pomodoroSequence.Clear();
        pomodoroSequenceDatas.Clear();
    }
}
