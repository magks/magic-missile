using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    // Start is called before the first frame update
	void Start()
	{
		StartCoroutine(waiter());
	}

	IEnumerator waiter()
	{
		//Rotate 90 deg
		//	transform.Rotate(new Vector3(90, 0, 0), Space.World);
		//Wait for 2 seconds before returning to Main Menu
		yield return new WaitForSeconds(4);
        SceneManager.LoadScene("StartMenu 1");
	}
}
