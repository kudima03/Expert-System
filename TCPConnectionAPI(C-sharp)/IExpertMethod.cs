using DatabaseEntities;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IExpertMethod
    {
        void Rate(ref Vehicle obj, Expert expert, float rate);
    }
}
