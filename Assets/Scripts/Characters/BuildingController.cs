using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField]
    int fadeSpeed;
    private bool isFading = false;
    private SpriteRenderer sprite;
    private Collider blocking;
    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        blocking = transform.GetChild(1).GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFading) {
            Fade();
        } else {
            UnFade();
        }
    }

    void FixedUpdate() {
        Collider[] colliders = Physics.OverlapBox(blocking.bounds.center, blocking.bounds.extents, Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                isFading = true;
                break;
            }
            isFading = false;
        }
    }

    private void Fade() {
        if(sprite.color.a > .3f) sprite.color = new Color(sprite.color.r,
                                                        sprite.color.g,
                                                        sprite.color.b,
                                                        sprite.color.a - .1f * Time.deltaTime * fadeSpeed);
    }

    private void UnFade() {
        if(sprite.color.a < 1.0f) sprite.color = new Color(sprite.color.r,
                                                        sprite.color.g,
                                                        sprite.color.b,
                                                        sprite.color.a + .1f * Time.deltaTime * fadeSpeed);
    }
}
