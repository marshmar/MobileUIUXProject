using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [Header("Pomodoro")]
    [SerializeField]
    private TMP_Text timerText;
    private bool isOnPomodoro;
    private bool isOnRest;
    private float pomodoroTime;
    private float basePomodoroTime;
    private float restTime;
    private float baseRestTime;

    [Header("Infinity")]
    [SerializeField]
    private TMP_Text pomodoroTimerText;
    private bool isOnTimer;
    private float accumulatedTime;

    
    private Panel_Main panelMainScr;
    private Pomodoro pomodoroScr;
    public float AccumulatedTime { get => accumulatedTime; set => accumulatedTime = value; }
    public bool IsOnPomodoro { get => isOnPomodoro; set => isOnPomodoro = value; }
    public float BasePomodoroTime { get => basePomodoroTime; set => basePomodoroTime = value; }
    public bool IsOnTimer { get => isOnTimer; set => isOnTimer = value; }


    // Start is called before the first frame update
    void Start()
    {
        isOnTimer = false;
        isOnPomodoro = false;
        isOnRest = false;
        accumulatedTime = 0.0f;
        basePomodoroTime = 1500.0f;
        pomodoroTime = basePomodoroTime;
        baseRestTime = 300.0f;
        restTime = baseRestTime;
        pomodoroScr = GetComponent<Pomodoro>();
        panelMainScr = GetComponentInChildren<Panel_Main>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTimer)
        {
            if (isOnRest)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    restTime -= 10.0f;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    restTime -= 30.0f;
                }
                restTime -= Time.deltaTime;
                pomodoroScr.SetRestCircleImage(restTime / baseRestTime);
                if(restTime <= 0)
                {
                    restTime = baseRestTime;
                    pomodoroTime = basePomodoroTime;
                    isOnTimer = false;
                    isOnRest = false;
                    panelMainScr.SetPomodoroBeforeStudying();
                    pomodoroScr.EndPomodoro();
                    pomodoroTimerText.text = CauculateTime(pomodoroTime);
                    return;
                }
                pomodoroTimerText.text = CauculateTime(restTime);
            }
            else
            {
                accumulatedTime += Time.deltaTime;
                if (isOnPomodoro)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        pomodoroTime -= 10.0f;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        pomodoroTime -= 60.0f;
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        pomodoroTime -= 300.0f;
                    }
                    
                    pomodoroTime -= Time.deltaTime;
                    pomodoroScr.SetCircleImage(pomodoroTime / basePomodoroTime);
                    if (pomodoroTime <= 0)
                    {
                        isOnRest = true;
                        panelMainScr.SetPomodoroRest();
                    }
                    pomodoroTimerText.text = CauculateTime(pomodoroTime);
                }
                else
                {
                    timerText.text = CauculateTime(accumulatedTime);
                }
            }



        }
    }

    public void StartTimer()
    {
        isOnTimer = true;
    }

    public void StopTimer()
    {
        isOnTimer = false;
    }

    public string CauculateTime(float time)
    {
        // 전체 초에서 시간 계산
        int hours = (int)(time / 3600);
        // 나머지 초에서 분 계산
        int minutes = (int)((time % 3600) / 60);
        // 초 계산
        int seconds = (int)(time % 60);


        // 문자열 보간
        // D2: 숫자 서식화, 2자리만 보여주기
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    public void SetTimerText()
    {
        timerText.text = CauculateTime(accumulatedTime);
    }

    public void ResetPomodoroTime()
    {
        pomodoroTime = basePomodoroTime;
        pomodoroTimerText.text = CauculateTime(pomodoroTime);
        if (isOnRest)
        {
            isOnTimer = false;
            isOnRest = false;
            panelMainScr.SetPomodoroBeforeStudying();
            pomodoroScr.EndPomodoro();
        }
    }
}
