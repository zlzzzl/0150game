using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionManager : MonoBehaviour
{
    public int currentChar;
    public bool inGamePlayScene = false;
    public int maxcOunt;
    public GameObject[] cars;
    public Transform player;
    void Awake()
    {
        int selectedCar = PlayerPrefs.GetInt("SelectedCarID")+1;
        Debug.Log(selectedCar);
        if(inGamePlayScene == true)
        {
            GameObject clone =Instantiate ( Resources.Load<GameObject>("Prefabs/"+selectedCar.ToString()),player);
            clone.transform.localPosition = Vector3.zero;
            clone.transform.localEulerAngles = Vector3.zero;
            Destroy(gameObject);
        }
    }


    
    void Update()
    {
        
    }

    public void Right()
    {
        if(currentChar < maxcOunt -1 )
        {
            cars[currentChar].SetActive(false);
            currentChar += 1;
            cars[currentChar].SetActive(true);
        }
    }
    
    public void Left()
    {
        if(currentChar > 0)
        {

            cars[currentChar].SetActive(false);
            currentChar -= 1;
            cars[currentChar].SetActive(true);
        
        }
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedCarID", currentChar);
        SceneManager.LoadScene("move");
    }
}
