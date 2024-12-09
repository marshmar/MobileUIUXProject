using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPSData : MonoBehaviour
{
    public PomodoroData pomodoroData;

    [SerializeField]
    private GameObject focusImage;
    [SerializeField]
    private GameObject restImage;
    [SerializeField]
    private GameObject longRestImage;

    private List<GameObject> instantiatedFocusObjects = new List<GameObject>();
    private List<GameObject> instantiatedRestObjects = new List<GameObject>();
    private List<GameObject> instantiatedLongRestObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteData()
    {
        foreach (Transform child in focusImage.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in restImage.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in longRestImage.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void SetData()
    {

        instantiatedFocusObjects.Clear();
        List<GameObject> tempList = pomodoroData.GetFocusTimeList();
        for(int i = 0; i < tempList.Count; i++)
        {
            GameObject instance = Instantiate(tempList[i], focusImage.transform);
            instantiatedFocusObjects.Add(instance);
        }

        instantiatedRestObjects.Clear();
        tempList = pomodoroData.GetRestTimeList();
        for (int i = 0; i < tempList.Count; i++)
        {
            GameObject instance = Instantiate(tempList[i], restImage.transform);
            instantiatedRestObjects.Add(instance);
        }

        instantiatedLongRestObjects.Clear();
        tempList = pomodoroData.GetLongRestTimeList();
        for (int i = 0; i < tempList.Count; i++)
        {
            GameObject instance = Instantiate(tempList[i], longRestImage.transform);
            instantiatedLongRestObjects.Add(instance);
        }
    }
}
