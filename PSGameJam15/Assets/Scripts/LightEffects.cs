using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffects : MonoBehaviour
{
    public enum Effect
    {
        None,
        Speed,
        NoGravity,
        JumpBoost,
        ReverseGravity,
    }

    public Effect effect;

    void OnTriggerEnter2D(Collider2D other)
    {
        EffectObject effectObject = other.GetComponent<EffectObject>();
        if (effectObject != null )
        {
            effectObject.SetEffect(effect);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        EffectObject effectObject = other.GetComponent<EffectObject>();
        if (effectObject != null)
        {
            effectObject.RemoveEffect(effect);
        }
    }
}