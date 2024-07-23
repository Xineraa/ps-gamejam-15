using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public float cooldown = 4f;
    public float doorOpenTime = 2f;
    public Door door;
    private bool canPress;
    private bool onCooldown = false;

    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();
            Invoke("CloseDoor", doorOpenTime);
            Invoke("ResetCooldown", cooldown);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canPress = onCooldown ? false : true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
    }

    private void CloseDoor()
    {
        door.CloseDoor();
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }
}
