using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
    GameObject[] musicObject;
    // Use this for initialization
    void Start()
    {


        // Use this for initialization

        musicObject = GameObject.FindGameObjectsWithTag("Music");
        if (musicObject.Length == 1)
        {
            
        }
        else
        {
            for (int i = 1; i < musicObject.Length; i++)
            {
                Destroy(musicObject[i]);
            }

        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
