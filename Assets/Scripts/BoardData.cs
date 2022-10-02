[System.Serializable]
public struct tile_to_save
{
    public int[] id;
    public TileType type;
    public Commands command;
}

[System.Serializable]
public struct building_to_save
{
    public int[] id;
    public BuildingsType type;
    public int healths;
    public Commands command;
}


namespace SaveData
{
    [System.Serializable]
    public class BoardData
    {
        public int gold_red;
        public int gold_blue;
        public int att_red;
        public int att_blue;

        public Commands current_turn;

        public int[] BoardTopology;
        public tile_to_save[] tiles_to_save;
        public building_to_save[] buildings_to_save;
    }
}