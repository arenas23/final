using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objjectives : MonoBehaviour
{
    public static Objjectives Instance { get; private set; }


    [SerializeField] Image [] objectives;
    public int currentObjective = 0;

    public enum Objectives
    {
        GO_CONTROL_ROOM = 0,
        GO_CONTROL_ROOM_COMPLETED = 1,
        SEARCH_KEYCARD = 2,
        SEARCH_KEYCARD_COMPLETED = 3,
        TURN_ON_GENERATORS = 4,
        TURN_ON_GENERATORS_COMPLETED = 5,
        ESCAPE = 6
    }

 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in objectives)
        {
            item.gameObject.SetActive(false);
        }

        StartCoroutine(showFirstObjective());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator showFirstObjective()
    {
        yield return new WaitForSeconds(6);
        objectives[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        objectives[0].gameObject.SetActive(false);
    }

    IEnumerator ShowCurrentObjective()
    {
        objectives[currentObjective].gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        objectives[currentObjective].gameObject.SetActive(false);
    }

    public void ChangeObjective(Objectives objective)
    {
        currentObjective = (int)objective;
        StartCoroutine(ShowCurrentObjective());
    } 

}
