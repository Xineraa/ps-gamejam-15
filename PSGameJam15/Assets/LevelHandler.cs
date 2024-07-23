using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private float fadeConstant = 2.0f;
    private void Start()
    {
        StartCoroutine(DoFadeIn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeIn()
    {
        Debug.Log("Starting");
        float alpha = blackScreen.color.a;
        while (blackScreen.color.a > 0)
        {
            alpha -= Time.deltaTime * fadeConstant;
            Color bColor = blackScreen.color;
            Color color = new Color(bColor.r, bColor.g, bColor.b, alpha);
            blackScreen.color = color;
            yield return null;
        }
        yield return null;
    }

    IEnumerator DoFadeOut()
    {
        float alpha = blackScreen.color.a;
        while (blackScreen.color.a < 1)
        {
            alpha += Time.deltaTime * fadeConstant;
            Color bColor = blackScreen.color;
            Color color = new Color(bColor.r, bColor.g, bColor.b, alpha);
            blackScreen.color = color;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
