using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds, sfxcSounds;
    public AudioSource musicSource, sfxSource, sfxcSource;

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Musica nao encontrada");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name) //SFX que pode ser interrompido
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX nao encontrado");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySFXC(string name) //SFX que não podem ser interrompidos 
    {
        Sound s = Array.Find(sfxcSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFXC nao encontrado");
        }
        else
        {
            sfxcSource.PlayOneShot(s.clip);
        }
    }

    public void StopAllSFX()
    {
        sfxSource.Stop();
        sfxcSource.Stop();
    }
}
