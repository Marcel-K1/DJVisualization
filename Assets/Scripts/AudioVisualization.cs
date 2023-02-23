using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AudioVisualization : MonoBehaviour
{
    [Header("Background")]
    [SerializeField]
    private AudioData audioData = null;
    [SerializeField]
    private Material materialToChange;   
    [SerializeField]
    private float backgroundUpdateStep = 0.1f;
    private float currentBackgroundUpdateTime = 0f;

    //[Header("Video Player")]
    //[SerializeField]
    //private VideoPlayer videoPlayerToChange;
    //[SerializeField]
    //private RawImage imageToChange;
    //[SerializeField]
    //private float colorPower = 1f;
    //[SerializeField]
    //private float playbackSpeed = 1f;
    //[SerializeField]
    //private float videoUpdateStep = 0.5f;
    //private float currentVideoUpdateTime = 0f;

    [Header("Image Player")]
    [SerializeField]
    private Texture[] imageArray = null;
    [SerializeField]
    private RawImage imageToChange = null;
    //[SerializeField]
    //int screenWidth = 1500;
    //[SerializeField]
    //int screenHeight = 1500;
    [SerializeField]
    private int currentImage = 0;


    private Color colorFromAudioData = Color.white;
    private float targetTime;


    //private void OnGUI()
    //{
    //    Rect imageRect = new Rect(-(screenWidth-(screenWidth/2)), -(screenHeight-(screenHeight/2)), screenWidth, screenHeight);
    //    Debug.Log($"{imageRect.x},{imageRect.y}");
    //    GUI.DrawTexture(imageRect, imageArray[currentImage]);
    //    GUI.color = colorFromAudioData;
    //}

    void Start()
    {
        //videoPlayerToChange.Prepare();
        targetTime = 5;
    }

    void Update()
    {
        //playbackSpeed = videoPlayerToChange.playbackSpeed;
        //currentVideoUpdateTime += Time.deltaTime;

        //Background
        currentBackgroundUpdateTime += Time.deltaTime;

        if (currentBackgroundUpdateTime >= backgroundUpdateStep)
        {
            currentBackgroundUpdateTime = 0f;

            if (materialToChange != null)
            {
                float factor1 = Random.Range(0, 255);
                float factor2 = Random.Range(0, 255);
                float factor3 = Random.Range(0, 255);
                float factor4 = Random.Range(5f, 8f);
                float randomfloat = Random.Range(0.01f, 0.1f);
                colorFromAudioData = new Color(randomfloat * factor1, randomfloat * factor2, randomfloat * factor3);
                
                //Changing Background Properties
                materialToChange.SetColor("BaseColor", colorFromAudioData);
                materialToChange.SetFloat("LavaPower", factor4);

                //Changing Image Properties
                //imagetoChange.color = colorFromAudioData;
            }

            //if (currentVideoUpdateTime >= videoUpdateStep)
            //{
            //    currentVideoUpdateTime = 0f;
            //    float factor1 = Random.Range(0.2f, 3f);
            //    videoPlayerToChange.playbackSpeed = factor1;
            //}
        }

        //Image Player
        targetTime -= Time.deltaTime * 5;

        if (targetTime <= 0)
        {
            currentImage = Random.Range(0, imageArray.Length);
            targetTime = Random.Range(0, 5);
            imageToChange.texture = imageArray[currentImage];
        }



    }
}
