using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class opgaveClass
{
    public string svar;
    public string opgaver;

}

[System.Serializable]
public class opgaveListClass
{
    public List<opgaveClass> opgaveliste;
}

public class databasefechter : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(GetData());
    }

    public TMP_Text spørgsmålet;
    public TMP_InputField svarfelt;
    public MoveDestination currentEnemy;
    public opgaveListClass opgave;
    IEnumerator GetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/futurebob/fetch_text.php");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string json = "{\"opgaveliste\":" + www.downloadHandler.text + "}";

            opgave = JsonUtility.FromJson<opgaveListClass>(json);
            Debug.Log("antal opgaver " + opgave.opgaveliste.Count);
            foreach (opgaveClass opgaver in opgave.opgaveliste)
            {
                Debug.Log($"opgave: {opgaver.opgaver}, svar: {opgaver.svar}");
                //feedbackField.text = www.downloadHandler.text;


            }
            spørgsmålet.text = opgave.opgaveliste[0].opgaver;   
            opgaveClass = opgave.opgaveliste[0];

        }


    }
    public GameObject canvas;
    public GameObject førsteliv;
    public GameObject andenliv;
    public GameObject trejdeliv;
    public GameObject player;
    
    public opgaveClass opgaveClass;
    public TMP_InputField anwser;
    public void tjek()
    {
        Debug.Log(anwser.text);
        Debug.Log(opgaveClass.svar);

        if (anwser.text.ToString() == opgaveClass.svar.ToString())
        {
            Debug.Log("if true");
            canvas.SetActive(false);
            currentEnemy.answered = true;
            currentEnemy.goal.parent.GetComponent<PlayerMovement>().allowtomove = true;
        }
        else if (anwser.text.ToString() != opgaveClass.svar.ToString() && førsteliv.activeInHierarchy)
        {

            førsteliv.SetActive(false);
        }
        else if (anwser.text.ToString() != opgaveClass.svar.ToString() && andenliv.activeInHierarchy)
        {

            andenliv.SetActive(false);
        }
        else if (anwser.text.ToString() != opgaveClass.svar.ToString() && trejdeliv.activeInHierarchy)
        {

            trejdeliv.SetActive(false);
        }
        else
        {
            Destroy(player);
        }
    }
}
