using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(false, true, LogBehaviour.Verbose).SetCapacity(200, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        StartCoroutine(Scale());
    }

    public IEnumerator Scale()
    {
        transform.DOScale(4.5f, 0.05f);

        yield return new WaitForSeconds(0.05f);

        transform.DOScale(4.0f, 0.05f);
    }
}
