using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class PartySaveSystem
{
    public static Mii LoadMii(string name)
    {
        string path = Application.persistentDataPath + "/"+name+".smoothii";
        if (File.Exists(path) && File.ReadAllText(path).Length !=0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Mii data = formatter.Deserialize(stream) as Mii;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Not found in " + path);
            return null;
        }
    }
    public static Mii LoadMiiFromFile(string path)
    {
        if (File.Exists(path) && File.ReadAllText(path).Length != 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Mii data = formatter.Deserialize(stream) as Mii;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Not found in " + path);
            return null;
        }
    }
    public static void DeleteMii(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".smoothii";
        if (File.Exists(path) && File.ReadAllText(path).Length != 0)
        {
            File.Delete(path);
        }
    }
}
