using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu]
public class ScoreSaver : ScriptableObject
{
    public void SaveMaxScore(int scoreToSave)
    {
        if (GetSavedScore() < scoreToSave)
        {
            SaveScore(scoreToSave);
        }
    }

    private void SaveScore(int scoreToSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/SavedData.dat");
        bf.Serialize(file, scoreToSave);
        file.Close();
    }

    public int GetSavedScore()
    {
        if (File.Exists(Application.persistentDataPath
          + "/SavedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath
          + "/SavedData.dat", FileMode.Open);
            int savedScore = (int)bf.Deserialize(file);
            file.Close();
            return savedScore;
        }
        else return 0;
    }

    //public void DeleteSavedScore()
    //{
    //    if (File.Exists(Application.persistentDataPath
    //      + "/SavedData.dat"))
    //    {
    //        File.Delete(Application.persistentDataPath + "/SavedData.dat");
    //        Debug.Log("saved score deleted");
    //    }
    //    else Debug.Log("No saved score to delete");
    //}
}