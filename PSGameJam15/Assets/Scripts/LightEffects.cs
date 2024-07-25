using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static EffectConstants;

public class LightEffects : MonoBehaviour
{
    public Effect effect;
    private List<EffectObject> objects = new List<EffectObject>();

    private Light2D light;

    private void Start()
    {
        light = GetComponent<Light2D>();
        light.color = getEffectInfo(effect).color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EffectObject effectObject = other.GetComponent<EffectObject>();
        objects.Add(effectObject);
        if (effectObject != null )
        {
            effectObject.SetEffect(effect);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        EffectObject effectObject = other.GetComponent<EffectObject>();
        objects.Remove(effectObject);
        if (effectObject != null)
        {
            effectObject.RemoveEffect(effect);
        }
    }

    public void UpdateEffect (Effect setEffect)
    {
        foreach (EffectObject obj in objects) {
            obj.RemoveEffect(effect);
            obj.SetEffect(setEffect);
        }
        light.color = getEffectInfo(setEffect).color;
        effect = setEffect;
    }
}