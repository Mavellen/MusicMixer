using System.Collections.Generic;

public class SoundData
{
    public SoundData()
    {
        parameters = new Dictionary<string, float>();
        ClearDictionary();
    }

    // This is a collection of all exposed parameters of the music mixer that the user may influence with modifiers
    public Dictionary<string,float> parameters;

    // Before sending the sound to be played and the parameters to change the audio mixer for that moment of playback,
    // this applies the changes to the sound that modifiers that are connected to the sound have
    public void PrepareData(Dictionary<int,Parameter> param){
        foreach(Parameter p in param.Values){
            if(p.Activated) parameters[p._paramName] = p.cm._value;
        }
    }

    // The collection of parameters is reset to their defaults after every playback
    public void ClearDictionary(){
        parameters = new Dictionary<string, float>(); 
        parameters.Add("Volume", -10f); // in decibals, from -80db to 20db
        //parameters.Add("PitchSpeed",100f); // in percent, from 1% to 150%
        parameters.Add("ChorusDepth",0f); // in float, from 0 to 1 
        parameters.Add("ChorusRate",0f); // in Hz, from 0 to 20
        parameters.Add("EchoDryMix",0f); // in %, from 0 to 1
        parameters.Add("FlangeDryMix",0f); // in %, from 0 to 1
        parameters.Add("FlangeDepth",0.01f); // in float from 0.1 to 1.0
        parameters.Add("FlangeRate",0f); // in Hz, from 0 to 20
        parameters.Add("ParamEQOctaveRange",1f); // in octaves, from 0.2 to 5.0
        parameters.Add("ParamEQFrequencyGain",1f); // in float, from 0.05 to 3.0
        parameters.Add("PitchShifterPitch",1f); // in multiplier, from 0.5 to 2.0
        parameters.Add("ReverbRoom",-10000.00f); // in float, from -10000.00 to 0.00
    }
}
