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
        NoGravity,
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
            case Effect.NoGravity:
            {
                if (other.gameObject != null)
                {
                    other.gameObject.GetComponent<Rigidbody2D>().gravityScale = effectConstants.noGravity;
                }
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
            case Effect.NoGravity:
            {
                if (other.gameObject != null)
                {
                    other.gameObject.GetComponent<Rigidbody2D>().gravityScale = effectConstants.normalGravity;
                }
                break;
            }
        }
    }
}
