using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class BlockSpawnerScript : MonoBehaviour
{

    public GameObject blockPrefab;
    public Vector3 position;
    public TextMesh textComponent;

    public Vector3[] rows;
    private GameObject[] blocks;

    public string[] words = { "bin", "hello", "great", "find", "unity", "hub", "text", "doll", "photo", "lamp" };

    string allChars = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
    
    float width = 1;
    float offset = 0.2f;

    int numOfRows = 10;
    int numOfColumns = 10;

    // Start is called before the first frame update
    void Start()
    {
      
        blocks = new GameObject[10];    //10 blocks in a row
        float width = 1;
        float offset = 0.2f;

        int numOfRows = 10;
        int numOfColumns = 10;

        blocks = new GameObject[10];    //10 blocks in a row
        //inside outer loop before inner loop
        string word = words[UnityEngine.Random.Range(0, 10)];
        Debug.Log("word: " + word);

        int numOfRandomLetters = numOfColumns - word.Length;

        string randomLetters = generateRandomLetters(numOfRandomLetters);
        Debug.Log("randomLetters: " + randomLetters);

        string shuffleLetters = "";
        shuffleLetters += word + randomLetters;

        Debug.Log("shuffleLetters: " + shuffleLetters);

        var shuffledString = shuffleAllLetters(shuffleLetters);

        blocks = spawnRow(shuffledString);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    GameObject[] spawnRow(string str)
    {
        var shuffledString = str;
        blocks = new GameObject[10];

        for (int i = 0; i < 10; i++)
        {
            GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            block.transform.position = new Vector3(transform.position.x + (i * width) + (i * offset), transform.position.y, 0);
            block.GetComponentInChildren<TextMesh>().text = Char.ToString(shuffledString[i]);
            blocks[i] = block;
        }
        return blocks;
    } 

    public string generateRandomLetters(int n)
    {
        //char[] randomLetters = new char[n];
        string allCharsTemp = allChars;
        string randomChar = "";

        for (int i = 0; i < n; i++)
        {
            int index = UnityEngine.Random.Range(0, allCharsTemp.Length);
            char chr = allCharsTemp[index];
            Debug.Log("Random letter: " + chr);
            randomChar+= Char.ToString(chr);
            allCharsTemp.Remove(index);
        }

        //return randomLetters;
        Debug.Log("randomletter str: " + randomChar);
        return randomChar;
    }

    public string shuffleAllLetters(string str)
    {

        char[] charArray = str.ToCharArray();

        // Shuffle the array of characters
        System.Random random = new System.Random();
        charArray = charArray.OrderBy(x => random.Next()).ToArray();

        // Convert the shuffled array of characters back to a string
        string shuffledString = new string(charArray);
        Debug.Log("Shuffled String: " + shuffledString);

        return shuffledString;
    }

}
