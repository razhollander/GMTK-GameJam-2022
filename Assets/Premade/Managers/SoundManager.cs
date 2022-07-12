using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audio1;

    bool _flag = true;
    
    public void PlayAudio1()
    {
        audio1.Play();
    }
}
