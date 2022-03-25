using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sound_slider : MonoBehaviour
{
    [SerializeField] Slider volume_slider;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
        Load();
    }

    // Update is called once per frame
    public void change_volume()
    {
        AudioListener.volume = volume_slider.value;
        Save();
    }

    private void Load ()
    {
        volume_slider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volume_slider.value);
    }
}
