using System.Collections.Generic;
using UnityEngine;

public class AmbienceHandler : MonoBehaviour
{
    public List<GameObject> BeforeIntro;
    public List<GameObject> AfterIntro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BeforeIntro.ForEach(x => x.SetActive(GameManager.WaitingForStartClick));
        AfterIntro.ForEach(x => x.SetActive(!GameManager.WaitingForStartClick));
        GameManager.Instance.OnDidFirstClick.AddListener(OnDidFirstClick);
    }
    
    private void OnDidFirstClick()
    {
        BeforeIntro.ForEach(x => x.SetActive(GameManager.WaitingForStartClick));
        AfterIntro.ForEach(x => x.SetActive(!GameManager.WaitingForStartClick));
    }
}
