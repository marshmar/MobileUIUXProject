using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroList : MonoBehaviour
{
    // ������ �Ǹ𵵷� �����͸� ������ ���ӿ�����Ʈ ����Ʈ
    private List<GameObject> pomodoroSettingList;
    // �Ǹ� �����͸� �����ϴ� ����Ʈ
    private List<PomodoroData> pomodoroDataList;

    // �Ǹ𵵷� ������Ʈ ������
    [SerializeField]
    private GameObject pomodoroDataPrefab;
    [SerializeField]
    private Transform contentTransform;
    private void Awake()
    {
        pomodoroSettingList = new List<GameObject>();
        pomodoroDataList = new List<PomodoroData>();

        // �Ǹ𵵷� ������ 1 ����
        GameObject tempObj = Instantiate(pomodoroDataPrefab, contentTransform);
        if(tempObj.TryGetComponent<PomodoroData>(out PomodoroData pomodoroData1))
        {
            pomodoroDataList.Add(pomodoroData1);
        }
        pomodoroSettingList.Add(tempObj);
        // �Ǹ𵵷� ������ 2 ����
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
