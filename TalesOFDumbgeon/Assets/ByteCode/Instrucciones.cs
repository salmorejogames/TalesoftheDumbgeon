
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ByteCode
{
    public static class Instrucciones 
    {
        public enum Instruction
        {
            LITERAL_INT = 0x000,
            LITERAL_INT_NEGATIVE = 0x001,
            LITERAL_FLOAT = 0x002,
            LITERAL_CHAR = 0x003,
            LITERAL_STRING = 0x004,
            SET_HEALTH = 0x005,
            SET_SPEED = 0x006,
            PLAY_SOUND = 0x007
        }

        public static List<char> Interprete(string line)
        {
            Stack<char> charBytes = new Stack<char>();
            string[] lines = line.Split('#');
            
            //Detect Instruction
            switch (lines[0])
            {
                case "setHealth":
                    charBytes.Push((char) Instruction.SET_HEALTH);
                    break;
                case "playSound":
                    charBytes.Push((char) Instruction.PLAY_SOUND);
                    break;
                case "setSpeed":
                    charBytes.Push((char) Instruction.SET_SPEED);
                    break;
            }

            int value;
            bool valueBool;
            float valueF;
            for (int i = 0; i < lines.Length; i++)
            {
                if (bool.TryParse(lines[i], out valueBool))
                {
                    if(valueBool)
                        charBytes.Push((char) 1);
                    else
                        charBytes.Push((char) 0);
                    charBytes.Push((char) Instruction.LITERAL_INT);
                }
                else if (int.TryParse(lines[i], out value))
                {
                    if (value >= 0)
                    {
                        charBytes.Push((char) value);
                        charBytes.Push((char) Instruction.LITERAL_INT);
                    }
                    else
                    {
                        charBytes.Push((char) -value);
                        charBytes.Push((char) Instruction.LITERAL_INT_NEGATIVE);
                    }
                }
                else if (float.TryParse((lines[i]), out valueF))
                {
                    //Debug.Log("GENERANDO FLOAT: " + valueF);
                    int signo = 0;
                    if (valueF >= 0)
                        signo = 1;
                    valueF = Math.Abs(valueF);
                    int parteEntera = Mathf.FloorToInt(valueF);
                    string dec = valueF.ToString();
                    int parteDecimal = int.Parse(dec.Split(',')[1]);
                    //Debug.Log("SIGNO: " + signo + " PARTE ENTERA: " + parteEntera + " PARTE DECIMAL " + parteDecimal);
                    charBytes.Push((char) parteDecimal);
                    charBytes.Push((char) parteEntera);
                    charBytes.Push((char) signo);
                    
                    
                    charBytes.Push((char) Instruction.LITERAL_FLOAT);
                }
            }
            
            return new List<char>(charBytes);
        }
    }
}

