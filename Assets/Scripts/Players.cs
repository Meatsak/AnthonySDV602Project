﻿using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
//Creates a list two store multiple players
public class Players
{
    private List<Player> _players = new List<Player>();

    public Player this[int index]
    {
        get
        {
            return _players[index];
        }
        set
        {
            _players[index] = value;
        }
    }

    public Players()
    {

    }
}


