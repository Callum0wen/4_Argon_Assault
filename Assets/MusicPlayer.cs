using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
	// Awake is called on scene load
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Start is called before the first frame update
	void Start()
    {
        Invoke("LoadFirstScene", 3.0f);
    }

    void LoadFirstScene()
	{
        SceneManager.LoadScene(1);
	}
}
