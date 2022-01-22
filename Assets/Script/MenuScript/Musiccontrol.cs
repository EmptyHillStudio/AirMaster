using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musiccontrol : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("Volume");
        slider.value = music.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Control()
    {
        music.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
}
