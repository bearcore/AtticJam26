using UnityEngine;

public class MoveObjectEveryFrame : MonoBehaviour
{
    public Vector3 LocalVelocity = new Vector3(0f, 1f, 0f);

    // Update is called once per frame
    void Update()
    {
        var scaled = LocalVelocity * Time.deltaTime;
        transform.localPosition += scaled;
    }
}
