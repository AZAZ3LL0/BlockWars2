using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour
{
    private Camera cam;


    // игровые переменные
    public Commands curent_comand = Commands.Blue;

    public int gold_blue = 10;
    public int gold_red = 10;

    public int actions_blue = 10;
    public int actions_red = 10;

    public int[] boardTopology = new int[2] { 12, 12 };


    // UI
    public bool fireMouse = false;
    public GameObject changedBuilding;

    public Canvas MainUI;
    private Text turn_txt;
    private Text gold_counter;
    private Text action_counter;

    public List<GameObject> buildings = new List<GameObject>();
    public GameObject[] tiles;


    private void Start()
    {
        cam = GetComponent<Camera>();

        // --------- setup tile list ---------------
        // tiles = GameObject.FindGameObjectsWithTag("Tile");

        GetComponent<Wrapper>().LoadSnaphot(SettingsParams.current_save_name);

        // GetComponent<Wrapper>().LoadDefaults();
        // --------- end setup tile list -----------

        // Setup UI
        Text[] Texts = MainUI.GetComponentsInChildren<Text>();
        foreach (Text text in Texts)
        {
            if (text.name == "Command")
            {
                turn_txt = text;
            }
            if (text.name == "Act_counter")
            {
                action_counter = text;
            }
            if (text.name == "Gold_counter")
            {
                gold_counter = text;
            }
        }
        refresh_counters();
        // end setup ui
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (fireMouse)
            {
                RaycastHit hit;
                Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                int layerBuildings = 1 << 6;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerBuildings))
                {
                    if (changedBuilding != null)
                    {
                        Vector2Int selected_index = hit.transform.GetComponent<Tile_Struct>().index;
                        changedBuilding.GetComponent<BuildingAbstract>().Fire(selected_index);
                        // Debug.Log(hit.transform.GetComponent<Tile_Struct>().index);
                    }
                    else { Debug.Log("Пушка, которая должна стрелять не выбрана"); }
                }
                else { Debug.Log("Не попали в постройку"); }

                fireMouse = false;
                changedBuilding = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    if (objectHit.tag == "Tile")
                    {
                        objectHit.GetComponent<TileScript>().GetUI();
                    }
                    else if (objectHit.tag == "Building")
                    {
                        objectHit.GetComponentInParent<BuildingAbstract>().GetUI();
                    }
                    else
                    {
                        // hit other/ not interesting...
                        Debug.Log("Other Raycast Hit");
                        Debug.Log(objectHit.name);
                    }
                }
            }
        }
        // Input.GetMouseButtonUp(0) only for UI
    }

    public void ToggleTurn()
    {
        if (curent_comand == Commands.Blue)
        {
            foreach (GameObject build in buildings)
            {
                if (build.GetComponent<BuildingStruct>().command_attachment == Commands.Blue)
                {
                    build.GetComponent<BuildingAbstract>().OnTurnEnd();
                }
            }
            curent_comand = Commands.Red;
            turn_txt.text = "Red";
            turn_txt.color = Color.red;
            // Add red in counter gold and actions

        }
        else
        {
            foreach (GameObject build in buildings)
            {
                if (build.GetComponent<BuildingStruct>().command_attachment == Commands.Red)
                {
                    build.GetComponent<BuildingAbstract>().OnTurnEnd();
                }
            }
            curent_comand = Commands.Blue;
            turn_txt.text = "Blue";
            turn_txt.color = Color.blue;
            // Add blue in counter gold and actions

        }
        refresh_counters();
    }

    public Commands GetTurn()
    {
        return curent_comand;
    }


    public void AddValueToCounters(int gold, int actions)
    {
        if (GetTurn() == Commands.Red)
        {
            gold_red += gold;
            actions_red += actions;
        }
        else
        {
            gold_blue += gold;
            actions_blue += actions;
        } 
    }


    public void refresh_counters()
    {
        if (curent_comand == Commands.Red)
        {
            gold_counter.text = gold_red.ToString();
            action_counter.text = actions_red.ToString();
        }
        else
        {
            gold_counter.text = gold_blue.ToString();
            action_counter.text = actions_blue.ToString();
        }
    }


    public bool PossibilityToSpend(int cost_gold, int cost_act)
    {
        if ((curent_comand == Commands.Red && gold_red - cost_gold >= 0 && actions_red - cost_act >= 0) || (curent_comand == Commands.Blue && gold_blue - cost_gold >= 0 && actions_blue - cost_act >= 0))
        {
            return true;
        }
        return false;
    }

    public void Spend(int cost_gold, int cost_act)
    {
        if (curent_comand == Commands.Red)
        {
            gold_red -= cost_gold;
            actions_red -= cost_act;
        }
        else
        {
            gold_blue -= cost_gold;
            actions_blue -= cost_act;
        }
        refresh_counters();
    }
}
