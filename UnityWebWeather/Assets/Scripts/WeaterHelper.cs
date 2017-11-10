using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class WeaterHelper : MonoBehaviour
{
	/*
	调用国家气象局天气预报接口
	https://www.cnblogs.com/lonelyxmas/p/5667230.html
	{
		"10101":"北京","10102":"上海","10103":"天津","10104":"重庆","10105":"黑龙江",
		"10106":"吉林","10107":"辽宁","10108":"内蒙古","10109":"河北","10110":"山西",
		"10111":"陕西","10112":"山东","10113":"新疆","10114":"西藏","10115":"青海",
		"10116":"甘肃","10117":"宁夏","10118":"河南","10119":"江苏","10120":"湖北",
		"10121":"浙江","10122":"安徽","10123":"福建","10124":"江西","10125":"湖南",
		"10126":"贵州","10127":"四川","10128":"广东","10129":"云南","10130":"广西","
		10131":"海南","10132":"香港","10133":"澳门","10134":"台湾"
	}
	*/


	private string m_url ="http://www.weather.com.cn/data/cityinfo/101040100.html";
	void Start ()
	{
		StartCoroutine (GetWeather ());
	}



	IEnumerator GetWeather()
	{  
		if (m_url != null) {  
			WWW www = new WWW (m_url);  

			while (!www.isDone) { 
				yield return www;
			}  


			if (www.text != null) 
			{  
				Debug.Log (www.text);
				DoJsonData (www.text);
			}
		}
	}


	private void DoJsonData(string _jsonStr)
	{
		JsonData jd =JsonMapper.ToObject(_jsonStr);  
		JsonData jdInfo =jd["weatherinfo"];  
		Debug.Log (jdInfo ["weather"]);
	}
}
