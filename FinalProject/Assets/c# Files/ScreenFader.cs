using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeTime = 1;


    void Start(){
        FadeToClear();

    }

    void FadeToClear(){
        fadeImage.color = fadeColor;
        StartCoroutine(FadeToClearRoutine());
        IEnumerator FadeToClearRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                yield return null;
                timer+=Time.deltaTime;
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f -(timer/fadeTime));
            }
            fadeImage.color = Color.clear;
        }
    }

}