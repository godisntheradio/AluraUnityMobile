using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private string mixerParam;
    [SerializeField]
    private OnLoadSuccess OnLoadSuccess;
    private void Start()
    {
        if(PlayerPrefs.HasKey(mixerParam))
        {
            PlayerPrefs.GetFloat(mixerParam);
            float vol = PlayerPrefs.GetFloat(mixerParam);
            audioMixer.SetFloat(mixerParam, vol);
            OnLoadSuccess.Invoke(vol);
        }
    }
    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat(mixerParam, volume);
        PlayerPrefs.SetFloat(mixerParam, volume);
    }
}
[System.Serializable]
public class OnLoadSuccess : UnityEvent<float>
{ }

