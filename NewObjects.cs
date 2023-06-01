public class NewObjects
{
   public static List<Wheel> NewWheelsList(float i_NumOfWheels, float i_MaxPressure)
   {
    List<Wheel> wheels = new List<Wheel>();
        for(int i = 0; i < i_NumOfWheels; i++)
        {   
            Wheel wheel = new Wheel("michlen", i_MaxPressure);
            wheels.Add(wheel);
        }
    return wheels;    
   }
}