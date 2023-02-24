using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imageshow : MonoBehaviour
{
    [SerializeField]
    private Texture[] imageArray = null;   
    [SerializeField]
    int screenWidth = 1000; 
    [SerializeField]
    int screenHeight = 1000;
    [SerializeField]
    private int currentImage = 0;

    private float targetTime;


    private void OnGUI()
    {
        Rect imageRect = new Rect(screenWidth/2 ,0 ,screenWidth ,screenHeight);
        GUI.DrawTexture(imageRect,imageArray[currentImage]);
    }


    private void Start()
    {
        targetTime = 5;
    }

    private void Update()
    {
        targetTime -= Time.deltaTime * 5;

        if (targetTime <= 0)
        {
            currentImage = Random.Range(0, imageArray.Length);
            targetTime = Random.Range(0.35f, 5);    
        }
    }

}
