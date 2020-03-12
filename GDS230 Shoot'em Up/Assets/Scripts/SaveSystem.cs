using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveWeaponData(GenericPlayerWeapon[] playerWeapons)
    {
        PlayerWeaponSaveData[] weaponData = new PlayerWeaponSaveData[16];

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerSaveData.WeaponData";
        FileStream stream = new FileStream(path, FileMode.Create);

        for(int ww = 0; ww < 16; ww++)
        {
            weaponData[ww] = new PlayerWeaponSaveData(playerWeapons[ww]);
        }

        formatter.Serialize(stream, weaponData);

        stream.Close();
    }
    public static void SaveWeaponData(PlayerWeaponSaveData[] playerWeapons)
    {
        PlayerWeaponSaveData[] weaponData = new PlayerWeaponSaveData[16];

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerSaveData.WeaponData";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        for (int ww = 0; ww < 16; ww++)
        {
            weaponData[ww] = playerWeapons[ww];
        }

        formatter.Serialize(stream, weaponData);

        stream.Close();
    }

    public static PlayerWeaponSaveData[] LoadWeaponData()
    {

        string path = Application.persistentDataPath + "/playerSaveData.WeaponData";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerWeaponSaveData[] temp = formatter.Deserialize(stream) as PlayerWeaponSaveData[];
            stream.Close();
            return temp;
        }
        else
        {
            return null;
        }
    }
}
