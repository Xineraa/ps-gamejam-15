using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DoorButton : Interactable
{
    public float cooldown = 4f;
    public float doorOpenTime = 2f;
    public Door door;
    private bool canPress;
    private bool onCooldown = false;
    private bool onButton = false;

    [SerializeField] private AudioManager audioManager;

    private void Update()
    {
        if (canPress && !onCooldown && Input.GetKeyDown(KeyCode.E))
        {
            onCooldown = true;
            door.OpenDoor();
            base.Unhighlight();
            audioManager.playButtonClick();
            Invoke("CloseDoor", doorOpenTime);
            Invoke("ResetCooldown", cooldown);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canPress = onCooldown ? false : true;
        if (canPress)
            base.Highlight();
        onButton = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canPress = onCooldown ? false : true;
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
