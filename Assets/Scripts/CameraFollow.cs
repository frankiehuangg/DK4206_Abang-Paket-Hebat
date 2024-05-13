using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing = 10f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}