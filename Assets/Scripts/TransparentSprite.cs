using UnityEngine;

public class TransparentSprite : MonoBehaviour
{
    public Transform player;

    private Vector3 direction;
    private int buildingMask;

    void Start()
    {
        buildingMask = LayerMask.GetMask("Buildings");
        direction = player.position - transform.position;
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, direction.magnitude, buildingMask))
        {
            SpriteRenderer renderer = hit.collider.GetComponentInChildren<SpriteRenderer>();

            Debug.Log(hit.collider);

            if (renderer != null)
            {
                Color spriteColor = renderer.color;
                spriteColor.a = 0.8f;
                renderer.color = spriteColor;
            }
        }
    }
}