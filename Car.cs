public class Car : Vehicle
{
    protected string m_CarColor;
    protected int m_DoorsAmount;

    public override List<string> AdditionalFields()
    {
        List<string> additionalFields = new List<string>();
        additionalFields.Add("Color");

        return additionalFields;
    }
}