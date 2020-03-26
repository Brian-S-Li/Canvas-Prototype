// Copyright (C) 2016-2017 David Pol. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

using FullSerializer;
using TMPro;

using CCGKit;

public class CardBuilder : MonoBehaviour
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

    private string cardname = "apples";

	private int atk = 0;
	private int hp = 1;
	private int cost = 0;
	private int pts = 2;

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
    	if(cost>0 && pts>2)
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
}
