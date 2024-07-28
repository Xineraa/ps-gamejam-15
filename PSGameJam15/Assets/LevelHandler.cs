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
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(DoFadeOut(1));
        }
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

    public IEnumerator DoFadeOut(int scene)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
        yield return null;
    }
}
