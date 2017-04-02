using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance {
        set; get;
    }

    private List<GameObject> allBlocks;
    public GameObject[] levelPrefab;

    private int currentLevel = 0;

    private bool isGameCompleted = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        //load all 
        //done loading.. then.. 

        ChangeScene("Menu");
    }

    private void Update()
    {
        if (isGameCompleted) {
            ChangeScene("Menu");
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //callback function for Scene load 
    public void OnLevelWasLoaded(int levelIndex)
    {
        isGameCompleted = false;

        // wich Scene we are in 
        if (SceneManager.GetActiveScene().name == "Game")
        {
          
            CreateLevel();

        }
    }

    private void CreateLevel() {
        //instance level prefab 
        if (currentLevel < levelPrefab.Length)
        {
            Instantiate(levelPrefab[currentLevel]);
        }
        else
        {
            //it finish the levels 
            isGameCompleted = true; 
        }
        // How many blocks they are? 
        GameObject[] a = GameObject.FindGameObjectsWithTag("Block");
        allBlocks = new List<GameObject>();
        allBlocks.AddRange(a);
    }

    public void RemoveBlock(GameObject block)
    {
        if (allBlocks.Find(b => b == block)) {
            allBlocks.Remove(block);
        }
        if (allBlocks.Count== 0) {
            Victory();
        }
    }
    public void Victory(){
        currentLevel++;
        GameObject[] a = GameObject.FindGameObjectsWithTag("Block");
        for (int i=0;i<a.Length;i++) {
            DestroyImmediate(a[i]);
        }

        GameObject[] b = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < b.Length; i++)
        {
            DestroyImmediate(b[i]);
        }
        CreateLevel();
    }

}
