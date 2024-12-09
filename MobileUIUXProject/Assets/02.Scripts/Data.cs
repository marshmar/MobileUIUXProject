using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TIMETYPE { POMODORO, REST}

public class Data : MonoBehaviour
{
    public float time;
    public TIMETYPE timeType;
    private PanelPSData panelPSDataScr;
    
    // Start is called before the first frame update
    void Awake()
    {
        panelPSDataScr = GetComponentInParent<PanelPSData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPomodoroData()
    {
        if(timeType == TIMETYPE.POMODORO)
            panelPSDataScr.pomodoroData.AddPomodoroTime(this);
        else if(timeType == TIMETYPE.REST)
            panelPSDataScr.pomodoroData.AddRestTime(this);
    }

    
    public void DestroyThisObject()
    {
        panelPSDataScr.pomodoroData.DecreasePomodoroTime(this);
        Destroy(this.gameObject);
    }
}
