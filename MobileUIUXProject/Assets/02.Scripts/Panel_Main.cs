using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Main : MonoBehaviour
{
    private Timer timerScr;

    [SerializeField]
    private GameObject panelBottom_Bar;
    [SerializeField]
    private GameObject panelInfinityStudying;
    [SerializeField]
    private GameObject panelInfinityBeforeStudying;
    [SerializeField]
    private GameObject imageStudying;
    [SerializeField]
    private GameObject buttonStudyMode;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        timerScr = GetComponentInParent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfinityPanel()
    {
        if(timerScr.AccumulatedTime >= 0)
        {
            panelBottom_Bar.SetActive(true);
            panelInfinityStudying.SetActive(true);
            panelInfinityBeforeStudying.SetActive(false);
            buttonStudyMode.SetActive(false);
            imageStudying.SetActive(true);
            startButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        else
        {
            panelBottom_Bar.SetActive(false);
        }
    }

    public void SetPanelBeforeStudying()
    {
        panelBottom_Bar.SetActive(false);
        panelInfinityStudying.SetActive(false);
        panelInfinityBeforeStudying.SetActive(true);
        buttonStudyMode.SetActive(true);
        imageStudying.SetActive(false);
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
