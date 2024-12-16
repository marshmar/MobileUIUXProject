using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : MonoBehaviour
{
    [SerializeField]
    private GameObject pomodoroImages;
    [SerializeField]
    private Image pomodoroImagePrefab;
    [SerializeField]
    private Image circleImage;
    [SerializeField]
    private Image restCircleImage;

    private int pomodoroCount;
    private int basePomodoroCount;
    private int completedPomodoroCount;
    private int totalDailyPomodoroCount;
    private List<Image> pomodoroList;

    public int BasePomodoroCount { get => basePomodoroCount; set => basePomodoroCount = value; }
    public int CompletedPomodoroCount { get => completedPomodoroCount; set => completedPomodoroCount = value; }
    public int TotalDailyPomodoroCount { get => totalDailyPomodoroCount; set => totalDailyPomodoroCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        completedPomodoroCount = 0;
        totalDailyPomodoroCount = 0;
        basePomodoroCount = 4;
        pomodoroCount = basePomodoroCount;
        pomodoroList = new List<Image>(pomodoroCount);
        SetImage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePomodoroCount(int count)
    {
        basePomodoroCount = count;
        pomodoroCount = basePomodoroCount;
        SetImage();
    }

    public void SetImage()
    {
        int listCount = pomodoroList.Count;
/*        if(pomodoroCount < listCount)
        {
            for(int i = 0; i < listCount - pomodoroCount; i++)
            {
                Destroy(pomodoroList[i]);
                pomodoroList.RemoveAt(pomodoroList.Count);
            }
        }
        else
        {
            for(int i = 0; i < pomodoroCount - listCount; i++)
            {
                pomodoroList.Add(Instantiate(pomodoroImagePrefab, pomodoroImages.transform));
            }
        }*/
    }

    public void EndPomodoro()
    {
        ChangeImageColor(pomodoroList[completedPomodoroCount], "#D58936");
        completedPomodoroCount++;
        totalDailyPomodoroCount++;
        
        if(completedPomodoroCount >= pomodoroCount)
        {
            completedPomodoroCount = 0;
            for(int i = 0; i < pomodoroList.Count; i++)
            {
                ChangeImageColor(pomodoroList[i], "#D9D9D9");
            }
        }
    }

    public void SetCircleImage(float time)
    {
        circleImage.fillAmount = 1.0f - time;
    }

    public void SetRestCircleImage(float time)
    {
        restCircleImage.fillAmount = 1.0f - time;
    }

    public void ChangeImageColor(Image image, string hexCode)
    {
        if(ColorUtility.TryParseHtmlString(hexCode, out Color color))
        {
            image.color = color;
        }
    }

    public void SetPomodoroImageGameobject(bool value)
    {
        pomodoroImages.SetActive(value);
    }
}
