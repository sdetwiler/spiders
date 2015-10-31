using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public class Settings : System.Object {
	public float px, py, pz;
	public float rx, ry, rz;
	public float cameraFOV;


	public Vector3 getPosition()
	{
		return new Vector3(px, py, pz);
	}

	public Vector3 getRotation()
	{
		return new Vector3(rx, ry, rz);
	}

	public void setPosition(Vector3 p)
	{
		px = p.x;
		py = p.y;
		pz = p.z;
	}

	public void setRotation(Vector3 r)
	{
		rx = r.x;
		ry = r.y;
		rz = r.z;
	}
	
}

public class SettingsLoader {
	private string filename;

	// Use this for initialization
	public SettingsLoader () {
		filename = Application.persistentDataPath + "/settings.data";
	}
	
	public void Save(Settings settings) {
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream file = File.Create(filename);
		formatter.Serialize(file, settings);
		file.Close();
		Debug.LogFormat("Saved {0} {1}", settings.getPosition(), settings.getRotation());
	}

	public Settings Load() {
		Debug.Log ("Loading");
		if(File.Exists(filename)) {
			BinaryFormatter formatter = new BinaryFormatter();

			FileStream file = File.Open(filename, FileMode.Open);
			Settings settings = (Settings)formatter.Deserialize(file);
			file.Close();
			
			Debug.LogFormat("Loaded {0} {1}", settings.getPosition(), settings.getRotation());
			return settings;
		}
		Debug.Log("Nothing to load");
		return null;
	}
}
