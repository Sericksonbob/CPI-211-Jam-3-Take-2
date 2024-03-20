using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveMii(string name, Face face)
    {
        if (Directory.GetFiles(Application.persistentDataPath, "*.smoothii").Length < 100)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + name.Trim() + ".smoothii";
            FileStream stream = new FileStream(path, FileMode.Create);

            Mii data = new Mii(face.pickedeye, face.eyesize, face.eyerot, face.eyeposx, face.eyeposy,
                               face.pickednose, face.nosesize, face.noseposy,
                               face.pickedmouth, face.mouthsize, face.mouthposy, face.mouththickness,
                               face.pickedeyebrow, face.eyebrowsize, face.eyebrowrot, face.eyebrowposx, face.eyebrowposy,
                               face.pickedglasses, face.glassessize, face.glassesposy,
                               face.pickedmoustache, face.moustachesize, face.moustacheposy,
                               face.pickedhair, face.haircolor,
                               face.pickedBeard, face.beardcolor, face.favcolor, face.skincolor, name); ;

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else
        {
            Debug.Log("Out of Smoothii Storage");
        }
    }

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
