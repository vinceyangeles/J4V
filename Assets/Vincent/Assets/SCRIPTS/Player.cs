using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[System.Serializable]

    //Declaring a new class within a class
	public class PlayerStats
    {
        //Declare a health for the player (can be any tbh)
		public int Health = 100;
	}

    //accessing the class above which deals with health
	public PlayerStats playerStats = new PlayerStats();

    //the y value axis of which the player falls into (can be any negative)
	public int fallBoundary = -10;

	void Update ()
    {
        //Damaging the player by 100 (also the players Health) if they go below or equal to the fallboundary (-10)
		if (transform.position.y <= fallBoundary)
			DamagePlayer (100);
	}

    //Damage player method which kills the player if they fall within the y axis value
	public void DamagePlayer (int damage)
    {
        //Stating the player's health is able to take damage
		playerStats.Health -= damage;

		if (playerStats.Health <= 0)
        {
            //Accessing the GameMaster script that has the method of "KillPlayer"
			GameMaster.KillPlayer(this);
		}
	}

}
