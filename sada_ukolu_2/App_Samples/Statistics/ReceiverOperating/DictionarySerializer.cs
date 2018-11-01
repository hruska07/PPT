using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ReceiverOperating
{
    public class DictionarySerializer
    {
        public class Item
        {            
            public string Folder { get; set; }                        
            public List<string> List { get; set; }

            public Item()
            {
                Folder = "";
                List = new List<string>();
            }
        }

        public static Dictionary<string, List<string>> ConvertFileInfoToString(Dictionary<string, List<FileInfo>> list)
        {
            Dictionary<string, List<string>> listConvert = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, List<FileInfo>> it0 in list)
            {
                listConvert.Add(it0.Key, new List<string>());
                foreach (FileInfo it2 in it0.Value)
                        listConvert[it0.Key].Add(it2.ToString());
            }
            return listConvert;
        }

        public static Dictionary<string, List<FileInfo>> ConvertFiloInfoToDictionary(System.Collections.ArrayList list, string rootname)
        {
            Dictionary<string, List<FileInfo>> listScript = new Dictionary<string,List<FileInfo>>();
            List<FileInfo> listFileInfo = new List<FileInfo>();
            foreach (FileInfo it in list)
                listFileInfo.Add(it);
            listScript.Add(rootname, listFileInfo);
            return listScript;
        }

        public static void SaveScript(Dictionary<string, List<string>> listScript, string filename)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filename);
                //XmlSerializer xs = new XmlSerializer(typeof(Dictionary<string, List<FileInfo>>));
                XmlSerializer xs = new XmlSerializer(typeof(Item[]), new XmlRootAttribute() { ElementName = "script" });
                xs.Serialize(sw, listScript.Select(kv=>new Item() { Folder = kv.Key, List = kv.Value}).ToArray());
            }
            catch (Exception) { throw; }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        public static Dictionary<string, List<FileInfo>> LoadScript(string filename)
        {
            StreamReader sr = null;
            Dictionary<string, List<string>> listScript = null;
            try
            {
                sr = new StreamReader(filename);
                XmlSerializer xs = new XmlSerializer(typeof(Item[]), new XmlRootAttribute() { ElementName = "script" });
                listScript = ((Item[])xs.Deserialize(sr)).ToDictionary(i => i.Folder, i => i.List);
            }
            catch (Exception) { }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            Dictionary<string, List<FileInfo>> listScriptFileInfo = new Dictionary<string,List<FileInfo>>();
            foreach (KeyValuePair<string, List<string>> it in listScript)
            {
                List<FileInfo> listFI = new List<FileInfo>();
                foreach (string it2 in it.Value)
                    listFI.Add(new FileInfo(it2));
                listScriptFileInfo.Add(it.Key, listFI);
            }

            return listScriptFileInfo;
        }

        /// <summary>
        /// Nalezne soubor (obrazek) podle identifikatoru - poradoveho cisla. A vrati uzel a cestu k souboru. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static KeyValuePair<string, FileInfo> FindItem(int index, Dictionary<string, List<FileInfo>> dict, Dictionary<string, List<FileInfo>> dict_2)
        {
            int i = 0;
            foreach (KeyValuePair<string, List<FileInfo>> it1 in dict)
                foreach (FileInfo it2 in it1.Value)
                {
                    if (i == index)
                        return new KeyValuePair<string, FileInfo>(it1.Key, it2);
                    i++;
                }
            foreach (KeyValuePair<string, List<FileInfo>> it1 in dict_2)
                foreach (FileInfo it2 in it1.Value)
                {
                    if (i == index)
                        return new KeyValuePair<string, FileInfo>(it1.Key, it2);
                    i++;
                }
            throw new KeyNotFoundException("Not found.");
        }


        public static Dictionary<string, List<FileInfo>> Diff(string script1, string script2)
        {
            try
            {
                Dictionary<string, List<FileInfo>> list_1 = LoadScript(script1);
                Dictionary<string, List<FileInfo>> list_2 = LoadScript(script2);
                Dictionary<string, List<FileInfo>> list_diff = new Dictionary<string, List<FileInfo>>();
                bool exist = true;
                foreach (KeyValuePair<string, List<FileInfo>> it1 in list_1)
                    foreach (FileInfo it2 in it1.Value)
                    {
                        exist = false;
                        if (list_2.ContainsKey(it1.Key) == true)
                        {
                            foreach (FileInfo it3 in list_2[it1.Key])
                                if (it3.FullName == it2.FullName)
                                {
                                    exist = true;
                                    break;
                                }
                        }

                        if (exist == false)
                        {
                            if (list_diff.ContainsKey(it1.Key) == false)
                                list_diff.Add(it1.Key, new List<FileInfo>());
                            list_diff[it1.Key].Add(it2);
                        }
                    }
                return list_diff;
            }
            catch (Exception) { throw; }
        }
    }
}
