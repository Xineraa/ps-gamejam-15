using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : Interactable
{
    public Transform spawnPoint;
    public GameObject cube;
    public float cooldown = 2f;
    public Vector2 speed;
    private bool canPress;
    private bool onCooldown = false;
    private GameObject spawnedCube;
    [SerializeField] private AudioManager audioManager;

    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            if (spawnedCube != null)
            {
                Destroy(spawnedCube);
            }
            spawnedCube = Instantiate(cube, spawnPoint.position, Quaternion.identity);
            spawnedCube.GetComponent<Rigidbody2D>().AddForce(speed);
            audioManager.playButtonClick();
            onCooldown = true;
            canPress = false;
            Invoke("ResetCooldown", cooldown);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canPress = onCooldown ? false : true;
        if (canPress)
            base.Highlight();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.Unhighlight();
        canPress = false;
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }
}
