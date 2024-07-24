using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Hotbar hotbar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.tag == ("Lamp"))
                {
                    GameObject gameObject = hit.transform.gameObject;
                    LightEffects lampEffect = gameObject.GetComponent<LightEffects>();
                    lampEffect.effect = (LightEffects.Effect)hotbar.getCurretEffect();
                }
            }
        }
    }
}
