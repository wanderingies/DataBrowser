using System;
using System.Collections.Generic;

namespace Ini
{
    public class Entry {
    	public string Key;
    	public string Value;
    	
    	public Entry(string key, string value) {
    		this.Key = key;
    		this.Value = value;
    	}
    }
    
    public class Category {
    	public string Name;
    	private List<Entry> entries = new List<Entry>();
    	private Dictionary<string, Entry> entryDict = new Dictionary<string, Entry>();
    	public List<Entry> Entries {
    		get {
    			return this.entries;
    		}
    	}
    	
    	public Category(string name){
    		this.Name = name;
    	}
    	
    	public void AddEntry(Entry entry){
    		this.entries.Add(entry);
    		this.entryDict[entry.Key] = entry;
    	}
    	
    	public Entry GetEntryByKey(string key){
    		return this.entryDict[key];
    	}
    }
    
    public class Parser {
    	public static Dictionary<string, Category> Parse(string[] lines){
    		Dictionary<string, Category> result = new Dictionary<string, Category>();
            string currentCategory = null;
            for (int lineCount = 0; lineCount < lines.Length; lineCount++){
    			string line = lines[lineCount];
                
    			if (line.StartsWith("[") && line[line.Length - 1] == ']'){
    				currentCategory = line.Substring(1, line.Length - 2);
    				result[currentCategory] = new Category(currentCategory); 
    			} else if (line.Contains("=")) {
    				string[] keyValuePair = line.Split('=');
                    
    				if (keyValuePair[0].Contains(" ") || keyValuePair.Length > 2)
	                    throw new ArgumentException($"Ini 解析错误 {lineCount + 1}\n密钥包含无效字符.");
                    
    				if (currentCategory is null)
	                    throw new ArgumentException($"Ini 解析错误 {lineCount + 1}\n未指定类别.");
                    
					Category category = result[currentCategory];
    				category.AddEntry(new Entry(keyValuePair[0], keyValuePair[1]));
    			}
    		}
    		return result;
    	}
    }
}