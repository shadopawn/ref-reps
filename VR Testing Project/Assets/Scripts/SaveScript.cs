using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScript
{
    public static void SaveLesson (LessonConstructorScript lesson){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/lesson.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        LessonData data = new LessonData(lesson);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LessonData LoadLesson(){
        string path = Application.persistentDataPath + "/lesson.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LessonData data = formatter.Deserialize(stream) as LessonData;
            stream.Close();

            return data;
        }else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
