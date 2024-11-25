using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool isOnTimer;
    [SerializeField]
    private TMP_Text timerText;
    private float accumulatedTime;

    public float AccumulatedTime { get => accumulatedTime; set => accumulatedTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        isOnTimer = false;
        accumulatedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTimer)
        {
            accumulatedTime += Time.deltaTime;
            timerText.text = CauculateTime(accumulatedTime);
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
}
