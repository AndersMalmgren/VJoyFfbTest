using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJoyFfbTest
{

    class SlimDXTarget 
    {

        //public bool SendFFBEffect(DataClasses.FFBEffectData data)
        //{
        //    //Check if the device is properly initialized
        //    if (ffbDevice == null)
        //    {
        //        MessageBox.Show("Device not initialized.", FFBInspector.Properties.Resources.errCap_devError,
        //                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        return false;
        //    }

        //    //If there is an effect already stored in this slot, remove it
        //    StopOneEffect(data.slot);

        //    int[] axes = new Int32[actuatorsObjectTypes.Count];
        //    int i = 0;
        //    foreach (int objt in actuatorsObjectTypes)
        //    {
        //        axes[i++] = objt;
        //    }

        //    //Set effect direction
        //    int[] dirs = data.effect.GetDirections();

        //    //Set the general effect parameters up
        //    EffectParameters eParams = new EffectParameters();
        //    eParams.Duration = data.effect.duration;
        //    eParams.Flags = EffectFlags.Cartesian | EffectFlags.ObjectIds;
        //    eParams.Gain = data.effect.gain;
        //    eParams.SetAxes(axes, dirs);
        //    eParams.StartDelay = data.effect.startDelay;
        //    eParams.SamplePeriod = 0; //Use the default sample period;
        //    eParams.TriggerButton = data.effect.trigButton;
        //    eParams.TriggerRepeatInterval = data.effect.trigRepInterval;

        //    //Set the type specific effect parameters up
        //    TypeSpecificParameters typeSpec = null;
        //    if (data.effect.effectGuid == EffectGuid.ConstantForce)
        //    {
        //        DataClasses.ConstantEffectTypeData cfEfd = (DataClasses.ConstantEffectTypeData)data.effect;
        //        typeSpec = new ConstantForce();
        //        typeSpec.AsConstantForce().Magnitude = cfEfd.magnitude;
        //    }
        //    else if (data.effect.effectGuid == EffectGuid.RampForce)
        //    {
        //        DataClasses.RampEffectTypeData rfEfd = (DataClasses.RampEffectTypeData)data.effect;
        //        typeSpec = new RampForce();
        //        typeSpec.AsRampForce().Start = rfEfd.start;
        //        typeSpec.AsRampForce().End = rfEfd.end;
        //    }
        //    else if (data.effect.effectGuid == EffectGuid.Sine || data.effect.effectGuid == EffectGuid.Triangle ||
        //             data.effect.effectGuid == EffectGuid.Square ||
        //             data.effect.effectGuid == EffectGuid.SawtoothUp ||
        //             data.effect.effectGuid == EffectGuid.SawtoothDown)
        //    {
        //        DataClasses.PeriodicEffectTypeData pfEfd = (DataClasses.PeriodicEffectTypeData)data.effect;
        //        typeSpec = new PeriodicForce();
        //        typeSpec.AsPeriodicForce().Magnitude = pfEfd.magnitude;
        //        typeSpec.AsPeriodicForce().Offset = pfEfd.offset;
        //        typeSpec.AsPeriodicForce().Period = pfEfd.period;
        //        typeSpec.AsPeriodicForce().Phase = pfEfd.phase;
        //    }
        //    else if (data.effect.effectGuid == EffectGuid.Friction || data.effect.effectGuid == EffectGuid.Inertia ||
        //             data.effect.effectGuid == EffectGuid.Damper || data.effect.effectGuid == EffectGuid.Spring)
        //    {
        //        DataClasses.ConditionEffectTypeData cdEfd = (DataClasses.ConditionEffectTypeData)data.effect;
        //        typeSpec = new ConditionSet();
        //        typeSpec.AsConditionSet().Conditions = new Condition[1];

        //        typeSpec.AsConditionSet().Conditions[0].DeadBand = cdEfd.deadBand;
        //        typeSpec.AsConditionSet().Conditions[0].Offset = cdEfd.offset;
        //        typeSpec.AsConditionSet().Conditions[0].NegativeCoefficient = cdEfd.negCoeff;
        //        typeSpec.AsConditionSet().Conditions[0].NegativeSaturation = cdEfd.negSat;
        //        typeSpec.AsConditionSet().Conditions[0].PositiveCoefficient = cdEfd.posCoeff;
        //        typeSpec.AsConditionSet().Conditions[0].PositiveSaturation = cdEfd.posSat;
        //    }
        //    eParams.Parameters = typeSpec;

        //    //Create an envelope
        //    if (data.envelope != null)
        //    {
        //        Envelope envp = new Envelope();
        //        envp.AttackLevel = data.envelope.attackLevel;
        //        envp.AttackTime = data.envelope.attackTime;
        //        envp.FadeLevel = data.envelope.fadeLevel;
        //        envp.FadeTime = data.envelope.fadeTime;

        //        eParams.Envelope = envp;
        //    }

        //    //Create an effect and add it to the list
        //    Effect ef;
        //    try
        //    {
        //        ef = new Effect(ffbDevice, data.effect.effectGuid, eParams);
        //        ffbEffects[data.slot] = ef;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Cannot create effect.\n" + ex.Message + "\n" + ex.Data,
        //                        FFBInspector.Properties.Resources.errCap_effError,
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return StartFFBEffect(ef);
        //}
    }
}
