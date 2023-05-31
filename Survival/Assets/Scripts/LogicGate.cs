using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate : MonoBehaviour
{
    enum Gate { NOT, AND, OR, NAND, NOR, XOR, XNOR }
    [SerializeField] Gate gate = Gate.NOT;

    // Start is called before the first frame update
    void Calculate(bool x, bool y)
    {
        bool output = false;
        switch (gate)
        {
            case Gate.NOT:
                output = NOT(x);
                break;
            case Gate.AND:
                output = AND(x, y);
                break;
            case Gate.OR:
                output = OR(x, y);
                break;
            case Gate.NAND:
                output = NAND(x, y);
                break;
            case Gate.NOR:
                output = NOR(x, y);
                break;
            case Gate.XOR:
                output = XOR(x, y);
                break;
            case Gate.XNOR:
                output = XNOR(x, y);
                break;
        }
        //return output;
    }

    bool NOT(bool x)
    {
        return !x;
    }

    bool AND(bool x, bool y)
    {
        bool output = false;
        if (x && y) output = true;
        return output;
    }

    bool OR(bool x, bool y)
    {
        bool output = false;
        if (x || y) output = true;
        return output;
    }

    bool XOR(bool x, bool y)
    {
        bool output = true;
        if (x != y) output = true;
        return output;
    }

    bool NAND(bool x, bool y)
    {
        bool output = true;
        if (x && y) output = true;
        return NOT(output);
    }

    bool NOR(bool x, bool y)
    {
        bool output = true;
        if (x || y) output = true;
        return NOT(output);
    }

    bool XNOR(bool x, bool y)
    {
        bool output = true;
        if (x != y) output = true;
        return NOT(output);
    }
}
