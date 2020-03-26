// Copyright (C) 2016-2017 David Pol. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

using FullSerializer;
using TMPro;

public class CardBuilderScene : MonoBehaviour
{

[SerializeField]
    private TextMeshProUGUI Attack;

    [SerializeField]
    private TextMeshProUGUI Health;

    [SerializeField]
    private TextMeshProUGUI Mana;

    [SerializeField]
    private TextMeshProUGUI Points;

    [SerializeField]
    private TextMeshProUGUI Name;

    [SerializeField]
    private TMP_InputField input;

    public GameObject ReopenMsg;

    private string cardname = "apples";

	private int atk = 0;
	private int hp = 1;
	private int cost = 0;
	private int pts = 2;

    public System.Random ran = new System.Random();
    public int rand;

    public void atkIncPressed()
    {
        if(pts > 0)
        {        
        	atk += 1;
        	pts -= 1;
    		Points.text = "Points: " + pts.ToString();
        	Attack.text = atk.ToString();
        }

    }
    public void atkDecPressed()
    {
    	if(atk>0)
    	{
    		atk -= 1;
    		pts += 1;
    		Points.text = "Points: " + pts.ToString();
            Attack.text = atk.ToString();
    	}
    }

    public void hpIncPressed()
    {
        if(pts > 0)
        {        
        	hp += 1;
        	pts -= 1;
    		Points.text = "Points: " + pts.ToString();
        	Health.text = hp.ToString();
        }
    }
    public void hpDecPressed()
    {
    	if(hp>1)
    	{
    		hp -= 1;
    		pts += 1;
    		Points.text = "Points: " + pts.ToString();
            Health.text = hp.ToString();
    	}
    }

    public void costIncPressed()
    {
        if(cost < 10) 
        {
	        cost += 1;
	        pts += 3;
	        Mana.text = cost.ToString();
	        Points.text = "Points: " + pts.ToString();
        }

    }
    public void costDecPressed()
    {
    	if(cost>0 && pts>3)
    	{
    		cost -= 1;
    		pts -= 3;
    		Points.text = "Points: " + pts.ToString();
            Mana.text = cost.ToString();
    	}
    }

    public void SubmitName()
    {
    	cardname = input.text;
    	Name.text = input.text;
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("DeckBuilder");
    }

    public void OnSaveButtonPressed()
    {
    	var cardPath = Application.streamingAssetsPath + "/card_lib.json";

        rand = ran.Next(100, 100000);
    	string newCard = @"
            {
                ""cardTypeId"": 0,
                ""name"": """ + cardname + @""",
                ""costs"": [
                    {
                        ""statId"": 1,
                        ""value"": " + cost + @",
                        ""$type"": ""CCGKit.PayResourceCost""
                    }
                ],
                ""properties"": [
                    {
                        ""value"": """",
                        ""name"": ""Text"",
                        ""$type"": ""CCGKit.StringProperty""
                    },
                    {
                        ""value"": ""Creature"",
                        ""name"": ""Picture"",
                        ""$type"": ""CCGKit.StringProperty""
                    },
                    {
                        ""value"": 4,
                        ""name"": ""MaxCopies"",
                        ""$type"": ""CCGKit.IntProperty""
                    },
                    {
                        ""value"": null,
                        ""name"": ""Material"",
                        ""$type"": ""CCGKit.StringProperty""
                    }
                ],
                ""stats"": [
                    {
                        ""baseValue"": " + atk + @",
                        ""statId"": 0,
                        ""name"": ""Attack"",
                        ""originalValue"": " + atk + @",
                        ""minValue"": 0,
                        ""maxValue"": 99,
                        ""modifiers"": []
                    },
                    {
                        ""baseValue"": " + hp + @",
                        ""statId"": 1,
                        ""name"": ""Life"",
                        ""originalValue"": " + hp + @",
                        ""minValue"": 0,
                        ""maxValue"": 99,
                        ""modifiers"": []
                    }
                ],
                ""keywords"": [
                    {
                        ""keywordId"": 0,
                        ""valueId"": 0
                    }
                ],
                ""abilities"": [
                    {
                        ""trigger"": {
                            ""zoneId"": 0,
                            ""$type"": ""CCGKit.OnCardEnteredZoneTrigger""
                        },
                        ""name"": null,
                        ""type"": ""Triggered"",
                        ""effect"": {
                            ""keywordTypeId"": 0,
                            ""keywordValueId"": 0,
                            ""gameZoneId"": 0,
                            ""cardTypeId"": 0,
                            ""$type"": ""CCGKit.AddKeywordEffect""
                        },
                        ""target"": {
                            ""conditions"": [],
                            ""$type"": ""CCGKit.ThisCard""
                        },
                        ""$type"": ""CCGKit.TriggeredAbility""
                    }
                ],
                ""id"": " + rand + @"
            },
            ";

    	string[] lines = File.ReadAllLines(cardPath);
    	using (StreamWriter writer = new StreamWriter(cardPath))
		{
		    for (int i = 0; i < lines.Length - 3; i++)
		    	writer.WriteLine(lines[i]);
		    writer.WriteLine(newCard);
		    for (int i = lines.Length - 3; i < lines.Length; i++)
		    	writer.WriteLine(lines[i]);
		}
		ReopenMsg.SetActive(true);
    }
    //This is a monstrosity
}
