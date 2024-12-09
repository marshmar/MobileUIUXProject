using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroList : MonoBehaviour
{
    // 설정한 뽀모도로 데이터를 저장할 게임오브젝트 리스트
    private List<GameObject> pomodoroSettingList;
    // 뽀모도로 오브젝트 프리팹
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
