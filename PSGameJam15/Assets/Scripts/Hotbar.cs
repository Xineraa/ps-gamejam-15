using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{

    public int SlotIndex;
    private Slot slot;
    private Slot activeSlot;
    private List<Effect> effects;
    public Effect currentEffect = Effect.None;
    public enum Effect
    {
        None,
        Speed,
        NoGravity,
        JumpBoost,
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Slot>().isActive = true;
        effects = new List<Effect>();
    }
    void ChooseEffect(int slot)
    {
        effects.Clear();
        if (slot == 0)
        {
            effects.Add(Effect.None);
        }
        if (slot == 1)
        {
            effects.Add(Effect.Speed);
        }
        if (slot == 2)
        {
            effects.Add(Effect.NoGravity);
        }
        if (slot == 3)
        {
            effects.Add(Effect.JumpBoost);
        }
    }
    public void EffectChanger()
    {
        foreach (Effect effect in effects)
        {
            switch (effect)
            {
                case Effect.None:
                    {
                        currentEffect = Effect.None;
                    }
                    break;
                case Effect.Speed:
                    {
                        currentEffect = Effect.Speed;
                    }
                    break;
                case Effect.NoGravity:
                    {
                        currentEffect = Effect.NoGravity;
                    }
                    break;
                case Effect.JumpBoost:
                    {
                        currentEffect = Effect.JumpBoost;
                    }
                    break;
            }
        }
    }
    public Effect getCurretEffect()
    {
        return currentEffect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.GetChild(0).GetComponent<Slot>().activated)
        {
            SlotIndex = 0;
            ActiveSlot(SlotIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.GetChild(1).GetComponent<Slot>().activated)
        {
            SlotIndex = 1;
            ActiveSlot(SlotIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.GetChild(2).GetComponent<Slot>().activated)
        {
            SlotIndex = 2;
            ActiveSlot(SlotIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.GetChild(3).GetComponent<Slot>().activated)
        {
            SlotIndex = 3;
            ActiveSlot(SlotIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.GetChild(4).GetComponent<Slot>().activated)
        {
            SlotIndex = 4;
            ActiveSlot(SlotIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && transform.GetChild(5).GetComponent<Slot>().activated)
        {
            SlotIndex = 5;
            ActiveSlot(SlotIndex);
        }

    void ActiveSlot(int Slot)
        {
            var count = this.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                transform.GetChild(i).GetComponent<Slot>().isActive = false;
            }
            activeSlot = transform.GetChild(Slot).GetComponent<Slot>();
            activeSlot.isActive = true;
            ChooseEffect(Slot);
            EffectChanger();
        }
    }
}
