using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    //Having this particular script accessible to any other script through the "public static" function
	public static GameMaster gm;

	void Start ()
    {
		if (gm == null)
        {
            //finding a gameobject with the tag "GM" so it can be accessible to any other game object's scripts
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}

    //Declaring the transform of the player and the spawnpoint
	public Transform playerPrefab;
	public Transform spawnPoint;

    //The amount of seconds the player has to wait
	public int spawnWait = 5;

	public IEnumerator RespawnPlayer () 
    {
        //Create the  function in which the player has to wait based on the amount of int you put in the "spawnDelay"
		yield return new WaitForSeconds (spawnWait);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public static void KillPlayer (Player player)
    {
        //Destroy the player, which causes it to respawn through a player prefab.
		Destroy (player.gameObject);
		gm.StartCoroutine (gm.RespawnPlayer());
	}

}