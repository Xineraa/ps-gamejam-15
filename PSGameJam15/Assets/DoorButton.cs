using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorButton : Interactable
{
    public float cooldown = 4f;
    public float doorOpenTime = 2f;
    public Door door;
    private bool canPress;
    private bool onCooldown = false;
    private bool onButton = false;

    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();
            base.Unhighlight();
            Invoke("CloseDoor", doorOpenTime);
            Invoke("ResetCooldown", cooldown);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.Highlight();
        canPress = onCooldown ? false : true;
        onButton = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.Unhighlight();
        canPress = false;
        onButton = false;
    }

    private void CloseDoor()
    {
        door.CloseDoor();
    }

    private void ResetCooldown()
    {
        onCooldown = false;
        if (onButton)
            base.Highlight();
    }
}
