using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{


    

    private void Oncollisionfall(Collision2D collision)
    {



        if (collision.gameObject.tag == "PlayerCharacter")
        {
            Debug.Log("touching");
            // Application.LoadLevel(0);
            //SceneManager.LoadScene(0);
        }
    }
}
