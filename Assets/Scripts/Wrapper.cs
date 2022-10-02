using System.Collections.Generic;
using UnityEngine;
using SaveData;

public class Wrapper : MonoBehaviour
{
    [SerializeField] private CameraController cam;
    public void SaveSnaphot(string savename)
    {
        var data = new BoardData();

        // tiles
        int board_length = cam.boardTopology[0] * cam.boardTopology[1];
        data.tiles_to_save = new tile_to_save[board_length];
        for (int i = 0; i < board_length; i++)
        {
            Tile_Struct tile = cam.tiles[i].GetComponent<Tile_Struct>();
            data.tiles_to_save[i].id = new int[2] { tile.index[0], tile.index[1] };
            data.tiles_to_save[i].type = tile.tile_type;
            data.tiles_to_save[i].command = tile.command_attachment;
        }

        // build
        int buildings_count = cam.buildings.Count;
        data.buildings_to_save = new building_to_save[buildings_count];
        for (int i = 0; i < buildings_count; i++)
        {
            BuildingStruct building = cam.buildings[i].GetComponent<BuildingStruct>();
            data.buildings_to_save[i].id = new int[2] { building.index[0], building.index[1] };
            data.buildings_to_save[i].command = building.command_attachment;
            data.buildings_to_save[i].type = building.building_type;
            data.buildings_to_save[i].healths = cam.buildings[i].GetComponent<BuildingAbstract>().healths.GetHealths();
        }

        // others vars
        data.BoardTopology = cam.boardTopology;

        data.gold_red = cam.gold_red;
        data.gold_blue = cam.gold_blue;
        data.att_red = cam.actions_red;
        data.att_blue = cam.actions_blue;

        data.current_turn = cam.GetTurn();

        // Save to Prefs
        if (savename != null)
        {
            SaveManager.Save(data, savename);
        }
        else
        {
            SaveManager.Save(data);
        }
    }

    public void LoadSnaphot(string savename)
    {
        // Load from Prefs
        var data = SaveManager.Load(savename);
        
        if (data != null)
        {
            // others vars
            cam.boardTopology = data.BoardTopology;
            cam.gold_red = data.gold_red;
            cam.gold_blue = data.gold_blue;
            cam.actions_blue = data.att_blue;
            cam.actions_red = data.att_red;

            cam.curent_comand = data.current_turn;

            // tiles

            int board_length = data.BoardTopology[0] * data.BoardTopology[1];
            GameObject[] tiles = new GameObject[board_length];

            for (int i = 0; i < board_length; i++)
            {
                tile_to_save tile = data.tiles_to_save[i];
                tiles[i] = GetComponent<TileFabric>().create_tile(tile.type, new Vector2Int(tile.id[0], tile.id[1]), tile.command);
            }

            // buildings
            int buildings_count = data.buildings_to_save.Length;
            List<GameObject> buildings = new List<GameObject>();
            for (int i = 0; i < buildings_count; i++)
            {
                building_to_save building = data.buildings_to_save[i];
                buildings.Add(GetComponent<BuildFabric>().create_build(building.type, new Vector2Int(building.id[0], building.id[1]), building.command, building.healths));
            }

            // cam.buildings = buildings;
            cam.tiles = tiles;
        }
        else
        {
            LoadDefaults();
        }
        

    }

    public void LoadDefaults()
    {
        var data = SaveManager.Defaults();
        if (data != null)
        {
            // others vars
            cam.boardTopology = data.BoardTopology;
            cam.gold_red = data.gold_red;
            cam.gold_blue = data.gold_blue;
            cam.actions_blue = data.att_blue;
            cam.actions_red = data.att_red;

            cam.curent_comand = data.current_turn;

            // tiles

            int board_length = data.BoardTopology[0] * data.BoardTopology[1];
            GameObject[] tiles = new GameObject[board_length];

            for (int i = 0; i < board_length; i++)
            {
                tile_to_save tile = data.tiles_to_save[i];
                tiles[i] = GetComponent<TileFabric>().create_tile(tile.type, new Vector2Int(tile.id[0], tile.id[1]), tile.command);
            }

            // buildings
            int buildings_count = data.buildings_to_save.Length;
            List<GameObject> buildings = new List<GameObject>();
            for (int i = 0; i < buildings_count; i++)
            {
                building_to_save building = data.buildings_to_save[i];
                buildings.Add(GetComponent<BuildFabric>().create_build(building.type, new Vector2Int(building.id[0], building.id[1]), building.command, building.healths));
            }

            cam.buildings = buildings;
            cam.tiles = tiles;
        }
    }
}
