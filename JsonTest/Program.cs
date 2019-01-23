using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> JsonToDictionary(string jsonData)
            {
                //实例化JavaScriptSerializer类的新实例
                JavaScriptSerializer jss = new JavaScriptSerializer();
                try
                {
                    //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                    return jss.Deserialize<Dictionary<string, object>>(jsonData);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            string jsondata = "{\"dataSet\":{\"header\":{\"returnCode\":\"0\",\"errorInfo\":\"HTTP请求错误\",\"version\":\"V1.0R010\",\"totalRows\":\"2000\",\"returnRows\":\"20\"},\"fieldDefine\":{\"assetId\":\"string\",\"serverIdcId\":\"int\",\"inputTime\":\"datetime\"},\"data\":{\"row\":[{\"AssetId\":\"TCNS2006888\",\"ServerIdcId\":\"1\",\"InputTime\":\"2008-12-12\"},{\"AssetId\":\"TCNS2006889\",\"ServerIdcId\":\"2\",\"InputTime\":\"2008-1-1\"}]}}}";

            //Dictionary<string, object> dic = JsonToDictionary(jsondata);//将Json数据转成dictionary格式

            //Dictionary<string, object> dataSet = (Dictionary<string, object>)dic["dataSet"];
            //Dictionary<string, object> dataSet1 = (Dictionary<string, object>)dataSet["data"];
            ////使用KeyValuePair遍历数据
            //foreach (KeyValuePair<string, object> item in dataSet1)
            //{

            //    if (item.Key.ToString() == "row")//获取header数据
            //    {
            //        //ArrayList list = (Dictionary<string, object>)item;

            //        //var subItem = (Dictionary<string, object>)item.Value;
            //        var subItem1 = (ArrayList)item.Value;
            //        foreach (var str in subItem1)
            //        {
            //            var subItem = (Dictionary<string, object>)str;
            //            foreach (var item1 in subItem)
            //            {
            //                Console.WriteLine(item1.Key + ":" + item1.Value + "\r\n");//显示到界面

            //            }

            //        }
            //        break;
            //    }
            //}

            upDateData(jsondata);
            Console.ReadKey();
        }

        static Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  //string-json，to dictionary
        static void upDateData(string sourceData)  //处理树形列表
        {
            Dictionary<string, object> dic = JsonToDictionary(sourceData);//将Json数据转成dictionary格式           
            foreach (KeyValuePair<string, object> item in dic)
            {
                Console.WriteLine(item.Key + ":" + item.Value + "\r\n");
                Console.WriteLine("one" + "\r\n");

                if (item.Value.ToString() == "System.Collections.Generic.Dictionary`2[System.String,System.Object]")
                {
                    Dictionary<string, object> dataSet = (Dictionary<string, object>)dic[item.Key];
                    foreach (KeyValuePair<string, object> item1 in dataSet)
                    {
                        Console.WriteLine(item1.Key);
                        var subItem = (Dictionary<string, object>)item1.Value;
                        foreach (var str in subItem)
                        {
                            //if (str.ToString()== "System.Collections.ArrayList")
                            //{
                            //}
                             Console.WriteLine(str.Key + ":" + str.Value + "\r\n");//显示到界面
                            if (str.Value.ToString() == "System.Collections.ArrayList")
                            {
                                var subItem2 = (ArrayList)str.Value;                         
                                Console.WriteLine("来了老弟");
                                foreach (var item2 in subItem2)
                                {
                                    Console.WriteLine(item2.ToString() + "\r\n");
                                    Console.WriteLine("来啦");
                                    var subItem3 = (Dictionary<string, object>)item2;
                                    foreach (var item4 in subItem3)
                                    {
                                        Console.WriteLine(item4.Key + ":" + item4.Value + "\r\n");

                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
