using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioData : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private int sampleDataLength = 1024;
    [SerializeField]
    private float[] clipSampleData;
    [SerializeField]
    private float clipLoudness; 

    private float minSize = 0; 
    private float maxSize = 500f; 
    private float sizeFactor = 1f;

    //Microphone Input
    public AudioClip audioClip;
    public bool useMicrophone;
    public string selectedDevice;
    public AudioMixerGroup mixerGroupMicrophone, mixerGroupMaster;

    public float ClipLoudness { get => clipLoudness; set => clipLoudness = value; }


    void Awake()
    {
        clipSampleData = new float[sampleDataLength];

        //Microphone
        if (useMicrophone)
        {
            if (Microphone.devices.Length > 0)
            {
                selectedDevice = Microphone.devices[0].ToString();
                audioSource.outputAudioMixerGroup = mixerGroupMicrophone;
                audioSource.clip = Microphone.Start(selectedDevice, true, 10, AudioSettings.outputSampleRate);
            }
            else
            {
                useMicrophone = false;
            }
        }
        if (!useMicrophone)
        {
            audioSource.outputAudioMixerGroup = mixerGroupMaster;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    void Update()
    {
        audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
        ClipLoudness = 0f;
        foreach (var sample in clipSampleData)
        {
            ClipLoudness += Mathf.Abs(sample);
        }
        ClipLoudness /= sampleDataLength;

        ClipLoudness *= sizeFactor;
        ClipLoudness = Mathf.Clamp(ClipLoudness, minSize, maxSize);
    }
}
