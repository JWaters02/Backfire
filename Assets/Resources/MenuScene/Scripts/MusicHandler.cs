using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {
    private AudioSource music;

    // Start is called before the first frame update
    void Start() {
        //AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("MenuScene/Audio/music"), new Vector3(0, 0, 0));
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicHandler>().PlayMusic();
    }

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        music = GetComponent<AudioSource>();
    }

    public void PlayMusic() {
        if (music.isPlaying) return;
        music.Play();
    }

    public void StopMusic() {
        music.Stop();
    }
}
