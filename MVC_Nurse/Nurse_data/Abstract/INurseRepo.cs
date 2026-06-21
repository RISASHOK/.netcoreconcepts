using Nurse_data.Models;

namespace Nurse_data.Abstract
{
    public interface INurseRepo
    {
        List<Nurse> GetAllNurse();
        int InsertNurse(Nurse nurse);
        int UpdateNurse(Nurse nurse); 
        int DeleteNurse(int nurseId);
        Nurse GetNurseById(int hid);
    }
}
