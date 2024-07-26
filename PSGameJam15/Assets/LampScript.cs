using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectConstants;

public class LampScript : Interactable
{
    [SerializeField] private Hotbar hotbar;
    [SerializeField] private AudioManager audioManager;

    private Effect selectedEffect = Effect.None;

    private void OnMouseOver()
    {
        selectedEffect = hotbar.getCurrentEffect();
        if (selectedEffect != Effect.None)
        {
            Debug.Log(selectedEffect);
            Highlight();
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GameObject gameObject = transform.gameObject;
                LightEffects lampEffect = gameObject.GetComponentInChildren<LightEffects>();
                if (selectedEffect != lampEffect.effect)
                {
                    audioManager.playLightEffect();
                }
                lampEffect.UpdateEffect(selectedEffect);
                Interactable lamp = gameObject.GetComponent<Interactable>();
                lamp.Highlight();
            }
        }
        else
        {
            Unhighlight();
        }
    }

    private void OnMouseExit()
    {
        Unhighlight();
    }
}
