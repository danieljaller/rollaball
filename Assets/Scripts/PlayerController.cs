using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody player;
    private int count;
    public Text countText;
    public Text winnerText;
    private GameObject[] gameObjects;
    public float timer;
    public bool increaseTime;
    public Text timerText;
    public float speed;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        gameObjects = GameObject.FindGameObjectsWithTag("Pick Up");
        SetCountText();
        winnerText.text = "";
        SetActivePickUp(count);
        timer = 0.0f;
        increaseTime = true;
    }

    private void SetActivePickUp(int count)
    {
        var x = gameObjects[count].GetComponent<Renderer>();
        x.material.color = Color.green;
        gameObjects[count].tag = "Active Pick Up";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        player.AddForce(movement * speed);
        if (increaseTime)
            timer += Time.deltaTime;
        SetTimerText();
        //if (Input.GetKeyDown(KeyCode.Return))
        //    SceneManager.LoadScene(0);
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    Application.Quit();
    }

    private void SetTimerText()
    {
        timerText.text = "Time elapsed: " + timer.ToString("F3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            SetActivePickUp(count);
        }

        if (other.gameObject.CompareTag("Hole"))
        {
            player.gameObject.SetActive(false);
            winnerText.text = "You lose!";
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            winnerText.text = "You win!";
            player.gameObject.SetActive(false);
            increaseTime = false;
            Application.LoadLevel(1);
        }
    }
}
