using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockSpawnerScript : MonoBehaviour
{

    public GameObject blockPrefab;
    public Vector3 position;
    public string text1="M";
    public TextMesh textComponent;

    public Vector3[] rows;
    private GameObject[] blocks;
    public string[] letters = { "A", "Q", "F", "E", "C", "V", "P", "I", "H", "L" };

    // Start is called before the first frame update
    void Start()
    {
        //GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
       // block.transform.position = position;
            
       // textComponent = block.GetComponentInChildren<TextMesh>();
        //textComponent.text = "Z";

       // RectTransform rt = (RectTransform)block.transform;
        //float width = rt.rect.width;
        //Debug.Log("Width: "+width);

        blocks = new GameObject[10];    //10 blocks in a row
        float width = 1;
        float offset = 0.2f;

        
        for(int i=0; i<10; i++)
        {
            GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            block.transform.position = new Vector3(transform.position.x + (i*width) + (i*offset), transform.position.y, 0);        
            block.GetComponentInChildren<TextMesh>().text = letters[i];
            blocks[i] = block;
        } 

      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
