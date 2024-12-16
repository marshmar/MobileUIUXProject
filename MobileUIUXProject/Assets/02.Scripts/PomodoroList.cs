using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroList : MonoBehaviour
{
    // 설정한 뽀모도로 데이터를 저장할 게임오브젝트 리스트
    private List<GameObject> pomodoroSettingList;
    // 뽀모돌 데이터를 저장하는 리스트
    private List<PomodoroData> pomodoroDataList;

    // 뽀모도로 오브젝트 프리팹
    [SerializeField]
    private GameObject pomodoroDataPrefab;
    [SerializeField]
    private Transform contentTransform;
    private void Awake()
    {
        pomodoroSettingList = new List<GameObject>();
        pomodoroDataList = new List<PomodoroData>();

        // 뽀모도로 데이터 1 생성
        GameObject tempObj = Instantiate(pomodoroDataPrefab, contentTransform);
        if(tempObj.TryGetComponent<PomodoroData>(out PomodoroData pomodoroData1))
        {
            pomodoroDataList.Add(pomodoroData1);
        }
        pomodoroSettingList.Add(tempObj);
        // 뽀모도로 데이터 2 생성
        tempObj = Instantiate(pomodoroDataPrefab, contentTransform);
        if (tempObj.TryGetComponent<PomodoroData>(out PomodoroData pomodoroData2))
        {
            pomodoroDataList.Add(pomodoroData2);
        }
        pomodoroSettingList.Add(tempObj);
    }


    public void AddPomodoroData()
    {
        GameObject tempObj = Instantiate(pomodoroDataPrefab, contentTransform);
        tempObj.transform.SetSiblingIndex(0);
        pomodoroSettingList.Add(tempObj);
        if (tempObj.TryGetComponent<PomodoroData>(out PomodoroData pomodoroData))
        {
            pomodoroDataList.Add(pomodoroData);
        }
    }

    public void RemoveData(GameObject removeObj, PomodoroData pomodoroData)
    {
        pomodoroSettingList.Remove(removeObj);
        pomodoroDataList.Remove(pomodoroData);
    }

    public void EnableImages()
    {
        foreach(GameObject data in pomodoroSettingList)
        {
            if(data.TryGetComponent<HoldingComponent>(out HoldingComponent hc))
            {
                hc.EnableImage();
            }
        }
    }

    public void DisableImages()
    {
        foreach (GameObject data in pomodoroSettingList)
        {
            if (data.TryGetComponent<HoldingComponent>(out HoldingComponent hc))
            {
                hc.DisableImage();
            }
        }
    }
}
