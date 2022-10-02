using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private Commands attachment;

    private Camera cam;

    public Canvas main_canvas;
    public Canvas canv_unattachment;
    public Canvas canv_attachment;

    void Start()
    {
        // index
        Vector3 positiOnOfThisTile = transform.position;
        GetComponent<Tile_Struct>().index = new Vector2Int((int)positiOnOfThisTile.x, (int)positiOnOfThisTile.z);

        // setup mesh
        SetupMesh();

        // UI
        cam = GameObject.Find("Camera").GetComponent<Camera>();

        main_canvas.enabled = false;
        canv_unattachment.enabled = false;
        canv_attachment.enabled = false;

        main_canvas.worldCamera = cam;
    }

    void Update()
    {
        attachment = GetComponent<Tile_Struct>().command_attachment;

        WithTownCheck();
    }
    public void GetUI()
    {
        attachment = GetComponent<Tile_Struct>().command_attachment;

        // выводить UI для постройки если только вы владелец тайла и тип тайла - плоскость (default)
        if (cam.GetComponent<CameraController>().curent_comand == attachment && GetComponent<Tile_Struct>().tile_type == TileType.Default && GetComponent<Tile_Struct>().with_build == false)
        {
            // UI строительства
            main_canvas.enabled = true;
            canv_unattachment.enabled = false;
            canv_attachment.enabled = true;
        }

        // выводить UI для захвата если только вы не владелец тайла и тип тайла - плоскость (default) или лес
        else if (attachment != cam.GetComponent<CameraController>().curent_comand && (GetComponent<Tile_Struct>().tile_type == TileType.Default || GetComponent<Tile_Struct>().tile_type == TileType.Forest) && GetComponent<Tile_Struct>().with_build == false)
        {
            // UI для отжатия
            main_canvas.enabled = true;
            canv_unattachment.enabled = true;
            canv_attachment.enabled = false;
        }
    }

    public void HideUI()
    {
        main_canvas.enabled = false;
        canv_unattachment.enabled = false;
        canv_attachment.enabled = false;
    }

    private void WithTownCheck()
    {
        Ray up = new Ray(transform.position + Vector3.down, Vector3.up);
        bool hit;
        int layerBuildings = 1 << 7;
        hit = Physics.Raycast(up, Mathf.Infinity, layerBuildings);

        
        if (hit)
        {
            GetComponent<Tile_Struct>().with_build = true;
        }
        else
        {
            GetComponent<Tile_Struct>().with_build = false;
        }
    }


    // Функция создания сетки. Переписать
    private void SetupMesh()
    {
        Material m_Material = GetComponentInChildren<Renderer>().material;
        if ((GetComponent<Tile_Struct>().index.x + GetComponent<Tile_Struct>().index.y) % 2 == 1)
        {
            m_Material.color -= new Color(0.1f, 0.1f, 0.1f, 1);
        }
    }
}
