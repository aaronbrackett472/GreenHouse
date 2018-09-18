using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchGameLogic : MonoBehaviour {

    List<List<Card>> grid;
    public int numTypes = 5;
    private int numRows;
    private int numCols;
    private Card pickedCard = null;
    private int numMatches = 0;
    public Texture2D tex;
    public Text goodjob;
    public Transform cardPrefab;

    private float cardWidth;
    private float cardHeight;


    public Button nextDiffButton;

    public GameObject buttons;

    public Camera cam;

    private InfoScript info;

    // Use this for initialization
    void Start () {
        goodjob.enabled = false;
        buttons.SetActive(false);
        info = GameObject.Find("Game Info").GetComponent<InfoScript>();
        if (info != null)
        {
            numTypes = info.activeDifficulty;
            Debug.Log("num types");
            Debug.Log(numTypes);
        }
        for (int i = 0; i <= 10; i++){
            if (numTypes*2 >= i * i)
            {
                continue;
            }
            numRows = i;
            break;
        }
        if ((numTypes * 2) % numRows == 0)
        {
            numCols = numTypes * 2 / numRows;
        }
        else
        {
            numCols = (numTypes * 2 / numRows) + 1;
        }
        cardWidth = cardLength(numCols, true);
        cardHeight = cardLength(numRows, false);
        cardPrefab.localScale = new Vector3(cardWidth, cardHeight, 0);
        Debug.Log(string.Format("Card width: {0}, Card height: {1}, {0}", cardWidth, cardHeight));
        grid = new List<List<Card>>();
        populateGrid();
        Debug.Log(cam.orthographicSize);
       // showGrid();
	}
	
    private float cardLength (int numCards, bool width)
    {
        float screenLength = 0;
        if (width == true)
        {
            screenLength = 22f;
        }
        else
        {
            screenLength = 9f;
        }
        return screenLength / (1.25f * numCards + .25f * numCards);

    }

	// Update is called once per frame
	void Update () {
    }

    void populateGrid ()
    {
        List<int> left = new List<int>();
        for (int type = 0; type < numTypes; type++)
        {
            left.Add(type);
            left.Add(type);
        }
        Debug.Log(string.Format("There are {0} objects in list", left.Count));
        for (int row = 0; row < numRows; row++)
        {
            grid.Add(new List<Card>());
            for (int col = 0; col < numCols; col++) {
                if (row*numCols + col >= numTypes * 2)
                {
                    break;
                }
                int randIndex = Random.Range(0, left.Count-1);
                float newX = -11f + + .25f * cardWidth + .25f * cardWidth * col + .5f * cardWidth + cardWidth * col;
                float newY = -4.5f + .25f * cardHeight + .25f * cardHeight * row + .5f * cardHeight + cardHeight * row;
                Vector3 newPosition = new Vector3(newX, newY, 0);
                Debug.Log(string.Format("new card at {0}, {1}", newX, newY));
                Transform cardBody = Instantiate(cardPrefab, newPosition, cardPrefab.rotation);
                int newType = left[randIndex];
                cardBody.gameObject.GetComponent<Card>().construct(newType, row, col);
                grid[row].Add(cardBody.GetComponent<Card>());
                left.RemoveAt(randIndex);
            }
        }
    }

    void showGrid()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, 50f, 50f), new Vector2(0.5f, 0.5f));
                Debug.Log("sprite created");
            }
        }
    }

    public void pickCard(Card card)
    {
        Debug.Log("picked card");
        card.reveal();
        if (pickedCard != null)
        {
            if (pickedCard.type == card.type)
            {
                numMatches++;
                if (numMatches >= numTypes)
                {
                    goodjob.enabled = true;
                    if (info.activeDifficulty >= 10)
                    {
                        nextDiffButton.enabled = false;
                    }
                    buttons.SetActive(true);
                    Destroy(this);
                }
            }
            else
            {
                StartCoroutine(hideRoutine(card, pickedCard));
            }
            pickedCard = null;
        }
        else
        {
            pickedCard = card;
        }
    }

    

    IEnumerator hideRoutine(Card card, Card pc)
    {
        yield return new WaitForSeconds(.5f);
        print(Time.time);
        card.hide();
        pc.hide();
    }

}
