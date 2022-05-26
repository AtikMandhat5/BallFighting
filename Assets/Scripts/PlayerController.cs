using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


	private Rigidbody playerRb;
	private float powerupStrenth=15.0f;
	public float speed = 5.0f;
	private GameObject focalPoint;
	public bool hasPowerUp=false;
	public GameObject powerUpIndicator;




    // Start is called before the first frame update
    void Start()
    {
    	playerRb = GetComponent<Rigidbody>();
    	focalPoint = GameObject.Find("Focal Point");

        
    }

    // Update is called once per frame
    void Update()
    {
    	float forwardInput = Input.GetAxis("Vertical");

    	playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position=transform.position + new Vector3(0,0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("PowerUp"))
    	{
    		hasPowerUp = true;
    		powerUpIndicator.gameObject.SetActive(true);
    		Destroy(other.gameObject);
    		StartCoroutine(PowerUpCountDownRoutine());
    	}
    }

    IEnumerator PowerUpCountDownRoutine()
    {
    	yield return new WaitForSeconds(7);
    	hasPowerUp=false;
    	powerUpIndicator.gameObject.SetActive(false);
    		
    }
    //physics add in this methods // diffirence ontriger and on collision 
    private void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
    	{
    		Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
    		Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

    		enemyRigidbody.AddForce(awayFromPlayer * powerupStrenth, ForceMode.Impulse);
    		Debug.Log("Collide With :"+collision.gameObject.name +"With power set to "+ hasPowerUp);

    	}
    }
}
