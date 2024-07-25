using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material defaultMat;
    public Material outlineMat;

    public new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        outlineMat.mainTexture = renderer.sprite.texture;
        renderer.material = defaultMat;
    }

    public void Highlight()
    {
        renderer.material = outlineMat;
    }

    public void Unhighlight()
    {
        renderer.material = defaultMat;
    }
}
