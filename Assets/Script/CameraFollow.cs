using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTarget;
    public Transform Camera;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTarget.position, Time.deltaTime * 5f);
        transform.rotation = PlayerTarget.transform.rotation;
    }
}