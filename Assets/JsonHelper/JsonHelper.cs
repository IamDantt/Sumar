public class JsonHelper
{
	/*
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Items;
	}

	public static string ToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return UnityEngine.JsonUtility.ToJson(wrapper);
	}

	public static string ToJson<T>(T[] array, bool prettyPrint)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return UnityEngine.JsonUtility.ToJson(wrapper, prettyPrint);
	}

	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] Items;
	} */

	
	public static T[] GetArray<T>(string json)
	{
		string newJson = "{\"array\":  [" + json + "]  }";
		Wrapper<T> w = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(newJson);
		return w.array;
	}

	public static string arrayToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T> { array = array };
		string json = UnityEngine.JsonUtility.ToJson(wrapper);
		var pos = json.IndexOf(":");
		json = json.Substring(pos + 1); // cut away "{ \"array\":"
		pos = json.LastIndexOf('}');
		json = json.Substring(0, pos - 1); // cut away "}" at the end
		return json;
	}
	
	

	[System.Serializable]
	class Wrapper<T>
	{
		public T[] array;
	} 
}
