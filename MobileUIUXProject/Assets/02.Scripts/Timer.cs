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
        // ��ü �ʿ��� �ð� ���
        int hours = (int)(time / 3600);
        // ������ �ʿ��� �� ���
        int minutes = (int)((time % 3600) / 60);
        // �� ���
        int seconds = (int)(time % 60);


        // ���ڿ� ����
        // D2: ���� ����ȭ, 2�ڸ��� �����ֱ�
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}
