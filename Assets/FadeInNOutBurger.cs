using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRuby.Tween;
using System;
using System.Linq;



public class CrossfadeUI : MonoBehaviour
{
    public float targetOn = 5f; // Target X position
    public float targetOff = 1f;
    public float duration = 2f; // Duration of the movement
    public GameObject[] slides;
    public int index = 0;

    void Start()
    {
        // Move only in the X direction
        //LeanTween.moveX(gameObject, targetX, duration).setEase(LeanTweenType.linear);
    }

    private void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if (index == slides.Length - 1)
            {
                SceneManager.LoadScene("Level01");
                //Debug.Log("switch scene");
            }
            LeanTween.moveX(slides[index], targetOff, duration/2).setEase(LeanTweenType.linear);
            if (index < slides.Length - 1)
            {
                
                LeanTween.moveX(slides[index+1], targetOn, duration).setEase(LeanTweenType.linear);
            }
            
            index++;
        }
    }
}


