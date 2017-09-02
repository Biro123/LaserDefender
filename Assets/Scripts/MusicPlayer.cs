using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    private void Awake()
    {
        /// Singleton Pattern - used to ensure only one instance of this class
        /// ever exists. This way we won't have the same tune playing over itself.
        if (instance != null)
        {
            Destroy(gameObject);
            print("MusicPlayer destroyed");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Debug.Log(" MusicPlayer Start: " + GetInstanceID());
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
