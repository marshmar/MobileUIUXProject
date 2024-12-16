using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TIMETYPE { POMODORO, REST}

public class Data : MonoBehaviour
{
    private Sprite sprite;
    public float time;
    public TIMETYPE timeType;
    private PanelPSData panelPSDataScr;

    public Sprite Sprite { get => sprite; set => sprite = value; }

    // Start is called before the first frame update
    void Awake()
    {
        panelPSDataScr = GetComponentInParent<PanelPSData>();
        sprite = GetComponent<Sprite>();
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
        //panelPSDataScr.pomodoroData.DecreasePomodoroTime(this);
        Destroy(this.gameObject);
    }
}
