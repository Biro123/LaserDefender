using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    private void Awake()
    {
        /// Singleton Pattern - used to ensure only one instance of this class
        /// ever exists. This way we won't have the same tune playing over itself.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        Debug.Log("MusicPlayer Loaded: " + scene.buildIndex);

        music.Stop();

        if (scene.buildIndex == 0) { music.clip = startClip; }
        else if (scene.buildIndex == 1) { music.clip = gameClip; }
        else if (scene.buildIndex == 2) { music.clip = endClip; }

        music.loop = true;
        music.Play();
    }

 
    // Use this for initialization
    void Start () {
        
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
