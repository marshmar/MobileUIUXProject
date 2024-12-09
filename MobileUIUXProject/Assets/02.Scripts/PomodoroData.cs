using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private PomodoroList pomodoroListScr;
    private void Awake()
    {
        pomodoroName = "Àç¹Õ´Â °øºÎ";
        pomodoroCount = 4;
        pomodoroTime = 1500.0f;
        restTime = 300.0f;
        longRestTime = 900.0f;
        panel_Main_Scr = GetComponentInParent<Panel_Main>();
        pomodoroListScr = GetComponentInParent<PomodoroList>();
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
        panel_Main_Scr.SetPomodoroDataSetting(this);
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
}
