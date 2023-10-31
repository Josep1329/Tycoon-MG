using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image blackBG;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void CargarEscena(int _scene)
    {
        StartCoroutine(FadeOut(_scene));
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator FadeIn()
    {
        Color c = blackBG.color;
        for (float alpha = 1f; alpha >= 0f; alpha -= 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackBG.color = c;
            yield return null;
        }


    }

    IEnumerator FadeOut(int _scene)
    {
        Color c = blackBG.color;
        for(float alpha = 0f; alpha <= 1f; alpha += 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackBG.color = c;
            yield return null;
        }

        SceneManager.LoadScene(_scene);
    }
}
