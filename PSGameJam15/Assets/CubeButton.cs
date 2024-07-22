using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject cube;
    public float cooldown = 2f;
    public Vector2 speed;
    private bool canPress;
    private bool onCooldown = false;

    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            GameObject spawnedCube = Instantiate(cube, spawnPoint.position, Quaternion.identity);
            spawnedCube.GetComponent<Rigidbody2D>().AddForce(speed);
            onCooldown = true;
            canPress = false;
            Invoke("ResetCooldown", cooldown);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canPress = onCooldown ? false : true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }
}
