using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource Layer1;
    public AudioSource Layer2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Layer1.gameObject.SetActive(GameManager.WaitingForStartClick);
        Layer2.gameObject.SetActive(!GameManager.WaitingForStartClick);
        GameManager.Instance.OnDidFirstClick.AddListener(OnDidFirstClick);
    }
    
    private void OnDidFirstClick()
    {
        Layer1.gameObject.SetActive(false);
        Layer2.gameObject.SetActive(true);
    }
}
