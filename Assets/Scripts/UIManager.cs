using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
        //declaring variables
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
        score.text = "Score: 0";        //initializing score
        turn.text = whoTurn = "Player's Turn (W,A,S,D)"; //display whos turn it is
        enemyAI = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();   //get components after tags found
        gameOver.SetActive(false);//show gameover
        winGame.SetActive(false);//show win screen
        Time.timeScale = 1;//Time scale active
    }

    // Update is called once per frame
    void Update()
    {


        score.text = "Score: " + uiScore.ToString();        //setting new score
        turn.text = whoTurn; //show turn

        if (uiScore == 5) //win condition
        {
            winGame.SetActive(true);
            Time.timeScale = 0;
            boolwinGame = true;
            playerObj.SetActive(false);
            
        }

        if (enemyAI.gameOver)//gameover condition
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            boolgameOver = true;
            playerObj.SetActive(false);

        }
        
    }
}
