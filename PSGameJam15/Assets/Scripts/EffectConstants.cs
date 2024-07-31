using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectConstants : MonoBehaviour
{
    public float defaultSpeed = 5.0f;
    public float speed = 3.0f;
    public float reverseGravity = -1f;
    public float noGravity = 0f;
    public float lowGravity = 0.5f;
    public float normalGravity = 1.0f;
    public float jumpBoost = 200.0f;
    public float defaultJumpHeight = 100f;
    public float HighGravity = 1.5f;

    public EffectInfo[] effectInfos;

    public static Dictionary<Effect, EffectInfo> effectToInfo = new();

    private void Awake()
    {
        foreach (EffectInfo info in effectInfos)
        {
            effectToInfo.Add(info.effect, info);
        }
    }

    public enum Effect
    {
        None,
        Speed,
        NoGravity,
        JumpBoost,
        ReverseGravity,
        Mini,
        HighGravity,
    }

    public static EffectInfo getEffectInfo(Effect effect)
    {
        return effectToInfo[effect];
    }
}
