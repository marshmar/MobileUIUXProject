using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroData : MonoBehaviour
{
    // »Ç¸ðµµ·Î ÀÌ¸§
    private string pomodoroName;
    // »Ç¸ðµµ·Î ¹Ýº¹È½¼ö
    private int pomodoroCount;
    // »Ç¸ðµµ·Î ½Ã°£
    private float pomodoroTime;
    // ÂªÀº ÈÞ½Ä ½Ã°£
    private float restTime;
    // ±ä ÈÞ½Ä ½Ã°£
    private float longRestTime;

    private Panel_Main panel_Main_Scr;
    private PanelPSData panelPSDataScr;
    private PomodoroList pomodoroListScr;
    private NavigationView navigationViewScr;
    [SerializeField]
    private RectTransform nextViewRect;

    
    private List<GameObject> focusTimeList;
    private List<GameObject> restTimeList;
    private List<GameObject> longRestTimeList;


    private void Awake()
    {
        pomodoroName = "Àç¹Õ´Â °øºÎ";
        pomodoroCount = 4;
        pomodoroTime = 1500.0f;
        restTime = 300.0f;
        longRestTime = 900.0f;

        focusTimeList = new List<GameObject>();
        restTimeList = new List<GameObject>();
        longRestTimeList = new List<GameObject>();

        panel_Main_Scr = GetComponentInParent<Panel_Main>();
        pomodoroListScr = GetComponentInParent<PomodoroList>();
        navigationViewScr = GetComponentInParent<NavigationView>();

        panelPSDataScr = GetComponentInParent<PanelPSData>();
        nextViewRect = panelPSDataScr.panelPsView.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToDataSetting()
    {
        navigationViewScr.Push(nextViewRect);
        Debug.Log(panel_Main_Scr == null);
        panel_Main_Scr.SetPomodoroDataSetting(this);
        panelPSDataScr.DeleteData();
        panelPSDataScr.SetData();
    }

    public void RemovePomodoroData()
    {
        pomodoroListScr.RemoveData(this.gameObject);
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

    public List<GameObject> GetFocusTimeList()
    {
        return focusTimeList;
    }

    public List<GameObject> GetRestTimeList()
    {
        return restTimeList;
    }

    public List<GameObject> GetLongRestTimeList()
    {
        return longRestTimeList;
    }

    public void AddFocusTimeList(GameObject gameObject)
    {
        focusTimeList.Add(Instantiate(gameObject));
    }
    public void AddRestTimeList(GameObject gameObject)
    {
        restTimeList.Add(Instantiate(gameObject));
    }

    public void AddLongRestTimeList(GameObject gameObject)
    {
        longRestTimeList.Add(Instantiate(gameObject));
    }

}
