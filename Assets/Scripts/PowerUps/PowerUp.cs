using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    public Image digitImage;
    public Sprite[] numberSprites;

    protected int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        getCount();
        SetTimerSprites();
    }

    // Update is called once per frame
    void Update()
    {
        int prevCount = count;
        getCount();
        if (count != prevCount) SetTimerSprites();
    }

    protected virtual void getCount()
    {
        count = 0;
    }

    private void SetTimerSprites()
    {
        int idx = count > 3 ? 3 : count;
        digitImage.sprite = numberSprites[idx];
    }

    public virtual void Activate()
    {

    }
}
