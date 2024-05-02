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
        GO_CONTROL_ROOM = 1,
        GO_CONTROL_ROOM_COMPLETED = 2,
        SEARCH_KEYCARD = 3,
        SEARCH_KEYCARD_COMPLETED = 4,
        TURN_ON_GENERATORS = 5,
        TURN_ON_GENERATORS_COMPLETED = 6,
        ESCAPE = 7
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
    }

    IEnumerator ShowCurrentObjective()
    {
        objectives[currentObjective].gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        objectives[currentObjective].gameObject.SetActive(false);
    }

    public void ChangeObjective(Objectives objective)
    {
        currentObjective = (int)objective;
        StartCoroutine(ShowCurrentObjective());
    } 

}
