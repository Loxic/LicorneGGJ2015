using UnityEngine;
using System.Collections;
using System.Xml;
using System;


public abstract class XMLParsing {
	private static XmlDocument xmlDoc;
	private static string fileName="./Annexe/Dialogues.xml";
	

	public static String getDialogue(int dialNum) {
		xmlDoc = new XmlDocument ();
		xmlDoc.Load(fileName);
		return ParseDialogue(xmlDoc.SelectNodes("dials/dial"), dialNum);
		
		}


	public static String ParseDialogue(XmlNodeList nodes, int dialNum){
		foreach (XmlNode node in nodes) {
			if (Convert.ToInt32 (node.Attributes.GetNamedItem ("num").Value) == dialNum) {
				return node.InnerText;
			}
	
		}

		return null;
	}


}
