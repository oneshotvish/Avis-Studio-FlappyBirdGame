using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{
	public GameObject coin;
	public GameObject coinParticleEffect;

	void OnTriggerEnter2D(Collider2D other)

	{
		if(other.GetComponent<Bird>() != null)
		{
			Debug.Log("Coin Get");
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			GameControl.instance.BirdScored();
			coin.SetActive(false);

			//Create and destroy particle effect
			GameObject clone = Instantiate(coinParticleEffect, coin.transform.position, coin.transform.rotation);
			clone.transform.SetAsLastSibling();
			//Destroy(clone, 1.0f);
			
		}
	}
}
