using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LightEffects;

public class EffectObject : MonoBehaviour
{
    public PlayerMovement player;
    public EffectConstants effectConstants;
    public CharacterController2D characterController;
    private List<Effect> baseEffects;
    private List<Effect> comboEffects;

    private void Start()
    {
        baseEffects = new List<Effect>();
        comboEffects = new List<Effect>();
    }

    public void SetEffect (Effect effect)
    {
        ResetEffects();
        baseEffects.Add(effect);
        List<Effect> activeCombos = CombosActive();
        List<Effect> effectsToSet = new List<Effect>();
        if (activeCombos.Count > 0)
        {
            printList("Combos: ", activeCombos);
            foreach (Effect comboEffect in activeCombos)
            {
                comboEffects.Add(comboEffect);
                effectsToSet.Add(comboEffect);
                foreach (Effect comboPart in ComboParts(comboEffect))
                {
                    baseEffects.Remove(comboPart);
                }
            }

        } else
        {
            effectsToSet.Add(effect);
        }

        foreach (Effect effectToSet in effectsToSet)
        {
            printList("Setting effects: ", effectsToSet);
            switch (effectToSet)
            {
                case Effect.Speed:
                    {
                        if (player != null)
                        {
                            player.Speed += effectConstants.speed;
                        }
                        break;
                    }
                case Effect.NoGravity:
                    {
                        if (gameObject != null)
                        {
                            gameObject.GetComponent<Rigidbody2D>().gravityScale = effectConstants.noGravity;
                        }
                        break;
                    }
                case Effect.JumpBoost:
                    {
                        if (characterController != null)
                        {
                            characterController.m_JumpForce = effectConstants.jumpBoost;
                        }
                        break;
                    }
                case Effect.ReverseGravity:
                    {
                        gameObject.GetComponent<Rigidbody2D>().gravityScale = effectConstants.reverseGravity;
                        break;
                    }
            }
        }
    }

    public void RemoveEffect (Effect effect)
    {
        ResetEffects();

        if (comboEffects.Count > 0)
        {
            printList("Combos: ", comboEffects);
            List<Effect> comboEffectsCopy = new List<Effect>(comboEffects);
            foreach (Effect comboEffect in comboEffectsCopy)
            {
                if (ComboParts(comboEffect).Contains(effect))
                {
                    comboEffects.Remove(comboEffect);
                    List<Effect> comboParts = ComboParts(comboEffect);
                    printList("Combos parts: ", comboParts);
                    comboParts.Remove(effect);
                    Debug.Log("Setting effect: " + comboParts[0]);
                    SetEffect(comboParts[0]);
                }
            }
        } else
        {
            baseEffects.Remove(effect);
        }
    }

    private void printList (string pretext, List<Effect> effects)
    {
        string stringToPrint = "";
        foreach (Effect effect in effects)
        {
            stringToPrint += effect.ToString();
        }
        Debug.Log(pretext + stringToPrint);
    }

    private void ResetEffects ()
    {
        if (player != null)
        {
            player.Speed = effectConstants.defaultSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().gravityScale = effectConstants.normalGravity;
        if (characterController != null)
        {
            characterController.m_JumpForce = effectConstants.defaultJumpHeight;
        }
    }

    private List<Effect> CombosActive()
    {
        List<Effect> comboEffectsActive = new List<Effect>();
        if (baseEffects.Contains(Effect.NoGravity) && baseEffects.Contains(Effect.JumpBoost))
        {
            comboEffectsActive.Add(Effect.ReverseGravity);
        }
        return comboEffectsActive;
    }

    private List<Effect> ComboParts(Effect effect)
    {
        switch (effect)
        {
            case Effect.ReverseGravity:
                {
                    return new List<Effect> { Effect.NoGravity, Effect.JumpBoost };
                }
        }
        return null;
    }
}
