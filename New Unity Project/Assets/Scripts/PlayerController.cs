using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    //Boosts the player's Speed and resets Agility and Strength.
    private float PlayerSpeedMode()
    {
        PlayerStats.playerSpeed = PlayerStats.playerBaseSpeed * PlayerStats.playerSpeedMod;
        PlayerStats.playerStrength = PlayerStats.playerBaseStrength;
        PlayerStats.playerAgility = PlayerStats.playerBaseAgility;
        return PlayerStats.playerStrength;
        return PlayerStats.playerAgility;
        return PlayerStats.playerSpeed;
    }

    //Boosts the player's Strength and resets Agility and Strength.
    public float PlayerStrengthMode()
    {
        PlayerStats.playerStrength = PlayerStats.playerBaseStrength * PlayerStats.playerStrengthMod;
        PlayerStats.playerSpeed = PlayerStats.playerBaseSpeed;
        PlayerStats.playerAgility = PlayerStats.playerBaseAgility;
        return PlayerStats.playerStrength;
        return PlayerStats.playerAgility;
        return PlayerStats.playerSpeed;
    }

    //Boosts the player's Agility and resets Speed and Strength.
    public float PlayerAgilityMode()
    {
        PlayerStats.playerAgility = PlayerStats.playerBaseAgility * PlayerStats.playerAgilityMod;
        PlayerStats.playerSpeed = PlayerStats.playerBaseSpeed;
        PlayerStats.playerStrength = PlayerStats.playerBaseStrength;
        return PlayerStats.playerStrength;
        return PlayerStats.playerAgility;
        return PlayerStats.playerSpeed;
    }

    //Resets all stats on the player to their base value.
    public float PlayerClean()
    {
        PlayerStats.playerAgility = PlayerStats.playerBaseAgility;
        PlayerStats.playerSpeed = PlayerStats.playerBaseSpeed;
        PlayerStats.playerStrength = PlayerStats.playerBaseStrength;
        return PlayerStats.playerStrength;
        return PlayerStats.playerAgility;
        return PlayerStats.playerSpeed;
    }

// Use this for initialization
void Start () {
        PlayerClean();
	}
	
	// Update is called once per frame
	void Update () {

        PlayerStats.verticalVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        //Acts as a method of grounding the character (resets the jumpCount which keeps a player from double jumping)
        if (PlayerStats.verticalVelocity == 0)
        {
            PlayerStats.jumpCount = 0;
        }

        //Causes the player to jump when Spacebar is pressed and prevents multi-jumping using the jumpCount variable.
        if (Input.GetKeyDown(KeyCode.Space) && PlayerStats.jumpCount < 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PlayerStats.playerAgility), ForceMode2D.Impulse);
            PlayerStats.jumpCount += 1;
        }

        //Switches the character to their Speed form when the "1" key is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerSpeedMode();
        }

        //Switches the character to their Srength form when the "2" key is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerStrengthMode();
        }

        //Switches the character to their Agility form when the "3" key is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerAgilityMode();
        }

        //Resets the character's stats when the "4" key is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayerClean();
        }

        //Move right when the right arrow key is pressed.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(new Vector2(PlayerStats.playerSpeed, 0) * 6 * Time.deltaTime);
        }
        
        //Move left when the left arrow key is pressed.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
        }
    }
}
