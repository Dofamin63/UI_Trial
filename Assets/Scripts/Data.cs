using System.Collections.Generic;

[System.Serializable]
public class Data
{
	public int gold;
	public int stars;
	public List<Skin> skins = new List<Skin>();
	public List<Skin> epicSkins = new List<Skin>();
}

[System.Serializable]
public class Skin
{
	public string name;
	public bool status;

	public Skin(string name, bool status)
    {
		this.name = name;
		this.status = status;
    }
}

