using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    public static int playerModeSelect = 0;
    public static float speedMovement;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool hasChangedForms;
    public float movementSpeed;

    //Stats that should show us the values for each stat (or how they may unintentionally change)
    /*public float baseSpeedDebug = PlayerStats.playerBaseSpeed;
    public float baseStrengthDebug = PlayerStats.playerBaseStrength;
    public float baseAgilityDebug = PlayerStats.playerBaseAgility;
    public float speedDebug = PlayerStats.playerSpeed;
    public float strengthDebug = PlayerStats.playerStrength;
    public float agilityDebug = PlayerStats.playerAgility;
    public float newSpeed;
    public float newStrength;
    public float newAgility;*/



    //Boosts the player's Speed and resets Agility and Strength.
    private float PlayerSpeedMode()
    {
        PlayerStats.playerSpeed = PlayerStats.playerBaseSpeed * PlayerStats.playerSpeedMod;
        PlayerStats.playerStrength = PlayerStats.playerBaseStrength;
        PlayerStats.playerAgility = PlayerStats.playerBaseAgility;
        return PlayerStats.playerStrength;
        return PlayerStats.playerAgility;
        return PlayerStats.playerSpeed;
        animator.SetBool("playerGreen", false);
        animator.SetBool("playerBlue", true);
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
    void Start()
    {
        playerModeSelect = 1;
        PlayerSpeedMode();
        hasChangedForms = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Detects movement inputs from the joystick and d-pad of the controller
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
            animator.SetBool("isRunning", false);
        }

        //Keeps the playerModeSelect variable from going out of bounds (and from changing the character back to clean).
        if (playerModeSelect > 3 && hasChangedForms == false)
        {
            playerModeSelect = 0;
        }
        if (playerModeSelect < 0 && hasChangedForms == false)
        {
            playerModeSelect = 3;
        }
        if (playerModeSelect > 3 && hasChangedForms == true)
        {
            playerModeSelect = 1;
        }
        if (playerModeSelect < 1 && hasChangedForms == true)
        {
            playerModeSelect = 3;
        }


        //Swaps player to clean mode
        if (playerModeSelect == 0)
        {
            PlayerClean();
            hasChangedForms = false;
        }
         
        //Swaps player to speed mode and changes sprite color to blue.
        if (playerModeSelect == 1)
        {
            PlayerSpeedMode();
            animator.SetBool("playerBlue", true);
            animator.SetBool("playerGreen", false);
            animator.SetBool("playerRed", false);
            hasChangedForms = true;
        }

        //Swaps player to strength mode and changes sprite color to red.
        if (playerModeSelect == 2)
        {
            PlayerStrengthMode();
            animator.SetBool("playerRed", true);
            animator.SetBool("playerBlue", false);
            animator.SetBool("playerGreen", false);
            hasChangedForms = true;
        }

        //Swaps player to agility mode and changes sprite color to green.
        if (playerModeSelect == 3)
        {
            PlayerAgilityMode();
            animator.SetBool("playerGreen", true);
            animator.SetBool("playerBlue", false);
            animator.SetBool("playerRed", false);
            hasChangedForms = true;
        }

        //Gets the tab or select input to enable changing back to the clean form
        if (Input.GetKey(KeyCode.Tab) || Input.GetButton("Select"))
        {
            PlayerClean();
            hasChangedForms = false;
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

        //Move right when the right arrow key is pressed and animates it
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(new Vector2(PlayerStats.playerSpeed, 0) * 6 * Time.deltaTime);
            speedMovement = PlayerStats.playerSpeed * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }

        //Move left when the left arrow key is pressed and animates it
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
            speedMovement = (PlayerStats.playerSpeed * -1) * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }

        else
        {
            animator.SetBool("isRunning", false);
        }

        if (joystickMovement < 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
            speedMovement = PlayerStats.playerSpeed * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }

        if (joystickMovement > 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * 1), 0) * 6 * Time.deltaTime);
            speedMovement = (PlayerStats.playerSpeed * -1) * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }

        if (dPadMovement < 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * -1), 0) * 6 * Time.deltaTime);
            speedMovement = PlayerStats.playerSpeed * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }

        if (dPadMovement > 0)
        {
            gameObject.transform.Translate(new Vector2((PlayerStats.playerSpeed * 1), 0) * 6 * Time.deltaTime);
            speedMovement = (PlayerStats.playerSpeed * -1) * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
            animator.SetBool("isSliding", false);
        }
        if (collision.gameObject.tag == "jump wall" && playerModeSelect == 3)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedMovement, -2.5f);
            animator.SetBool("isSliding", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            gameObject.transform.SetParent(null);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            //Debug.Log("touching");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (collision.gameObject.tag == "jump wall" && playerModeSelect == 3)
        {
            PlayerStats.jumpCount = 0;
        }
        if (collision.gameObject.tag == "Restart")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Run")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }
}

   
