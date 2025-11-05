using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI score;
    public TextMeshProUGUI turn;

    public int uiScore = 0;
    public string whoTurn = "Player's Turn (W,A,S,D)";
    private EnemyAI enemyAI;
    private GameManager gameManager;
    public GameObject gameOver;
    public GameObject winGame;
    public bool boolgameOver = false;
    public bool boolwinGame = false;
    public GameObject playerObj;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.text = "Score: 0";
        turn.text = whoTurn = "Player's Turn (W,A,S,D)";
        enemyAI = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameOver.SetActive(false);
        winGame.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {


        score.text = "Score: " + uiScore.ToString();
        turn.text = whoTurn;

        if (uiScore == 5)
        {
            winGame.SetActive(true);
            Time.timeScale = 0;
            boolwinGame = true;
            playerObj.SetActive(false);
            
        }

        if (enemyAI.gameOver)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            boolgameOver = true;
            playerObj.SetActive(false);

        }
        
    }
}
