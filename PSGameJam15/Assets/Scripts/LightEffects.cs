using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffects : MonoBehaviour

{
    public PlayerMovement player;
    public EffectConstants effectConstants;

    public enum Effect
    {
        Speed,
        LowGravity,
    }

    public Effect effect;

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (effect)
        {
            case Effect.Speed:
            {
                player.Speed += effectConstants.speed;
                break;
            }
            case Effect.LowGravity:
            {
                player.SetGravity(effectConstants.lowGravity);
                break;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        switch (effect)
        {
            case Effect.Speed:
            {
                player.Speed -= effectConstants.speed;
                break;
            }
            case Effect.LowGravity:
            {
                player.SetGravity(effectConstants.normalGravity);
                break;
            }
        }
    }
}
