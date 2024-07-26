using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Door door;
    [SerializeField] private GameObject LaserStart;
    [SerializeField] private GameObject LaserReceptor;
    private bool hitting = false;
    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(LaserStart.transform.position, LaserStart.transform.rotation*Vector2.right);
        lineRenderer.SetPosition(0, LaserStart.transform.position);
        lineRenderer.SetPosition(1, hit.point);
        if (hit.collider.tag == "LaserReceptor" && !hitting)
        {
            door.OpenDoor();
            hitting = true;
        }
        if (hit.collider.tag != "LaserReceptor")
        {
            door.CloseDoor();
            hitting = false;
        }
    }
}
