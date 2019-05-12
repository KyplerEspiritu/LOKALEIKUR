using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject door;
	public GameObject gameOverText;
	public GameObject winText;
	public GameObject light;

	public float speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	IEnumerator loadMainMenu() // Fall sem loadar main menu eftir 3 sek
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    void StopAllAnimation() // Fall sem finnur öll object með animation
	{
	    Animator[] animatorsInTheScene = FindObjectsOfType(typeof(Animator)) as Animator[];
        foreach (Animator animatorItem in animatorsInTheScene)
        {
            animatorItem.enabled = false;
        }
	}

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () { // Update fall sem eru notaður til að hreyfa playerinn
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other){ // Þessar if setningar eru notaðar til að deactivatea object eftir að hafa snert eitthvað
		if (other.gameObject.CompareTag("PurpleKey")){
			door = GameObject.FindWithTag("PurpleDoor");
			other.gameObject.SetActive(false);
			door.SetActive(false);
		}
		if (other.gameObject.CompareTag("GreenKey")){
			door = GameObject.FindWithTag("GreenDoor");
			other.gameObject.SetActive(false);
			door.SetActive(false);
		}
		if (other.gameObject.CompareTag("YellowKey")){
			door = GameObject.FindWithTag("YellowDoor");
			other.gameObject.SetActive(false);
			door.SetActive(false);
		}
		if (other.gameObject.CompareTag("RedKey")){
			door = GameObject.FindWithTag("RedDoor");
			other.gameObject.SetActive(false);
			door.SetActive(false);
		}
		if (other.gameObject.CompareTag("BlueKey")){
			door = GameObject.FindWithTag("BlueDoor");
			other.gameObject.SetActive(false);
			door.SetActive(false);
		}
		if (other.gameObject.CompareTag("Enemy")){ // Þessi if setning gerist þegar þú snertir óvin
			StopAllAnimation();
			gameOverText.SetActive(true);
			light = GameObject.FindWithTag("Light");
			light.SetActive(false);
			StartCoroutine(loadMainMenu()); // Main menu loadast eftir ákveðinn tíma
		}
		
		if (other.gameObject.CompareTag("FinalKey")){ // Þessi if setning gerist þegar þú vinnur
			StopAllAnimation();
			winText.SetActive(true);
			light = GameObject.FindWithTag("Light");
			light.SetActive(false);
			StartCoroutine(loadMainMenu());
		}
	}
}
