using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AudioVisualization : MonoBehaviour
{
    [SerializeField]
    private AudioData audioData = null;
    [SerializeField]
    private Material materialToChange;
    [SerializeField]
    private VideoPlayer videoPlayerToChange;
    [SerializeField]
    private RawImage imageToChange;
    [SerializeField]
    private float colorPower = 1f;
    [SerializeField]
    private float playbackSpeed = 1f;
    [SerializeField]
    private float videoUpdateStep = 0.5f;
    [SerializeField]
    private float backgroundUpdateStep = 0.1f;

    private float currentBackgroundUpdateTime = 0f;
    private float currentVideoUpdateTime = 0f;
    private Color colorValue = Color.white;


    void Start()
    {
        videoPlayerToChange.Prepare();
        materialToChange.SetFloat("LavaSpeed", 1.5f);
    }

    void Update()
    {
        ////AudioPeer
        //colorValue = new Color(AudioPeer.samples[(int)Random.Range(0f, 128f)] * colorPower, AudioPeer.samples[(int)Random.Range(128f, 256f)] * colorPower, AudioPeer.samples[(int)Random.Range(256f, 512f)] * colorPower); ; ;
        //if (materialToChange != null)
        //{
        //    materialToChange.SetColor("BaseColor", colorValue);
        //}

        //AudioData
        playbackSpeed = videoPlayerToChange.playbackSpeed;
        currentVideoUpdateTime += Time.deltaTime;
        currentBackgroundUpdateTime += Time.deltaTime;

        if (currentBackgroundUpdateTime >= backgroundUpdateStep)
        {
            currentBackgroundUpdateTime = 0f;

            if (materialToChange != null)
            {
                float factor1 = Random.Range(0, 255);
                float factor2 = Random.Range(0, 255);
                float factor3 = Random.Range(0, 255);
                float factor4 = Random.Range(2, 8);
                float factor5 = Random.Range(0, 255);
                materialToChange.SetColor("BaseColor", new Color(audioData.ClipLoudness * factor1, audioData.ClipLoudness * factor2, audioData.ClipLoudness * factor3));
                materialToChange.SetFloat("LavaPower", factor4);
                imageToChange.color = new Color(audioData.ClipLoudness * factor1, audioData.ClipLoudness * factor2, audioData.ClipLoudness * factor3, audioData.ClipLoudness * factor5);
            }

            if (currentVideoUpdateTime >= videoUpdateStep)
            {
                currentVideoUpdateTime = 0f;
                float factor1 = Random.Range(0.2f, 3f);
                videoPlayerToChange.playbackSpeed = factor1;
            }
        }
    }
}
