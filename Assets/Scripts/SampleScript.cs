using UnityEngine;

public class SampleScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 100f);
    }
}
