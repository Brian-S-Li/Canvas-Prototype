// Copyright (C) 2016-2017 David Pol. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleCardBuilder : MonoBehaviour
{
    public GameObject Monster;
    public GameObject Spell;


    public void MonsterPress ()
    {
        Spell.SetActive(false);
        Monster.SetActive(true);
    }
    public void SpellPress ()
    {
        Spell.SetActive(true);
        Monster.SetActive(false);
    }
}
