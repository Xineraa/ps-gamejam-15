using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextDisplayHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> texts;
    [SerializeField] private float fadeConstant = 2.0f;
    [SerializeField] private LevelHandler levelHandler;

    private int index = 0;
    
    void Start()
    {
        StartCoroutine(ShowText(texts[index]));
    }

    IEnumerator ShowText (GameObject text)
    {
        TextMeshPro textMesh = text.GetComponent<TextMeshPro>();
        float alpha = textMesh.color.a;
        while (textMesh.color.a < 1)
        {
            alpha += Time.deltaTime * fadeConstant;
            Color bColor = textMesh.color;
            Color color = new Color(bColor.r, bColor.g, bColor.b, alpha);
            textMesh.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(4);
        alpha = textMesh.color.a;
        while (textMesh.color.a > 0)
        {
            alpha -= Time.deltaTime * fadeConstant;
            Color bColor = textMesh.color;
            Color color = new Color(bColor.r, bColor.g, bColor.b, alpha);
            textMesh.color = color;
            yield return null;
        }
        index++;
        yield return new WaitForSeconds(2);
        if (index == texts.Count)
        {
            StartCoroutine(levelHandler.DoFadeOut(1));
        } else
        {
            StartCoroutine(ShowText(texts[index]));
        }
    }
}
