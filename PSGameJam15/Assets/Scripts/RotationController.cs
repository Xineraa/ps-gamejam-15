using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class RotationController : MonoBehaviour
{

    [SerializeField]
    private float distToShow = 5f;

    private SpriteRenderer sprRenderer;
    public GameObject lampObject;

    private bool rotating = false;

    private void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        lampObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rotating = false;
        }

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(mouseWorldPos, lampObject.transform.position);
        if (dist < distToShow || rotating == true)
        {
            sprRenderer.enabled = true;
        } else
        {
            sprRenderer.enabled = false;
        }

        if (rotating)
        {
            RotateLamp(mouseWorldPos);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotating = true;
        }
    }

    private void RotateLamp(Vector2 mouseWorldPos)
    {
        Debug.Log(mouseWorldPos);
        Vector2 lampPos = lampObject.transform.position;
        Vector2 positionDiff = mouseWorldPos - lampPos;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, -90) * positionDiff;
    
        lampObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget.normalized);
    }
}
