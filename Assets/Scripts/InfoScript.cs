using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : MonoBehaviour {

    public List<string> gameNames;
    public List<string> descriptions;
    public List<int> difficulties;
    private int numGames = 3;
    public int activeDifficulty = 0;

	// Use this for initialization
	void Start () {
        addGameNames();
        addDescriptions();
        addDifficulties();
        DontDestroyOnLoad(this);
	}

    void addGameNames()
    {
        gameNames.Add("Refrigerator Matching!");
        gameNames.Add("Race to Cleanliness!");
        gameNames.Add("Lights Out!");
    }

    void addDescriptions()
    {
        descriptions.Add("Keeping the fridge open can be a waste of valuable energy. You could help the environment by only keeping it open for a short while and memorizing its contents. Test your memory with this matching game!");
        descriptions.Add("The longer you are in the shower, the more water you waste. You should stay in until you are clean, but not more than that. Help this duck get clean as fast as possible before he runs out of water!");
        descriptions.Add("Lights use a lot of electricity, so it's important to turn them off when you're not using them. See if you can find the right combination of switches to turn these lights off!");
    }

    void addDifficulties()
    {
        for (int i = 0; i < numGames; i++)
        {
            difficulties.Add(0);
        }
    }
}
