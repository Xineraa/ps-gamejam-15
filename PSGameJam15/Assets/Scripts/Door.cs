using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite doorClosed;
    [SerializeField] private Sprite doorOpen;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D trigger;
    [SerializeField] private AudioManager audioManager;

    private SpriteRenderer doorRenderer;
    private bool shouldClose = false;
    private int amountInDoor = 0;

    // Start is called before the first frame update
    void Start()
    {
        doorRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldClose)
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        audioManager.playDoorEffect(true);
        boxCollider.enabled = false;
        doorRenderer.sprite = doorOpen;
    }

    public void CloseDoor()
    {
        if (amountInDoor > 0)
        {
            shouldClose = true;
        } else
        {
            audioManager.playDoorEffect(false);
            shouldClose = false;
            boxCollider.enabled = true;
            doorRenderer.sprite = doorClosed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        amountInDoor++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        amountInDoor--;
    }
}
