using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static int playerModeSelect = 0;
    public static float speedMovement;

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
    void Update() {

        float joystickMovement = Input.GetAxis("Joystick Horizontal");
        float dPadMovement = Input.GetAxis("D-Pad Horizontal");

        PlayerStats.verticalVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        //Acts as a method of grounding the character (resets the jumpCount which keeps a player from double jumping)
        if (PlayerStats.verticalVelocity == 0)
        {
            PlayerStats.jumpCount = 0;
        }

        //Causes the player to jump when Spacebar is pressed and prevents multi-jumping using the jumpCount variable.
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && PlayerStats.jumpCount < 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PlayerStats.playerAgility), ForceMode2D.Impulse);
            PlayerStats.jumpCount += 1;
        }

        //Keeps the playerModeSelect variable from going out of bounds.
        if (playerModeSelect > 3)
        {
            playerModeSelect = 0;
        }
        if (playerModeSelect < 0)
        {
            playerModeSelect = 3;
        }

        //Swaps player to clean mode
        if (playerModeSelect == 0)
        {
            PlayerClean();
        }

        //Swaps player to speed mode
        if (playerModeSelect == 1)
        {
            PlayerSpeedMode();
        }

        //Swaps player to strength mode
        if (playerModeSelect == 2)
        {
            PlayerStrengthMode();
        }

        //Swaps player to agility mode
        if (playerModeSelect == 3)
        {
            PlayerAgilityMode();
        }

        //Switches the character's mode to the next mode in the sequence (Clean -> Speed -> Strength -> Agility)
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetButtonDown("RB"))
        {
            playerModeSelect += 1;
        }

        //Switches the character's mode to the previous mode in the sequence (Agility -> Strength -> Speed -> Clean)
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("LB"))
        {
            playerModeSelect -= 1;
        }

        //Move right when the right arrow key is pressed.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(new Vector2(PlayerStats.playerSpeed, 0) * 6 * Time.deltaTime);
            speedMovement = PlayerStats.playerSpeed * 6 * Time.deltaTime;
        }

        //Move left when the left arrow key is pressed.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
            speedMovement = (PlayerStats.playerSpeed * -1) * 6 * Time.deltaTime;
        }

        if (joystickMovement < 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
            speedMovement = PlayerStats.playerSpeed * 6 * Time.deltaTime;
        }

        if (joystickMovement > 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * 1), 0) * 6 * Time.deltaTime);
            speedMovement = (PlayerStats.playerSpeed * -1) * 6 * Time.deltaTime;
        }

        if (dPadMovement < 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
            speedMovement = PlayerStats.playerSpeed * 6 * Time.deltaTime;
        }

        if (dPadMovement > 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * 1), 0) * 6 * Time.deltaTime);
            speedMovement = (PlayerStats.playerSpeed * -1) * 6 * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
        if (collision.gameObject.tag == "jump wall" && playerModeSelect == 3)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedMovement, -2.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (collision.gameObject.tag == "jump wall" && playerModeSelect == 3)
        {
            PlayerStats.jumpCount = 0;
        }
    }
}
