using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class AlienController : MonoBehaviour
{
    [Header("AlienControls")]
    public bool isActive = true;
    public float speed = 10f;

    //get player coordiantes
    //follow player

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player, Vector3.up);
    }

    //ontriggerenter
    //reset scene
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            //reset scene
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }
}
