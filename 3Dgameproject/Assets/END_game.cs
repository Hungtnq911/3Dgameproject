using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END_game : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject== Player)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

        }
    }
}
