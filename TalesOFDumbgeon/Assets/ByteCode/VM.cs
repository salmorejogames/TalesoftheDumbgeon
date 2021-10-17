using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ByteCode
{
    public class VM
    {
        private Stack<int> _stack;

        public VM()
        {
            _stack = new Stack<int>();
        }

        public void Interpret(List<char> bytecode)
        {
            for (int i = 0; i < bytecode.Count; i++)
            {
                char instruction = bytecode[i];
                switch (instruction)
                {
                    case (char) Instrucciones.Instruction.LITERAL_INT:
                        int value = (int) bytecode[++i];
                        _stack.Push(value);
                        break;
                    case (char) Instrucciones.Instruction.LITERAL_INT_NEGATIVE:
                        int valueN = -(int) bytecode[++i];
                        _stack.Push(valueN);
                        break;
                    case (char) Instrucciones.Instruction.LITERAL_CHAR:
                        char valueC = bytecode[++i];
                        _stack.Push((int) valueC);
                        break;
                    case (char) Instrucciones.Instruction.LITERAL_FLOAT:
                        //Debug.Log("LEYENDO FLOAT:");
                        int signo = (int) bytecode[++i];
                        int value1 = (int) bytecode[++i];   
                        int value2 = (int) bytecode[++i];
                        //Debug.Log("Valores: " + signo + " " + value1 + " " + value2);
                        //Primero sacamos la parte entera y luego la decimal, asique tienen que netrar al reves al stack.
                        _stack.Push(value2);
                        _stack.Push(value1);
                        _stack.Push(signo);
                        break;
                    case (char) Instrucciones.Instruction.SET_HEALTH:
                        int amount = _stack.Pop();
                        int objetive = _stack.Pop();
                        bool relative = Convert.ToBoolean(_stack.Pop());
                        InstructionManager.instance.SetHealth(amount, objetive, relative);
                        break;
                    case (char) Instrucciones.Instruction.SET_SPEED:
                        float pos = GetFloat();
                        float neg = GetFloat();
                        InstructionManager.instance.SetSpeed(pos, neg);
                        break;
                }
            }
        }

        private float GetFloat()
        {
            //Debug.Log("OBTENIENDO FLOAT");
            float num = 0;
            int signo = _stack.Pop();
            float parte_entera = _stack.Pop();
            float parte_decimal = _stack.Pop();
            //Debug.Log("Valores: " + signo + " " + parte_entera + " " + parte_decimal);  
            
            //Numero de digitos en la parte decimal
            int digitos = (int)Math.Floor(Math.Log10(parte_decimal) + 1);

            num = (float) (parte_entera + (parte_decimal/Math.Pow(10, digitos)));
            if (signo == 0)
                return -num;
            else
                return num;
        }
    } 
}

