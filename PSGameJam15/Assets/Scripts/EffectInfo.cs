using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectConstants;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EffectInfo", order = 1)]

public class EffectInfo : ScriptableObject
{
    public Effect effect;
    public Sprite icon;
    public Color color;

    public Sprite getIcon()
    {
        return icon;
    }

    public Color GetColor()
    {
        return color;
    }
}
