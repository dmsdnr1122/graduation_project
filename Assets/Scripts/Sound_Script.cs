using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Script : MonoBehaviour {

    private AudioSource audio1, audio2, audio3, audio4;
    public AudioClip Main_Sound, Btn_Sound, Unlock_Sound, Paper_Sound;
    
    public void LoopSound()
    {
        this.audio1 = this.gameObject.AddComponent<AudioSource>();
        this.audio1.clip = this.Main_Sound;
        this.audio1.loop = true;
        Loop_play();
    }
    public void BtnSound()
    {
        this.audio2 = this.gameObject.AddComponent<AudioSource>();
        this.audio2.clip = this.Btn_Sound;
        this.audio2.loop = false;
        Btn_play();
    }
    public void UnlockSound()
    {
        this.audio3 = this.gameObject.AddComponent<AudioSource>();
        this.audio3.clip = this.Unlock_Sound;
        this.audio3.loop = false;
        Unlock_play();
    }
    public void PaperSound()
    {
        this.audio4 = this.gameObject.AddComponent<AudioSource>();
        this.audio4.clip = this.Paper_Sound;
        this.audio4.loop = false;
        Paper_sound();
    }
    
    void Loop_play()
    {
        this.audio1.Play();
    }
    void Btn_play()
    {
        this.audio2.Play();
    }
    void Unlock_play()
    {
        this.audio3.Play();
    }
    void Paper_sound()
    {
        this.audio4.Play();
    }
}
