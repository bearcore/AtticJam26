using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    public float Delay = 2f;
    public GameObject ShotPrefab;
    public GameObject EnableAfterFirstShot;
    public Transform ShotSpawnPosition;

    public CinemachineImpulseSource ScreenshakeSource;
    [SerializeField] private float MaxScreenshakeDistance = 6f;
    [SerializeField] private float ScreenshakeStrength = 0.3f;

    private float _curDelay = 0f;
    private Transform _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main.transform;
    }

    void OnEnable()
    {
        _curDelay = Random.Range(0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        _curDelay -= Time.deltaTime;
        if(_curDelay <= 0f)
        {
            var shot = Instantiate(ShotPrefab, ShotSpawnPosition);
            _curDelay = Delay;
            Destroy(shot, 0.1f);
            EnableAfterFirstShot.SetActive(true);
            FireWhiz();
        }
    }

    // Call this when the bullet passes close (e.g., on near-miss)
    public void FireWhiz()
    {
        float d = Vector3.Distance(ScreenshakeSource.transform.position, _camera.position);
        if (d > MaxScreenshakeDistance) return;

        // Scale strength by distance (closer = stronger)
        float t = 1f - (d / MaxScreenshakeDistance);
        ScreenshakeSource.GenerateImpulse(ScreenshakeStrength * t); // simplest API
    }
}
