using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LottiePlugin.UI;

public class Panel_Main : MonoBehaviour
{
    private Timer timerScr;
    private Pomodoro pomodoroScr;
    private PanelPSData panelPSDataScr;

    [SerializeField]
    private GameObject imageStudying;
    [SerializeField]
    private GameObject buttonStudyMode;

    [Header("Sector")]
    [SerializeField]
    private GameObject panelTop;
    [SerializeField]
    private GameObject panelMiddle;
    [SerializeField]
    private GameObject panelBottom;
    [SerializeField]
    private GameObject panelMusic;


    [Header("Infinity")]
    [SerializeField]
    private GameObject panelInfinityStudying;
    [SerializeField]
    private GameObject panelInfinityBeforeStudying;
    [SerializeField]
    private GameObject textInfinityTimer;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private AnimatedImage infinityAnimatedImage;

    [Header("Pomodoro")]
    [SerializeField]
    private GameObject panelPomodoroBeforeStudying;
    [SerializeField]
    private GameObject panelPomodoroStudying;
    [SerializeField]
    private GameObject panelPomodoroSetting;
    [SerializeField]
    private GameObject panelPomodoroList;
    [SerializeField]
    private GameObject panelPomodoroDataSetting;
    [SerializeField]
    private PanelPSData panelPsDataScr;
    [SerializeField]
    private GameObject panelPomodoroRest;
    [SerializeField]
    private GameObject textPomodoroTimer;
    [SerializeField]
    private GameObject pomodoroStartButton;
    [SerializeField]
    private GameObject pomodoroPauseButton;
    [SerializeField]
    private AnimatedImage pomodoroAnimatedImage;

    private void Awake()
    {
        timerScr = GetComponentInParent<Timer>();
        pomodoroScr = GetComponentInParent<Pomodoro>();
        //panelPsDataScr = GetComponentInChildren<PanelPSData>();
    }
    // Start is called before the first frame update
    void Start()
    {

        SetPanelBeforeStudying();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // �Ǹ𵵷� �޽�ȭ������ ����
    public void SetPomodoroRest()
    {
        panelPomodoroStudying.SetActive(false);
        panelPomodoroBeforeStudying.SetActive(false);
        panelPomodoroRest.SetActive(true);

    }

    // �Ǹ𵵷� Ÿ�̸� ����Ʈȭ������ ����
    public void SetPomodoroTimerSetting()
    {
        if (timerScr.IsOnTimer) return;
        Debug.Log(timerScr.IsOnTimer);
        panelPomodoroBeforeStudying.SetActive(false);
        imageStudying.SetActive(false);
        buttonStudyMode.SetActive(false);
        textPomodoroTimer.SetActive(false);

        // �г� ����
        panelTop.SetActive(false);
        panelMiddle.SetActive(false);
        panelBottom.SetActive(false);
        panelMusic.SetActive(false);

        panelPomodoroSetting.SetActive(true);
        panelPomodoroList.SetActive(true);
        panelPomodoroDataSetting.SetActive(false);
    }

    // �Ǹ𵵷� Ÿ�̸� ������ ����ȭ������ ����
    public void SetPomodoroDataSetting(PomodoroData pomodoroData)
    {
        panelPsDataScr.pomodoroData = pomodoroData;
    }
    // �Ǹ𵵷� ���� �� �гη� ����
    public void SetPomodoroBeforeStudying()
    {
        timerScr.IsOnPomodoro = true;

        // �г� ����
        panelTop.SetActive(true);
        panelMiddle.SetActive(true);
        panelBottom.SetActive(true);
        panelMusic.SetActive(true);

        panelPomodoroRest.SetActive(false);
        panelPomodoroSetting.SetActive(false);
        panelInfinityStudying.SetActive(false);
        panelInfinityBeforeStudying.SetActive(false);
        panelPomodoroBeforeStudying.SetActive(true);
        panelPomodoroStudying.SetActive(false);
        textInfinityTimer.SetActive(false);
        textPomodoroTimer.SetActive(true);
        imageStudying.SetActive(false);
        buttonStudyMode.SetActive(true);
    }

    // �Ǹ𵵷� ���θ�� �гη� ����
    public void SetPomodoroStudying()
    {
        panelPomodoroBeforeStudying.SetActive(false);
        panelPomodoroStudying.SetActive(true);
        imageStudying.SetActive(true);
        buttonStudyMode.SetActive(false);
        pomodoroStartButton.SetActive(false);
        pomodoroPauseButton.SetActive(true);
        pomodoroAnimatedImage.Play();
    }

    // ���� ���θ�� �гη� ����
    public void SetInfinityPanel()
    {
        if(timerScr.AccumulatedTime >= 0)
        {

            panelInfinityStudying.SetActive(true);
            panelInfinityBeforeStudying.SetActive(false);
            buttonStudyMode.SetActive(false);
            imageStudying.SetActive(true);
            startButton.SetActive(false);
            pauseButton.SetActive(true);
            infinityAnimatedImage.Play();
        }
        else
        {

        }
    }

    // ���� ���θ�� �غ� �гη� ����
    public void SetPanelBeforeStudying()
    {
        // �г� ����
        panelTop.SetActive(true);
        panelMiddle.SetActive(true);
        panelBottom.SetActive(true);
        panelMusic.SetActive(true);

        timerScr.IsOnPomodoro = false;
        panelInfinityStudying.SetActive(false);
        panelInfinityBeforeStudying.SetActive(true);
        panelPomodoroBeforeStudying.SetActive(false);
        panelPomodoroStudying.SetActive(false);
        buttonStudyMode.SetActive(true);
        imageStudying.SetActive(false);
        textInfinityTimer.SetActive(true);
        textPomodoroTimer.SetActive(false);
        timerScr.SetTimerText();
    }

    public void SetTopBarContent()
    {
        if(buttonStudyMode.activeSelf == true)
        {
            buttonStudyMode.SetActive(false);
        }
        else
        {
            buttonStudyMode.SetActive(true);
        }

        if(imageStudying.activeSelf == true)
        {
            imageStudying.SetActive(false);
        }
        else
        {
            imageStudying.SetActive(true);
        }
    }
}
