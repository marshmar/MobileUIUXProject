using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroList : MonoBehaviour
{
    // ������ �Ǹ𵵷� �����͸� ������ ���ӿ�����Ʈ ����Ʈ
    private List<GameObject> pomodoroSettingList;
    // �Ǹ𵵷� ������Ʈ ������
    [SerializeField]
    private GameObject pomodoroDataPrefab;
    [SerializeField]
    private Transform contentTransform;
    private void Awake()
    {
        pomodoroSettingList = new List<GameObject>();
        pomodoroSettingList.Add(Instantiate(pomodoroDataPrefab, contentTransform));
        pomodoroSettingList.Add(Instantiate(pomodoroDataPrefab, contentTransform));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPomodoroData()
    {
        pomodoroSettingList.Add(Instantiate(pomodoroDataPrefab, contentTransform));
    }

    public void RemoveData(GameObject removeObj)
    {
        pomodoroSettingList.Remove(removeObj);
    }
}
