using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Panel_Group : MonoBehaviour
{
    [SerializeField]
    private TMP_Text topText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        topText.text = text;
    }

    
}
