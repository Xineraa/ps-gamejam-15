using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EffectConstants;

public class Hotbar : MonoBehaviour
{

    public int SlotIndex;
    public Effect currentEffect = Effect.None;

    public Effect getCurrentEffect()
    {
        return currentEffect;
    }

    // Update is called once per frame
    void Update()
    {
        selectSlot();
    }

    public int selectSlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Input.GetKeyDown((i+1).ToString()))
            {
                Slot[] slots = GetComponentsInChildren<Slot>();
                slots[i].setActive(true);
                foreach (Slot slot in slots) {
                    if (slot != slots[i])
                        slot.setActive(false);
                }
                Debug.Log(currentEffect);
                currentEffect = slots[i].getEffect();
            }
        }
        return -1;
    }
}
