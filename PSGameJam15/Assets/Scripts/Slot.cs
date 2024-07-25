using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;
using static EffectConstants;

public class Slot : MonoBehaviour
{
    public bool activated;
    public bool isActive;
    public Effect effect;
    public Sprite defaultSprite;
    public Sprite selectedSprite;
    public Image effectIcon;

    private void Start()
    {
        effectIcon.sprite = getEffectInfo(effect).icon;
    }

    public Effect getEffect()
    {
        return effect;
    }

    public void setActive(bool activate)
    {
        isActive = activate;
        GetComponent<Image>().overrideSprite = activate ? selectedSprite : defaultSprite;
    }
}

